namespace Apbd_test_2.API.DTO;

public class CreateRecordDto
{
    public int LanguageId { get; set; }
    public int TaskId { get; set; }
    public CreateTaskDto? Task { get; set; }
    public int StudentId { get; set; }
    public long ExecutionTime { get; set; }
    public string Created { get; set; }
}