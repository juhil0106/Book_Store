using Book.API.Model;
using Book.API.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookDetails()
        {
            var books = await _bookRepository.GetBookDetails();
            return Ok(books);
        }

        [HttpGet, Route("ById/{id}")]
        public async Task<ActionResult> GetBookDetailById(string id)
        {
            var book = await _bookRepository.GetBookDetailById(id);
            return book != null ? Ok(book) : BadRequest("Book not found.");
        }

        [HttpGet, Route("ByGenreId/{id}")]
        public async Task<IActionResult> GetBookDetailByGenreId(string id)
        {
            var books = await _bookRepository.GetBookDetailsByGenreId(id);
            return Ok(books);
        }

        [HttpGet, Route("[action]")]
        public async Task<IActionResult> GetAuthorsName()
        {
            var authorsName = await _bookRepository.GetAuthorsName();
            return Ok(authorsName);
        }

        [HttpGet, Route("{authorName}")]
        public async Task<IActionResult> GetBookDetailByAuthor(string authorName)
        {
            var books = await _bookRepository.GetBookDetailsByAuthor(authorName);
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(BookDetail book)
        {
            var flag = await _bookRepository.AddBook(book);
            return flag ? Ok("Book added successfully.") : BadRequest("Unable to add book.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(BookDetail book)
        {
            var flag = await _bookRepository.UpdateBook(book);
            return flag ? Ok("Book updated successfully.") : BadRequest("Unable to update book.");
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> DeleteBook(string id)
        {
            var flag = await _bookRepository.DeleteBook(id);
            return flag ? Ok("Book deleted successfully.") : BadRequest("Unable to delete book.");
        }
    }
}
