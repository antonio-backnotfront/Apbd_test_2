using System.Globalization;
using Apbd_test_2.API.DAL;
using Apbd_test_2.API.DTO;
using Apbd_test_2.API.Exceptions;
using Apbd_test_2.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace Apbd_test_2.API.Services;

public class RecordService : IRecordService
{
    RecordDbContext _context;

    public RecordService(RecordDbContext context)
    {
        _context = context;
    }

    public async Task<GetRecordsDto?> GetRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var record = await _context.Records
            .OrderBy(r => r.CreatedAt)
            .Include(r => r.Language)
            .Include(r => r.Task)
            .Include(r => r.Student)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        if (record == null) return null;

        return new GetRecordsDto
        {
            Id = record.Id,
            Language = new GetLanguageDto
            {
                Id = record.LanguageId,
                Name = record.Language.Name
            },
            Task = new GetTaskDto
            {
                Id = record.TaskId,
                Name = record.Task.Name,
                Description = record.Task.Description,
            },
            Student = new GetStudentDto
            {
                Id = record.StudentId,
                FirstName = record.Student.FirstName,
                LastName = record.Student.LastName,
                Email = record.Student.Email,
            },
            ExecutionTime = record.ExecutionTime,
            Created = record.CreatedAt.ToString(),
        };
    }


    public async Task<List<GetRecordsDto>> GetRecordsAsync(CancellationToken cancellationToken)
    {
        string format = "dd/MM/yyyy HH:mm:ss";
        
        return await _context.Records
            .OrderByDescending(r => r.CreatedAt)
            .Include(r => r.Language)
            .Include(r => r.Task)
            .Include(r => r.Student)
            .Select(rec => new GetRecordsDto
            {
                Id = rec.Id,
                Language = new GetLanguageDto
                {
                    Id = rec.LanguageId,
                    Name = rec.Language.Name
                },
                Task = new GetTaskDto
                {
                    Id = rec.TaskId,
                    Name = rec.Task.Name,
                    Description = rec.Task.Description,
                },
                Student = new GetStudentDto
                {
                    Id = rec.StudentId,
                    FirstName = rec.Student.FirstName,
                    LastName = rec.Student.LastName,
                    Email = rec.Student.Email,
                },
                ExecutionTime = rec.ExecutionTime,
                Created = rec.CreatedAt.ToString(format, CultureInfo.InvariantCulture),
            }).ToListAsync(cancellationToken);
    }
    
    public async Task<GetRecordsDto> CreateRecordAsync(CreateRecordDto dto, CancellationToken cancellationToken)
    {
        string format = "dd/MM/yyyy HH:mm:ss";
        DateTime parsedDate;
        if (!DateTime.TryParseExact(dto.Created, format, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out parsedDate))
        {
            throw new ArgumentException($"Not a valid date, field 'created' should be in the following format {format}");
        }
        Console.WriteLine($"{parsedDate}");
        
        var language = await _context.Languages.FindAsync(new object[] { dto.LanguageId }, cancellationToken);
        if (language == null)
            throw new NotFoundException($"Language with ID {dto.LanguageId} not found.");
        var student = await _context.Students.FindAsync(new object[] { dto.StudentId }, cancellationToken);
        if (student == null)
            throw new NotFoundException($"Student with ID {dto.StudentId} not found.");
        
        var task = await _context.Tasks.FindAsync(new object[] { dto.TaskId }, cancellationToken);
        if (task == null)
            throw new NotFoundException($"Task with ID {dto.TaskId} not found.");
        var record = new Record
        {
            LanguageId = dto.LanguageId,
            TaskId = dto.TaskId,
            StudentId = dto.StudentId,
            ExecutionTime = dto.ExecutionTime,
            CreatedAt = parsedDate
        };

        _context.Records.Add(record);
        await _context.SaveChangesAsync(cancellationToken);

        return new GetRecordsDto
        {
            
            Id = record.Id,
            Language = new GetLanguageDto
            {
                Id = record.LanguageId,
                Name = record.Language.Name
            },
            Task = new GetTaskDto
            {
                Id = record.TaskId,
                Name = record.Task.Name,
                Description = record.Task.Description
            },
            Student = new GetStudentDto
            {
                Id = record.StudentId,
                FirstName = record.Student.FirstName,
                LastName = record.Student.LastName,
                Email = record.Student.Email
            },
            ExecutionTime = record.ExecutionTime,
            Created = record.CreatedAt.ToString(format, CultureInfo.InvariantCulture),
        };
    }


}