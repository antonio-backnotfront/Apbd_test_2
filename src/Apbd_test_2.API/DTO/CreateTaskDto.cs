using System.ComponentModel.DataAnnotations;

namespace Apbd_test_2.API.DTO;

public class CreateTaskDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
}