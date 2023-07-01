using Microsoft.EntityFrameworkCore;
using TravelPickerApp.DAL;

namespace TravelPickerApp.Validators;

public class CountryValidator
{
    public static  Boolean CountryCodeExists(string countryCode,AppDbContext dbContext)
    {

        return  dbContext.Countries
            .Any(x => x.Iso == countryCode.ToUpperInvariant());
    }
}