using Apbd_test_2.API.DAL;
using Apbd_test_2.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace Apbd_test_2.API.Services;

public class StudentService : IStudentService
{
    RecordDbContext _context;

    public StudentService(RecordDbContext context)
    {
        _context = context;
    }

    public async Task<GetStudentDto?> GetStudentByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Students
            .Select(stud => new GetStudentDto()
            {
                Id = stud.Id,
                FirstName = stud.FirstName,
                LastName = stud.LastName,
                Email = stud.Email,
            })
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    
}