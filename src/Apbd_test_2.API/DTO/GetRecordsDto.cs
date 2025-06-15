using Apbd_test_2.API.Models;

namespace Apbd_test_2.API.DTO;

public class GetRecordsDto
{
    public int Id { get; set; }
    public GetLanguageDto Language { get; set; }
    public GetTaskDto Task { get; set; }
    public GetStudentDto Student { get; set; }
    public double ExecutionTime { get; set; }
    public DateTime Created { get; set; }
}