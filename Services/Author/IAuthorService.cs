namespace poprawa_kol1.Services.Author;

public interface IAuthorService
{
    Task<int> DeleteAuthorAsync(int idAuthor);
}