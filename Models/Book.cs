
namespace poprawa_kol1.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Rating { get; set; }
    public int Author_Id { get; set; }
    public int Library_Id { get; set; }
    public int Category_Id { get; set; }

    public string CategoryName { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
}