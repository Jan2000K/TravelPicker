using Microsoft.EntityFrameworkCore;
using TravelPickerApp.DAL;
using TravelPickerApp.DAL.Entities;

namespace TravelPickerApp.Services;

public class UserService
{
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;
    }

    public async Task<User?> GetUserByUsername(string username)
        => await _appDbContext.Users.Where(x => x.Username == username).Include(x=>x.UserGroups).FirstOrDefaultAsync();

    public async Task<User?> GetUserById(Guid id)
        => await _appDbContext.Users.Include(x=>x.UserGroups).Where(x=>x.Id==id).FirstOrDefaultAsync();

}