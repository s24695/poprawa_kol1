namespace poprawa_kol1.Repositories.Author;

public interface IAuthorRepo
{
    Task<int> DeleteAuthorAsync(int idAuthor);
}