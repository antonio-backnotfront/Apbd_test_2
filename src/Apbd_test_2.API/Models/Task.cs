using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apbd_test_2.API.Models;

[Table("Task")]
public class Task
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    public ICollection<Record> Records { get; set; }
    
}