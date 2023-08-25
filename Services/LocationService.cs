using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TravelPickerApp.DAL;
using TravelPickerApp.Mappers;
using TravelPickerApp.Models;
using TravelPickerApp.Models.Builders;
using TravelPickerApp.Models.ControllerModels.Location;
using TravelPickerApp.Models.Location;

namespace TravelPickerApp.Services;

public class LocationService
{
    private readonly AppDbContext _dbContext;
    private readonly LoggerService _logger;
    private UserService _userService;

    public LocationService(AppDbContext dbContext, LoggerService logger, UserService userService)
    {
        _dbContext = dbContext;
        _logger = logger;
        _userService = userService;
    }

    public async Task<Result<LocationVM[]>> GetLocationsOfUser(Guid userId)
    {
        var locations = await _dbContext.Locations
            .Include(x => x.Country)
            .Where(x => x.AssignedTo.Id == userId)
            .Select(x => new LocationVM
            {
                Id = x.Id,
                Country = new KeyValueVM<string, string>(x.Country.Iso, x.Country.NiceName),
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                DateCreated = x.DateCreated,
                LocationName = x.LocationName
            })
            .ToArrayAsync();
        return new Result<LocationVM[]>(ActionStatusCode.ActionSuccess, locations,
            "Successfully fetched user locations");
    }
    public async Task<Result<LocationVM[]>> GetLocationsOfUser(ClaimsPrincipal user)
    {
        var userId = await _userService.GetUserIdFromClaimsPrincipal(user);
        if (userId is null)
        {
            return new Result<LocationVM[]>(ActionStatusCode.UnexpectedError, Array.Empty<LocationVM>(),
                AppConstants.CommonMessages.UserRelated.ErrorProcessingData);
        }
        var locations = await _dbContext.Locations
            .Include(x => x.Country)
            .Where(x => x.AssignedTo.Id == userId)
            .Select(x => new LocationVM
            {
                Id = x.Id,
                Country = new KeyValueVM<string, string>(x.Country.Iso, x.Country.NiceName),
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                DateCreated = x.DateCreated,
                LocationName = x.LocationName,
                RegionName = x.RegionName

            })
            .ToArrayAsync();
        return new Result<LocationVM[]>(ActionStatusCode.ActionSuccess, locations,
            "Successfully fetched user locations");
    }

    public async Task<Result<LocationVM>> GetLocationById(Guid locationId, ClaimsPrincipal user)
    {
        if (user.IsInRole(AppConstants.UserRoles.Admin.ToString()))
        {
            var location = await _dbContext.Locations
                .Include(x => x.Country)
                .Where(x => x.Id == locationId)
                .Select(x => LocationMapper.MapLocationToLocationVm(x))
                .FirstOrDefaultAsync();
            if (location is null)
            {
                return new Result<LocationVM>(ActionStatusCode.ActionFailed, null,
                    $"Location with Id {locationId} not found");
            }
            else
            {
                return new Result<LocationVM>(ActionStatusCode.ActionSuccess, location,
                    "Successfully fetched location");
            }

        }
        else
        {
            var userId = await _userService.GetUserIdFromClaimsPrincipal(user);
            if (userId is null)
            {
                return new Result<LocationVM>(ActionStatusCode.UnexpectedError, null, AppConstants.CommonMessages.UserRelated.ErrorProcessingData);
            }

            var location = await _dbContext.Locations
                .Include(x => x.Country)
                .Include(x => x.AssignedTo)
                .Where(x => x.Id == locationId && x.AssignedTo.Id == userId)
                .Select(x => LocationMapper.MapLocationToLocationVm(x))
                .FirstOrDefaultAsync();
            if (location is null)
            {
                return new Result<LocationVM>(ActionStatusCode.ActionFailed, null,
                    $"Location with Id {locationId} not found");
            }
            else
            {
                return new Result<LocationVM>(ActionStatusCode.ActionSuccess, location,
                    "Successfully fetched location");
            }
        }
    }

