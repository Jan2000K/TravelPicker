using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelPickerApp.Models;
using TravelPickerApp.Models.ControllerModels.Location;
using TravelPickerApp.Services;

namespace TravelPickerApp.Controllers;
[Authorize]
[Route("api/v1/location")]
public class LocationController:Controller
{
    private readonly LoggerService _logger;
    private readonly LocationService _locationService;
    public LocationController(LoggerService logger,LocationService locationService)
    {
        _logger = logger;
        _locationService = locationService;
    }

    #region Get methods
    [HttpGet]
    [Authorize(policy:AppConstants.AuthPolicies.UserOrAbove)]
    public async Task<IActionResult> GetLocations()
    {
        try
        {
            var res = await _locationService.GetLocationsOfUser(User);
            return Ok(res);
        }
        catch(Exception Ex)
        {
            await _logger.LogExceptionAsync(Ex);
            return StatusCode(500);
        }
    }
    
    //Route for admins to get locations assigned to a certain User Id
    [HttpGet("assignedTo/{userId}")]
    [Authorize(policy:AppConstants.AuthPolicies.AdminOnly)]
    public async Task<IActionResult> AssignedTo([FromRoute]Guid userid)
    {
        try
        {
            var res = await _locationService.GetLocationsOfUser(userid);
            return Ok(res);
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }
    #endregion
    #region post methods
    [HttpPost]
    [Authorize(policy:AppConstants.AuthPolicies.UserOrAbove)]
    public async Task<IActionResult> CreateLocation([FromBody]AddLocationVM model)
    {
        try
        {
           var res =  await _locationService.AddLocation(model, User);
           return Ok(res);
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }
    #endregion
    #region Put methods

    [HttpPut]
    [Authorize(policy: AppConstants.AuthPolicies.UserOrAbove)]
    public async Task<IActionResult> EditLocation ([FromBody]EditLocationVM model)
    {
        try
        {
            var res = await _locationService.EditLocation(model, User);
            return Ok(res);
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }
    #endregion

    #region Delete methods

    [HttpDelete("{locationId}")]
    [Authorize(policy:AppConstants.AuthPolicies.UserOrAbove)]
    public async Task<IActionResult> DeleteLocation([FromRoute] Guid locationId)
    {
        try
        {
            var res  = await _locationService.DeleteLocation(locationId, User);
            return Ok(res);
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }

    #endregion
    
    
}