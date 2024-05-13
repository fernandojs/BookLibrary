using BookStore.Presentation.API.Models;
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

        [HttpPost("addbook")]
        public IActionResult AddBook([FromBody] BookModel book)
        {
            if (book == null || string.IsNullOrWhiteSpace(book.Title))
            {
                return BadRequest("Invalid book data.");
            }

            try
            {
                _bookStoreService.AddBookAsync(book.Title, book.Author, book.Status);
                return Ok($"Book '{book.Title}' added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed
                return StatusCode(500, "An error occurred while adding the book.");
            }
        }
    }
}
