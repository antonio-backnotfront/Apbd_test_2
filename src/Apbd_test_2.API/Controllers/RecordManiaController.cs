using Apbd_test_2.API.DTO;
using Apbd_test_2.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apbd_test_2.API.Controllers;

[ApiController]
[Route("/api")]
public class RecordManiaController : ControllerBase
{
    private readonly ILogger<RecordManiaController> _logger;
    private readonly ITaskService _taskService;
    private readonly IStudentService _studentService;
    private readonly ILanguageService _languageService;
    private readonly IRecordService _recordService;

    public RecordManiaController(IRecordService recordService, ITaskService taskService, IStudentService studentService, ILanguageService languageService, ILogger<RecordManiaController> logger)
    {
        _recordService = recordService;
        _taskService = taskService;
        _studentService = studentService;
        _languageService = languageService;
        _logger = logger;
    }

    [HttpGet("records")]
    public async Task<ActionResult<IEnumerable<GetRecordsDto>>> GetRecords(CancellationToken cancellationToken)
    {
        return await _recordService.GetRecordsAsync(cancellationToken);
    }
    
    [HttpGet("records/{id}")]
    public async Task<ActionResult<IEnumerable<GetRecordsDto>>> GetRecordById(int id, CancellationToken cancellationToken)
    {
        GetRecordsDto record = await _recordService.GetRecordByIdAsync(id, cancellationToken);
        return record != null ? Ok(record) : NotFound("No record found");
    }
    
    [HttpPost("records")]
    public async Task<ActionResult<GetRecordsDto>> CreateRecord([FromBody] CreateRecordDto dto, CancellationToken cancellationToken)
    {
        var created = await _recordService.CreateRecordAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetRecordById), new { id = created.Id }, created);
    }
    
}