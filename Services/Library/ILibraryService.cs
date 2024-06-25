using poprawa_kol1.Models;

namespace poprawa_kol1.Services.Library;

public interface ILibraryService
{
    Task<Models.Library> GetLibraryByIdAsync(int idLibrary);
    Task<List<Book>> GetBooksByLibrary(int idLibrary);
}