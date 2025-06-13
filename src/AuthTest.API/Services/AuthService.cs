using AuthTest.API.DAL;
using AuthTest.API.DTO;
using AuthTest.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.API.Services;

public class AuthService : IAuthService
{
    private readonly PasswordHasher<Account> _passwordHasher;
    private readonly AuthDbContext _context;

    public AuthService(AuthDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<Account>();
    }

    public async Task<GetAccountDto?> ValidateLoginByUsernameAndPassword(LoginAccountDto dto, CancellationToken cancellationToken)
    {
        var account = await _context.Accounts
            .Include(acc => acc.Role)
            .FirstOrDefaultAsync(acc => acc.Username == dto.Login, cancellationToken);
        if (account == null) return null;
        var verificationResult = _passwordHasher.VerifyHashedPassword(account, account.Password, dto.Password);
        
        return verificationResult == PasswordVerificationResult.Success ? new GetAccountDto()
        {
            Username = account.Username,
            Role = account.Role.Name
        } : null;
    }


}