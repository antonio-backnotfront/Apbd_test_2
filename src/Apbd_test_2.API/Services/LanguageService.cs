using Apbd_test_2.API.DAL;
using Apbd_test_2.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace Apbd_test_2.API.Services;

public class LanguageService : ILanguageService
{
    RecordDbContext _context;

    public LanguageService(RecordDbContext context)
    {
        _context = context;
    }

    public async Task<GetLanguageDto?> GetLanguageByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Languages
            .Select(lang => new GetLanguageDto()
            {
                Id = lang.Id,
                Name = lang.Name,
            })
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    
}