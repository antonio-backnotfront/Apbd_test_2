using AuthTest.API.DAL;
using AuthTest.API.DTO;
using AuthTest.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.API.Services;

public interface IAccountsService
{
    public Task<List<GetAccounts>> GetAccountsAsync(CancellationToken cancellationToken);
    public Task<GetAccount?> GetAccountByIdAsync(int id, CancellationToken cancellationToken);
    public Task<CreateAccountDto?> CreateAccount(CreateAccountDto dto, CancellationToken cancellationToken);
    public Task<GetAccount?> GetAccountByUsernameAsync(string username, CancellationToken cancellationToken);
    public Task<Account?> GetAccountEntityByUsername(string username, CancellationToken cancellationToken);


}