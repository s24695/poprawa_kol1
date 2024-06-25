using poprawa_kol1.Models;

namespace poprawa_kol1.Repositories.Library;

public interface ILibraryRepo
{
    Task<Models.Library> GetLibraryByIdAsync(int idLibrary);
    Task<List<Book>> GetBooksByLibrary(int idLibrary);
}