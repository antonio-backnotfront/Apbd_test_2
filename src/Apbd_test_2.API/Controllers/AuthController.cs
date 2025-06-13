using ApbdTest2.API.DTO;
using ApbdTest2.API.Services;
using ApbdTest2.API.Services.Tokens;
using ApbdTest2.API.DAL;
using ApbdTest2.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApbdTest2.API.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _service;

    public AuthController(IAuthService service, ITokenService tokenService, ILogger<AuthController> logger)
    {
        _service = service;
        _logger = logger;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<IActionResult> Auth(LoginAccountDto dto, CancellationToken ct)
    {
        try
        {
            var userData = await _service.ValidateLoginByUsernameAndPassword(dto, ct); 
            if (userData == null)
            {
                _logger.LogInformation("Invalid username or password");
                return Unauthorized();
            }

            var tokens = new
            {
                AccessToken = _tokenService.GenerateToken(userData.Username, userData.Role)
            };
            return Ok(tokens);
        }
        catch (KeyNotFoundException)
        {
            _logger.LogError("Something went wrong during Authentication");
            return Unauthorized();
        }
    }
    
}