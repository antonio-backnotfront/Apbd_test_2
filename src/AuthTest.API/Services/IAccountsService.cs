using AuthTest.API.DAL;
using AuthTest.API.DTO;
using AuthTest.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.API.Services;

public interface IAccountsService
{
    public Task<List<GetAccountsDto>> GetAccountsAsync(CancellationToken cancellationToken);
    public Task<GetAccountDto?> GetAccountByIdAsync(int id, CancellationToken cancellationToken);
    public Task<CreateAccountDto?> CreateAccount(CreateAccountDto dto, CancellationToken cancellationToken);
    public Task<GetAccountDto?> GetAccountByUsernameAsync(string username, CancellationToken cancellationToken);


}