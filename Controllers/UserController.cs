using Microsoft.AspNetCore.Mvc;
using TravelPickerApp.Models;
using TravelPickerApp.Models.ControllerModels.Users;
using TravelPickerApp.Services;

namespace TravelPickerApp.Controllers;
[ApiController]
[Route("api/v1/user")]
public class UserController:Controller
{
    private readonly AuthorizationService _authorizationService;
    private readonly LoggerService _logger;

    public UserController(AuthorizationService authorizationService, LoggerService logger)
    {
        this._authorizationService = authorizationService;
        this._logger = logger;
    }
    [Route("authorize")]
    [HttpPost]
    public async Task<IActionResult> Authorize([FromBody]AuthorizeBodyVM bodyVm)
    {
        try
        {
            var result = await _authorizationService.AuthorizeUser(bodyVm.Username, bodyVm.Password, HttpContext);
            if (result.Code == ActionStatusCode.ActionSuccess)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }

    [Route("logout")]
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _authorizationService.SignOutUser(HttpContext);
            return Ok();
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }

    [Route("isLoggedIn")]
    [HttpGet]
    public async Task<IActionResult> IsLoggedIn()
    {
        try
        {
            var userIdentity = HttpContext.User.Identity;
            if (userIdentity is not null && userIdentity.IsAuthenticated)
            {
                return Ok(new Result<bool>(ActionStatusCode.ActionSuccess, true, "User has a valid session"));
            }
            else
            {
                return Ok(new Result<bool>(ActionStatusCode.ActionSuccess, false, "User has no or invalid session"));
            }
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }

}