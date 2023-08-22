using Microsoft.AspNetCore.Mvc;
using TravelPickerApp.Models;
using TravelPickerApp.Models.ControllerModels.Users;
using TravelPickerApp.Services;

namespace TravelPickerApp.Controllers;
[ApiController]
[Route("api/v1/user")]
public class UserController : Controller
{
    private readonly AuthorizationService _authorizationService;
    private readonly LoggerService _logger;
    private readonly UserService _userService;

    public UserController(AuthorizationService authorizationService, LoggerService logger, UserService userService)
    {
        _authorizationService = authorizationService;
        _logger = logger;
        _userService = userService;

    }
    [Route("authorize")]
    [HttpPost]
    public async Task<IActionResult> Authorize([FromBody] AuthorizeBodyVM model)
    {
        try
        {
            var result = await _authorizationService.AuthorizeUser(model.Username, model.Password, HttpContext);
            return Ok(result);
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

    [HttpPost("add")]
    public async Task<IActionResult> AddUser([FromBody] AddUserVM model)
    {
        try
        {
            var result = await _userService.CreateUser(model.Username, model.Password, model.UserGroups, model.Email);
            return Ok(result);
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }

    [HttpGet("{userId}/deactivate")]
    public async Task<IActionResult> DeactivateUser([FromRoute] Guid userId)
    {
        try
        {
            var result = await _userService.DeactivateUser(userId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            await _logger.LogExceptionAsync(ex);
            return StatusCode(500);
        }
    }
}