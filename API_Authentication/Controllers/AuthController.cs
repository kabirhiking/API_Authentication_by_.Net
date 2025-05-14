using Microsoft.AspNetCore.Mvc;
using API_Authentication.Models;
using API_Authentication.Services;


namespace API_Authentication.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = authService.Register(request);
        return result == "User registered succcessfully." ? Ok(result) :BadRequest(result);
        
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var response = authService.Login(request);
        return response is null ? Unauthorized("Invalid credentials") : Ok(response);
    }

}