using Microsoft.EntityFrameworkCore;
using TravelPickerApp.DAL.Entities;

namespace TravelPickerApp.DAL;

public class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; } 
    public DbSet<UserGroup> UserGroups { get; set; } 

    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions)
    {
        
    }
    
}