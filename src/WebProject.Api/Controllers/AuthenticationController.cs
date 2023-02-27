using Microsoft.AspNetCore.Mvc;
using WebProject.Application.Services.Authentication;
using WebProject.Contracts.Authentication;

namespace WebProject.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = authenticationService.Register(
            request.Name, 
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Name,
            authResult.User.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = authenticationService.Login(
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Name,
            authResult.User.Email,
            authResult.Token);

        return Ok(response);
    }
}
