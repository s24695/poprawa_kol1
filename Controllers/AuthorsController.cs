using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using poprawa_kol1.Models;
using poprawa_kol1.Services.Author;

namespace poprawa_kol1.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpDelete("{idAuthor}")]
    public async Task<IActionResult> DeleteAuthor(int idAuthor)
    {
        try
        {
            var result = await _authorService.DeleteAuthorAsync(idAuthor);

            return StatusCode(StatusCodes.Status204NoContent, result);
        }
        catch
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }


    }
}