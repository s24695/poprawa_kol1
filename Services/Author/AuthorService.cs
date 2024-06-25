using poprawa_kol1.Repositories.Author;

namespace poprawa_kol1.Services.Author;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepo _authorRepo;

    public AuthorService(IAuthorRepo authorRepo)
    {
        _authorRepo = authorRepo;
    }

    public async Task<int> DeleteAuthorAsync(int idAuthor)
    {
        return await _authorRepo.DeleteAuthorAsync(idAuthor);
    }
}