using Apbd_test_2.API.DTO;

namespace Apbd_test_2.API.Services;

public interface IStudentService
{
    public Task<GetStudentDto?> GetStudentByIdAsync(int id, CancellationToken cancellationToken);
}