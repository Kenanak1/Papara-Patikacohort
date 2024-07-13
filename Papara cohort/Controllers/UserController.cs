using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IAuthService _authService;

    public UserController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        if (_authService.Authenticate(user.Username, user.Password))
        {
            return Ok($"Logged in as {user.Username}");
        }
        return Unauthorized("Invalid credentials");
    }

    [HttpGet("secure")]
    [UserAuth]
    public IActionResult Secure()
    {
        return Ok("This is a secure endpoint");
    }
}
