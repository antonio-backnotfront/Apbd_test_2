using AuthTest.API.DAL;
using AuthTest.API.DTO;
using AuthTest.API.Models;
using AuthTest.API.Services;
using AuthTest.API.Services.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.API.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly PasswordHasher<Account> _passwordHasher;
    private readonly ILogger<AuthController> _logger;
    private readonly IAccountsService _accountsService;

    public AuthController(IAccountsService accountsService, ITokenService tokenService, ILogger<AuthController> logger)
    {
        _accountsService = accountsService;
        _logger = logger;
        _tokenService = tokenService;
        _passwordHasher = new PasswordHasher<Account>();
    }

    [HttpPost]
    public async Task<IActionResult> Auth(LoginAccountDto dto, CancellationToken ct)
    {
        try
        {
            var foundUser = await _accountsService.GetAccountEntityByUsername(dto.Login, ct);
            if (foundUser == null)
            {
                _logger.LogError("The user wasn't found");
                return Unauthorized();
            }
            
            var verificationResult = _passwordHasher.VerifyHashedPassword(foundUser, foundUser.Password, dto.Password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                _logger.LogError("The user password is incorrect");
                return Unauthorized();
            }

            var tokens = new
            {
                AccessToken = _tokenService.GenerateToken(foundUser.Username, foundUser.Role.Name)
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