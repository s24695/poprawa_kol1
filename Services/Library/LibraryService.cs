using poprawa_kol1.Models;
using poprawa_kol1.Repositories.Library;

namespace poprawa_kol1.Services.Library;

public class LibraryService : ILibraryService
{
    private readonly ILibraryRepo _libraryRepo;

    public LibraryService(ILibraryRepo libraryRepo)
    {
        _libraryRepo = libraryRepo;
    }

    public async Task<Models.Library> GetLibraryByIdAsync(int idLibrary)
    {
        return await _libraryRepo.GetLibraryByIdAsync(idLibrary);
    }

    public async Task<List<Book>> GetBooksByLibrary(int idLibrary)
    {
        return await _libraryRepo.GetBooksByLibrary(idLibrary);
    }
}