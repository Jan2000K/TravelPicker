using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelPickerApp.Models;
using TravelPickerApp.Models.ControllerModels.City;
using TravelPickerApp.Services;

namespace TravelPickerApp.Controllers;
[ApiController]
[Route("api/v1/city")]
public class CityController:Controller
{
    private readonly GeoSearchService _geoSearchService;
    private readonly LoggerService _logger;
    public CityController(GeoSearchService geoSearchService, LoggerService logger)
    {
        _geoSearchService = geoSearchService;
        _logger = logger;
    }
    
    [HttpPost("random")]
    [Authorize(policy: AppConstants.AuthPolicies.UserOrAbove)]
    public async Task<IActionResult> GetRandomCity(RandomCityFilterVM filter)
    {
        try
        {
           var res = await  _geoSearchService.GetRandomCity(filter, User);
           return Ok(res);
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }
}