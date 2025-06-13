namespace Apbd_test_2.API.DTO;

public class CreateRecordDto
{
    public int LanguageId { get; set; }
    public int TaskId { get; set; }
    public int StudentId { get; set; }
    public double ExecutionTime { get; set; }
    public DateTime Created { get; set; }
}