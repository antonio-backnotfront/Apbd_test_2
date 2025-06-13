using Apbd_test_2.API.DTO;

namespace Apbd_test_2.API.Services;

public interface ILanguageService
{
    public Task<GetLanguageDto?> GetLanguageByIdAsync(int id, CancellationToken cancellationToken);
}