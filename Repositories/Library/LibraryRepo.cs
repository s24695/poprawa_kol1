using System.Data.SqlClient;
using poprawa_kol1.Models;

namespace poprawa_kol1.Repositories.Library;

public class LibraryRepo : ILibraryRepo
{
    private readonly IConfiguration _configuration;

    public LibraryRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Models.Library> GetLibraryByIdAsync(int idLibrary)
    {
        await using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await connection.OpenAsync();

        await using var command = new SqlCommand();
        command.Connection = connection;

        command.CommandText = "SELECT Name, Description, Location" +
                              "FROM Library " +
                              "WHERE Id = @idLibrary";
        command.Parameters.AddWithValue("@idLibrary", idLibrary);
        
        await using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        var library = new Models.Library()
        {
            Name = reader["Name"].ToString(),
            Description = reader["Description"].ToString(),
            Location = reader["Location"].ToString()
        };
        
        await reader.CloseAsync();
        command.Parameters.Clear();
        await connection.CloseAsync();

        return library;
    }

    public async Task<List<Book>> GetBooksByLibrary(int idLibrary)
    {
        var books = new List<Book>();
        
        await using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await connection.OpenAsync();

        await using var command = new SqlCommand();
        command.Connection = connection;
        
        command.CommandText = "SELECT b.Title, b.Description, b.PublicationDate, b.Rating, c.Name AS CategoryName, a.firstName AS FirstName, a.lastName AS LastName" +
                              "FROM Book b " +
                              "JOIN Category c ON b.Category_Id == c.Id" +
                              "JOIN Author a ON b.Author_Id == a.Id" +
                              "WHERE b.Library_Id == @idLibrary" +
                              "ORDER BY b.PublicationDate DESC";
        command.Parameters.AddWithValue("@idLibrary", idLibrary);
        
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var book = new Book()
            {
                Title = reader["Title"].ToString(),
                Description = reader["Description"].ToString(),
                PublicationDate = (DateTime)reader["PublicationDate"],
                Rating = (int)reader["Rating"],
                CategoryName = reader["CategoryName"].ToString(),
                AuthorFirstName = reader["FirstName"].ToString(),
                AuthorLastName = reader["LastName"].ToString(),
            };
            books.Add(book);
        }
        
        await reader.CloseAsync();
        command.Parameters.Clear();
        await connection.CloseAsync();

        return books;
    }
    
}