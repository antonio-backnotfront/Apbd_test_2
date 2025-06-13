using AuthTest.API.DAL;
using AuthTest.API.DTO;
using AuthTest.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.API.Services;

public interface IAuthService
{
    public Task<GetAccountDto?> ValidateLoginByUsernameAndPassword(LoginAccountDto dto, CancellationToken cancellationToken);


}