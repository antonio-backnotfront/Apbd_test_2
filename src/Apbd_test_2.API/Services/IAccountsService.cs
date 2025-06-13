using ApbdTest2.API.DTO;
using ApbdTest2.API.DAL;
using ApbdTest2.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApbdTest2.API.Services;

public interface IAccountsService
{
    public Task<List<GetAccountsDto>> GetAccountsAsync(CancellationToken cancellationToken);
    public Task<GetAccountDto?> GetAccountByIdAsync(int id, CancellationToken cancellationToken);
    public Task<CreateAccountDto?> CreateAccount(CreateAccountDto dto, CancellationToken cancellationToken);
    public Task<GetAccountDto?> GetAccountByUsernameAsync(string username, CancellationToken cancellationToken);


}