using Apbd_test_2.API.DAL;
using Apbd_test_2.API.DTO;
using Apbd_test_2.API.Models;
using Microsoft.EntityFrameworkCore;

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
            Created = record.CreateAt,
        };
    }


    public async Task<List<GetRecordsDto>> GetRecordsAsync(CancellationToken cancellationToken)
    {
        return await _context.Records
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
                Created = rec.CreateAt,
            }).ToListAsync(cancellationToken);
    }
    
    public async Task<GetRecordsDto> CreateRecordAsync(CreateRecordDto dto, CancellationToken cancellationToken)
    {
        var record = new Record
        {
            LanguageId = dto.LanguageId,
            TaskId = dto.TaskId,
            StudentId = dto.StudentId,
            ExecutionTime = dto.ExecutionTime,
            CreateAt = dto.Created
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
            Created = record.CreateAt
        };
    }


}