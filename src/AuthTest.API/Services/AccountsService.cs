using AuthTest.API.DAL;
using AuthTest.API.DTO;
using AuthTest.API.Exceptions;
using AuthTest.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.API.Services;

public class AccountsService : IAccountsService
{
    
    AuthDbContext _context;
    PasswordHasher<Account> _passwordHasher;

    public AccountsService(AuthDbContext context)
    {
        _passwordHasher = new PasswordHasher<Account>();
        _context = context;
    }
    
    public async Task<List<GetAccountsDto>> GetAccountsAsync(CancellationToken cancellationToken)
    {
        return await _context.Accounts
            .Select(acc => new GetAccountsDto()
            {
                Id = acc.Id,
                Username = acc.Username
                
            })
            .ToListAsync(cancellationToken);
    }
    
    public async Task<GetAccountDto?> GetAccountByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Accounts
            .Select(acc => new GetAccountDto()
            {
                Id = acc.Id,
                Username = acc.Username,
                Role = acc.Role.Name
            })
            .FirstOrDefaultAsync(acc => acc.Id == id, cancellationToken);
    }
    
    public async Task<GetAccountDto?> GetAccountByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return await _context.Accounts
            .Select(acc => new GetAccountDto()
            {
                Id = acc.Id,
                Username = acc.Username,
                Role = acc.Role.Name
            })
            .FirstOrDefaultAsync(acc => acc.Username == username, cancellationToken);
    }
    
   
    
    public async Task<CreateAccountDto?> CreateAccount(CreateAccountDto dto, CancellationToken cancellationToken)
    {
        // check uniqueness
        _ = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Username == dto.Username, cancellationToken)
            != null ? throw new AlreadyExistsException($"This username '{dto.Username}' already exists") : "";
        
        var role = await _context.Roles.FirstOrDefaultAsync(role => role.Id == dto.RoleId, cancellationToken);
        if (role == null)
            throw new NotFoundException($"The role with id '{dto.RoleId}' does not exist'");


        Account newAccount = new Account()
        {
            Username = dto.Username,
            RoleId = dto.RoleId
        };
        newAccount.Password = _passwordHasher.HashPassword(newAccount, dto.Password);   
        Account createdAccount = (await _context.AddAsync(newAccount, cancellationToken)).Entity;
        await _context.SaveChangesAsync(cancellationToken);
        Console.WriteLine(createdAccount.Username);
        Console.WriteLine(createdAccount.Id);
        CreateAccountDto returnCreatedEntity = new CreateAccountDto()
        {
            Id = createdAccount.Id,
            Username = createdAccount.Username,
            Password = createdAccount.Password,
            RoleId = createdAccount.RoleId
        };
        return returnCreatedEntity; 
    }
}