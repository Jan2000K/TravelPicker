using Microsoft.EntityFrameworkCore;
using TravelPickerApp.DAL;
using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models;

namespace TravelPickerApp.Services;

public class SeedingService
{
    private readonly LoggerService _logger;
    private readonly AppDbContext _context;

    public SeedingService(LoggerService logger, AppDbContext ctx)
    {
        _context = ctx;
        _logger = logger;
    }

    public async Task SeedTestData()
    {
        if (await IsDatabaseTestSeeded())
        {
            return;
        }   
        var normalUserRole = await _context.UserGroups.FindAsync(AppConstants.UserRoles.User);
        var adminUserRole = await _context.UserGroups.FindAsync(AppConstants.UserRoles.Admin);
        if (normalUserRole is null)
        {
            await _logger.LogInformationAsync($"Cannot find user role  User with id {AppConstants.UserRoles.User}",ActionStatusCode.ActionFailed);
            return;
        }
        if (adminUserRole is null)
        {
            await _logger.LogInformationAsync($"Cannot find user role Admin with id {AppConstants.UserRoles.Admin}",ActionStatusCode.ActionFailed);
            return;
        }
    
        var adminUser = new User
        {
            Id = new Guid("CE651EAC-D35E-4C7F-99A4-39D48C4D2B46"),
            Username = "AdminTestUser",
            Password = await HashService.HashPassword("AdminUserPass"),
            Email = "TestAdminUserEmail.com",
            Active = true,
            UserGroups = new[] { adminUserRole, normalUserRole }
        };
        var normalUser = new User
        {
            Id = new Guid("C0F8B026-B01C-4A01-96AE-8D293825A87A"),
            Username = "NormalTestUser",
            Password = await HashService.HashPassword("NormalUserPass"),
            Email = "TestNormalUserEmail.com",
            Active = true,
            UserGroups = new[] { normalUserRole }
        };
        await _context.Users.AddRangeAsync(new[] { adminUser, normalUser });
        await _logger.LogInformationAsync($"Successfully finished seeding test data", ActionStatusCode.ActionSuccess);
    }

    private async Task<bool> IsDatabaseTestSeeded()
    {
        return await _context.Users.AnyAsync(x =>
            x.Id == AppConstants.TestConstants.TestUsers.AdminUser ||
            x.Id == AppConstants.TestConstants.TestUsers.NormalUser);
    }
}