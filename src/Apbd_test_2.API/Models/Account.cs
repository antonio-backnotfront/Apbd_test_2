using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApbdTest2.API.Models;

[Table("Account")]
public class Account
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }

    public int RoleId { get; set; }
    [ForeignKey(nameof(RoleId))]
    public Role Role { get; set; }

}