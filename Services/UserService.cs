using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using TravelPickerApp.DAL;
using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models;

namespace TravelPickerApp.Services;

public class UserService
{
    private readonly AppDbContext _appDbContext;
    private readonly LoggerService _logger;

    public UserService(AppDbContext appDbContext, LoggerService logger)
    {
        _appDbContext = appDbContext;
        _logger = logger;
    }

    public async Task<User?> GetUserByUsername(string username)
        => await _appDbContext.Users.Where(x => x.Username == username && x.Active).Include(x=>x.UserGroups).FirstOrDefaultAsync();

    public async Task<User?> GetUserById(Guid id)
        => await _appDbContext.Users.Include(x=>x.UserGroups).Where(x=>x.Id==id && x.Active).FirstOrDefaultAsync();

    public async Task<Guid?> GetUserIdFromClaimsPrincipal(ClaimsPrincipal user)
    {
        var userId = user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
        if (userId is null)
        {
            await _logger.LogInformationAsync("Cannot get User ID from Claims Principal", ActionStatusCode.UnexpectedError);
            return null;
        }

        return Guid.Parse(userId.Value);
    }

    public async Task<Result<Guid>> CreateUser(string username, string password,ICollection<Guid> userGroups,string? email = null)
    {
        var queriedUserGroups = await _appDbContext.UserGroups
            .Where(x => userGroups.Contains(x.Id)).ToListAsync();
        foreach (var userGroupId in userGroups)
        {
            var isInQueriedGroups =  queriedUserGroups.Where(x => x.Id == userGroupId).Select(x=>true).FirstOrDefault();
            if (!isInQueriedGroups)
            {
                await _logger.LogInformationAsync($"Request role id {userGroupId} not found",null);
            }
        }

        var hashedPass = await HashService.HashPassword(password);

        var user = new User()
        {
            UserGroups = queriedUserGroups,
            Active = true,
            Username = username,
            Email = email,
            Password = hashedPass
        };
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        await _logger.LogInformationAsync($"Successfully created user {username} with id {user.Id}",
            ActionStatusCode.ActionSuccess);
        return new Result<Guid>(ActionStatusCode.ActionSuccess, user.Id, $"Successfully created user {username} with id {user.Id}");
    }

    public async Task<Result<object>> DeactivateUser(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return new Result<object>(ActionStatusCode.ActionFailed, null, "Empty Guid was supplied");
        }
        var queriedUser = await _appDbContext.Users.FindAsync(userId);
        if (queriedUser is null)
        {
            return new Result<object>(ActionStatusCode.ActionFailed, null, $"User with ID ${userId} not found");
        }

        queriedUser.Active = false;
        await _appDbContext.SaveChangesAsync();
        await _logger.LogInformationAsync($"User {queriedUser.Username} with id {queriedUser.Id} has been deactivated",ActionStatusCode.ActionSuccess);
        return new Result<object>(ActionStatusCode.ActionSuccess, null,
            $"User {queriedUser.Username} with id {queriedUser.Id} has been deactivated");
    }
}