    public async Task<Result<Guid?>> AddLocation(AddLocationVM model, ClaimsPrincipal user)
    {
        var userId = await _userService.GetUserIdFromClaimsPrincipal(user);
        if (userId is null)
        {
            return new Result<Guid?>(ActionStatusCode.UnexpectedError, null,
                AppConstants.CommonMessages.UserRelated.ErrorProcessingData);
        }

        var dbUser = await _dbContext.Users.FindAsync(userId);
        if (dbUser is null)
        {
            return new Result<Guid?>(ActionStatusCode.UnexpectedError, null,
                AppConstants.CommonMessages.UserRelated.UserNotFound);
        }

        var country = await _dbContext.Countries
            .Where(x => x.Iso == model.CountryCode)
            .FirstOrDefaultAsync();

        if (country is null)
        {
            return new Result<Guid?>(ActionStatusCode.UnexpectedError, null,
                AppConstants.CommonMessages.CountryRelated.CountryDoesntExist);
        }
        var userLocations = await GetLocationsOfUser((Guid)userId);
        if (
            userLocations.Data.Any(x => x.LocationName.ToLowerInvariant() == model.LocationName.ToLowerInvariant() &&
            x.Country.Id.ToLowerInvariant() == model.CountryCode.ToLowerInvariant())
            )
        {
            return new Result<Guid?>(ActionStatusCode.ActionFailed, null, $"Location with name {model.LocationName}" +
                $" and country code {model.CountryCode} already exits");
        }

        var location = new LocationBuilder()
            .WithId(Guid.NewGuid())
            .WithName(model.LocationName)
            .CreatedBy(dbUser)
            .AssignedTo(dbUser)
            .AddedAt(DateTimeOffset.UtcNow)
            .WithLatitude(model.Latitude)
            .WithLongitude(model.Longitude)
            .WithCountry(country)
            .WithRegion(model.RegionName)
            .Build();
        await _dbContext.Locations.AddAsync(location);
        await _dbContext.SaveChangesAsync();
        await _logger.LogInformationAsync(
            $"Location with ID {location.Id} and name {location.LocationName} added by User {dbUser.Username}",
            ActionStatusCode.ActionSuccess);
        return new Result<Guid?>(ActionStatusCode.ActionSuccess, location.Id, "Location successfully added");
    }

    public async Task<Result<Guid?>> EditLocation(EditLocationVM model, ClaimsPrincipal user)
    {
        var userId = await _userService.GetUserIdFromClaimsPrincipal(user);
        if (userId is null)
        {
            return new Result<Guid?>(ActionStatusCode.UnexpectedError, null,
                AppConstants.CommonMessages.UserRelated.ErrorProcessingData);
        }

        var location = await _dbContext.Locations
            .Include(x => x.AssignedTo)
            .Where(x => x.Id == model.Id && x.AssignedTo.Id == userId)
            .FirstOrDefaultAsync();
        if (location is null)
        {
            return new Result<Guid?>(ActionStatusCode.ActionFailed, null,
                AppConstants.CommonMessages.LocationRelated.LocationNotFound);
        }

        var country = await _dbContext.Countries
            .Where(x => x.Iso == model.CountryCode)
            .FirstOrDefaultAsync();
        if (country is null)
        {
            return new Result<Guid?>(ActionStatusCode.ActionFailed, null,
                AppConstants.CommonMessages.CountryRelated.CountryDoesntExist);
        }
        location.Country = country;
        location.LocationName = model.LocationName;
        location.Latitude = model.Latitude;
        location.Longitude = model.Longitude;
        await _dbContext.SaveChangesAsync();
        return new Result<Guid?>(ActionStatusCode.ActionSuccess, location.Id, "Location successfully edited");
    }

    public async Task<Result<object?>> DeleteLocation(ICollection<Guid> locationIds, ClaimsPrincipal user)
    {
        var userId = await _userService.GetUserIdFromClaimsPrincipal(user);
        if (userId is null)
        {
            return new Result<object?>(ActionStatusCode.UnexpectedError, null,
                AppConstants.CommonMessages.UserRelated.ErrorProcessingData);
        }

        var locations = _dbContext.Locations
            .Include(x => x.AssignedTo)
            .Where(x => x.AssignedTo.Id == userId && locationIds.Contains(x.Id));
        if (!locations.Any())
        {
            return new Result<object?>(ActionStatusCode.ActionFailed, null,
                AppConstants.CommonMessages.LocationRelated.LocationNotFound);
        }

        _dbContext.Locations.RemoveRange(locations);
        await _dbContext.SaveChangesAsync();
        await _logger.LogInformationAsync($"User with id {userId} deleted {locations.Count()} locations", ActionStatusCode.ActionSuccess);
        return new Result<object?>(ActionStatusCode.ActionSuccess, null, $"Successfully deleted location");
    }

}