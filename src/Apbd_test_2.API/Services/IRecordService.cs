using Apbd_test_2.API.DTO;

namespace Apbd_test_2.API.Services;

public interface IRecordService
{
    public Task<GetRecordsDto?> GetRecordByIdAsync(int id, CancellationToken cancellationToken);
    public Task<List<GetRecordsDto>> GetRecordsAsync(string? date, int? languageId, int? taskId, CancellationToken cancellationToken);
    public Task<GetRecordsDto> CreateRecordAsync(CreateRecordDto dto, CancellationToken cancellationToken);
}