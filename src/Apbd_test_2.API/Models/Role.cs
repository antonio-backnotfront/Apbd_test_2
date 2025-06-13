using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApbdTest2.API.Models;

[Table("Role")]
public class Role
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Account> Accounts { get; set; }

}