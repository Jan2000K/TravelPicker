using System.Security.Claims;
using TravelPickerApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TravelPickerApp.DAL;
using TravelPickerApp.Models;

namespace TravelPickerApp.Services;

public class AuthorizationService
{
    private readonly AppDbContext _appDbContext;
    private readonly UserService _userService;
    public AuthorizationService(AppDbContext appDbContext,UserService userService)
    {
        this._appDbContext = appDbContext;
        this._userService = userService;
    }

    public async Task<Result<string>> AuthorizeUser(string username, string password,HttpContext httpContext)
    {
        var userIdentity = httpContext.User.Identity;
        if (userIdentity is not null && userIdentity.IsAuthenticated)
        {
            return new Result<string>(AppCode.ActionSuccess,String.Empty, "User already authenticated");
        }
        var queriedUser = await _userService.GetUserByUsername(username);
        if (queriedUser is null)
            return new Result<string>(AppCode.ActionFailed,String.Empty, "Authentication Failed");
        if(!await HashService.CompareStringToHash(password,queriedUser.Password))
            return new Result<string>(AppCode.ActionFailed,String.Empty, "Authentication Failed");
        var userClaims = new List<Claim>();
        foreach (var userGroup in queriedUser.UserGroups)
        {
            userClaims.Add(new Claim(ClaimTypes.Role,userGroup.Id.ToString()));
        }
        userClaims.Add(new Claim(ClaimTypes.Name,queriedUser.Id.ToString()));
        var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IssuedUtc = DateTimeOffset.UtcNow,
            AllowRefresh = true
        };
        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);
        return new Result<string>(AppCode.ActionSuccess,String.Empty, "Authentication successful");
    }

    public async Task SignOutUser(HttpContext httpContext)
    {
        await httpContext.SignOutAsync();
    }
    

}