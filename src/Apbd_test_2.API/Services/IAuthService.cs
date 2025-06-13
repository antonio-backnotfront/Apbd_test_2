using ApbdTest2.API.DTO;
using ApbdTest2.API.DAL;
using ApbdTest2.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApbdTest2.API.Services;

public interface IAuthService
{
    public Task<GetAccountDto?> ValidateLoginByUsernameAndPassword(LoginAccountDto dto, CancellationToken cancellationToken);


}