using Microsoft.AspNetCore.Mvc;
using Order.Service.Dtos;
using Order.Service.IService;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet, Route("{userId}")]
        public async Task<IActionResult> GetOrderDetails(int userId)
        {
            var order = await _orderService.GetOrderDetailsAsync(userId);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetails(AddOrderDetailsDto addOrderDetails)
        {
            var order = await _orderService.AddOrderDetailsAsync(addOrderDetails);
            return order > 0 ? Ok("Order Added Successfully.") : BadRequest("Unable to add order.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetails(UpdateOrderDetailsDto updateOrderDetails)
        {
            var order = await _orderService.UpdateOrderDetailsAsync(updateOrderDetails);
            return order > 0 ? Ok("Order updated successfully.") : BadRequest("Unable to update order.");
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteUpdateOrderDetails(int id)
        {
            var order = await _orderService.DeleteOrderDetailsAsync(id);
            return order > 0 ? Ok("Order deleted successfully.") : BadRequest("Unable to delete order.");
        }
    }
}
