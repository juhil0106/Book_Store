using Discount.API.Model;
using Discount.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookDiscount(string bookId)
        {
            var bookDiscount = await _discountRepository.GetBookDiscount(bookId);
            return Ok(bookDiscount);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookDiscount(BookDiscount bookDiscount)
        {
            var discount = await _discountRepository.AddBookDiscount(bookDiscount);
            return discount is true ? Ok("Book discount added successfully.") : BadRequest("Unable to add book discount.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookDiscount(BookDiscount bookDiscount)
        {
            var discount = await _discountRepository.UpdateBookDiscount(bookDiscount);
            return discount is true ? Ok("Book discount updated successfully.") : BadRequest("Unable to update book discount.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookDiscount(string bookId)
        {
            var discount = await _discountRepository.DeleteBookDiscount(bookId);
            return discount is true ? Ok("Book discount deleted successfully.") : BadRequest("Unable to delete book discount.");
        }
    }
}
