using Microsoft.AspNetCore.Mvc;
using TravelPickerApp.Models;
using TravelPickerApp.Models.UserControllerModels;
using TravelPickerApp.Services;

namespace TravelPickerApp.Controllers;
[ApiController]
[Route("api/v1/user")]
public class UserController:Controller
{
    private readonly AuthorizationService _authorizationService;
    private readonly ILogger<UserController> _logger;

    public UserController(AuthorizationService authorizationService, ILogger<UserController> logger)
    {
        this._authorizationService = authorizationService;
        this._logger = logger;
    }
    [Route("authorize")]
    [HttpPost]
    public async Task<IActionResult> Authorize([FromBody]AuthorizeBody body)
    {
        try
        {
            var result = await _authorizationService.AuthorizeUser(body.Username, body.Password, HttpContext);
            if (result.Code == AppCode.ActionSuccess)
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
            _logger.LogError(ex,"Exception thrown in Authorize controller method");
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
            _logger.LogError(ex,"Exception thrown in Logout controller method");
            return StatusCode(500);
        }
    }

    [Route("isLoggedIn")]
    [HttpGet]
    public ActionResult IsLoggedIn()
    {
        try
        {
            var userIdentity = HttpContext.User.Identity;
            if (userIdentity is not null && userIdentity.IsAuthenticated)
            {
                return Ok(new Result<bool>(AppCode.ActionSuccess, true, "User has a valid session"));
            }
            else
            {
                return Ok(new Result<bool>(AppCode.ActionSuccess, false, "User has no or invalid session"));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"Exception thrown in IsLoggedIn controller method");
            return StatusCode(500);
        }
    }

}