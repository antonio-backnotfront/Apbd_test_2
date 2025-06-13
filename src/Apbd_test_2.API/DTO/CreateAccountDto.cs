using System.ComponentModel.DataAnnotations;

namespace Apbd_test_2.API.DTO;

public class CreateAccountDto
{
    public int Id { get; set; }
    [Required]
    public required string Username { get; set;  }
    [Required]
    [MinLength(4, ErrorMessage = "Minimum password length is 4")]
    public required string Password { get; set; }
    [Required]
    public required int RoleId { get; set; }
}