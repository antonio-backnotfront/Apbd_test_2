using Apbd_test_2.API.DTO;

namespace Apbd_test_2.API.Services;

public interface ITaskService
{
    public Task<GetTaskDto?> GetStudentByIdAsync(int id, CancellationToken cancellationToken);
}