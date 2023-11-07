using Book.API.Model;
using Book.API.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImageController : ControllerBase
    {
        private readonly IBookImageRepository _bookImageRepository;

        public BookImageController(IBookImageRepository bookImageRepository)
        {
            _bookImageRepository = bookImageRepository;
        }

        [HttpGet, Route("{bookId}")]
        public async Task<IActionResult> GetBookImagesByBook(string bookId)
        {
            var bookImages = await _bookImageRepository.GetBookImagesByBook(bookId);
            return Ok(bookImages);
        }

        [HttpPost]
        public async Task<ActionResult> AddBookmage(BookImage bookImage)
        {
            var flag = await _bookImageRepository.AddBookImage(bookImage);
            return flag ? Ok("Book image added successfully.") : BadRequest("Unable to add book image.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBookImage(BookImage bookImage)
        {
            var flag = await _bookImageRepository.UpdateBookImage(bookImage);
            return flag ? Ok("Book image updated successfully.") : BadRequest("Unable to update book image.");
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> DeleteBookImage(string id)
        {
            var flag = await _bookImageRepository.DeleteBookImage(id);
            return flag ? Ok("Book image deleted successfully.") : BadRequest("Unable to delete book image.");
        }
    }
}
