using Apbd_test_2.API.DAL;
using Apbd_test_2.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace Apbd_test_2.API.Services;

public class TaskService : ITaskService
{
    RecordDbContext _context;

    public TaskService(RecordDbContext context)
    {
        _context = context;
    }

    public async Task<GetTaskDto?> GetStudentByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .Select(stud => new GetTaskDto()
            {
                Id = stud.Id,
                Name = stud.Name,
                Description = stud.Description,
            })
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    
}