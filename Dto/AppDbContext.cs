using Microsoft.EntityFrameworkCore;
using TravelPickerApp.Dto.Entities;

namespace TravelPickerApp.Dto;

public class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<GeoDbApiCallLog> GeoDbApiCallLog { get; set; }
    public DbSet<ApplicationLog> ApplicationLog { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

}