namespace Apbd_test_2.API.Services.Tokens;

public interface ITokenService
{
    string GenerateToken(string username, string role);
}