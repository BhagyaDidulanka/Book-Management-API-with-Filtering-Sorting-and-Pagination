using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shorting_filtering_pagination.Services;

namespace shorting_filtering_pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] string? search, [FromQuery] string? sortBy, [FromQuery] bool isDescending = false, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var books = await _bookService.GetBooksAsync(search, sortBy, isDescending, page, pageSize);
            return Ok(books);
        }
    }
}
