namespace Apbd_test_2.API.DTO;

public class GetAccountDto
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Role { get; set; }
}