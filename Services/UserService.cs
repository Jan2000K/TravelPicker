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
        => await _appDbContext.Users.Where(x => x.Username == username).Include(x=>x.UserGroups).FirstOrDefaultAsync();

    public async Task<User?> GetUserById(Guid id)
        => await _appDbContext.Users.Include(x=>x.UserGroups).Where(x=>x.Id==id).FirstOrDefaultAsync();

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
}