using Microsoft.AspNetCore.Mvc;
using poprawa_kol1.Models;
using poprawa_kol1.Services.Library;

namespace poprawa_kol1.Controllers;

[Route("api/libraries")]
[ApiController]
public class LibrariesController : ControllerBase
{
    private readonly ILibraryService _libraryService;

    public LibrariesController(ILibraryService libraryService)
    {
        _libraryService = libraryService;
    }

    [HttpGet("{idLibrary}")]
    public async Task<ActionResult<Library>> GetLibraryById(int idLibrary)
    {
        var library = await _libraryService.GetLibraryByIdAsync(idLibrary);
        if (library == null)
        {
            return NotFound("Counldn't find library");
        }

        var books = await _libraryService.GetBooksByLibrary(idLibrary);
        library.Books = books;

        return Ok(library);
    }
}