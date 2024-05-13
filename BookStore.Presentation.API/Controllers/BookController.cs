using BookStore.Repository.Interfaces;
using BookStore.Service.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookStoreService _bookStoreService;

        public BookController(IBookStoreService bookStoreService) {
            _bookStoreService = bookStoreService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks([FromQuery] string? author = null, [FromQuery] string? isbn = null, [FromQuery] string? status = null)
        {
            if (string.IsNullOrWhiteSpace(author) && string.IsNullOrWhiteSpace(isbn) && string.IsNullOrWhiteSpace(status))
            {
                return BadRequest("At least one search parameter must be provided.");
            }

            var books = await _bookStoreService.SearchBooksAsync(author, isbn, status);
            return Ok(books);
        }
    }
}
