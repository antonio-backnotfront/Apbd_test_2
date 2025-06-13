using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Apbd_test_2.API.Models;

[Table("Record")]
public class Record
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public double ExecutionTime { get; set; }
    
    public DateTime CreateAt { get; set; }
    
    public int LanguageId { get; set; }
    [ForeignKey(nameof(LanguageId))]
    public Language Language { get; set; }
    
    public int StudentId { get; set; }
    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; }
    
    public int TaskId { get; set; }
    [ForeignKey(nameof(TaskId))]
    public Task Task { get; set; }
    
    
    
    
    // public DbSet<>

}