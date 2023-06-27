using Microsoft.EntityFrameworkCore;
using TravelPickerApp.DAL;

namespace TravelPickerApp.Validators;

public class CountryValidator
{
    public static async Task<Boolean> CountryCodeExists(string countryCode,AppDbContext dbContext)
    {
        return await dbContext.Countries
            .Where(x => x.Iso == countryCode.ToUpperInvariant())
            .Select(x => true)
            .FirstOrDefaultAsync();
    }
}