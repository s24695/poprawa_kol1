using System.Data.SqlClient;

namespace poprawa_kol1.Repositories.Author;

public class AuthorRepo : IAuthorRepo
{
    private readonly IConfiguration _configuration;

    public AuthorRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<int> DeleteAuthorAsync(int idAuthor)
    {
        await using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await connection.OpenAsync();

        using var transaction = connection.BeginTransaction();

        try
        {
            var deleteBooksCommand = new SqlCommand()
            {
                Connection = connection,
                Transaction = transaction,
                CommandText = "DELETE FROM Books WHERE Author_Id == @idAuthor"
            };
            deleteBooksCommand.Parameters.AddWithValue("@idAuthor", idAuthor);
            await deleteBooksCommand.ExecuteNonQueryAsync();

            var deleteAuthorCommand = new SqlCommand()
            {
                Connection = connection,
                Transaction = transaction,
                CommandText = "DELETE FROM Author WHERE Id = @idAuthor"
            };
            deleteAuthorCommand.Parameters.AddWithValue("@idAuthor", idAuthor);
            var rowsAffected = await deleteAuthorCommand.ExecuteNonQueryAsync();

            transaction.Commit();
            
            deleteAuthorCommand.Parameters.Clear();
            deleteBooksCommand.Parameters.Clear();

            return rowsAffected;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}