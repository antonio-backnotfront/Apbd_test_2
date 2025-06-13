using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apbd_test_2.API.Models;

[Table("Language")]
public class Language
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<Record> Records { get; set; }

}