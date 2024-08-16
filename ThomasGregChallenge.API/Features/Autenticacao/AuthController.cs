using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThomasGregChallenge.API.Secure;
using ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        if (login.Email == "mr.zampieri@live.com" && login.Password == "P@ssw0rd")
        {
            var token = _tokenService.GenerateToken(login.Email, "Admin");
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}

public class LoginModel : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
