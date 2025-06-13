namespace AuthTest.API.DTO;

public class GetAccount
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Role { get; set; }
}