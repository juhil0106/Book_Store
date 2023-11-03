using AutoMapper;
using Basket.API.Grpc_Service;
using Basket.API.Model;
using EventBus.Messages.Event;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IDistributedCache _redisCache;
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public BasketController(IDistributedCache redisCache, DiscountGrpcService discountGrpcService, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _redisCache = redisCache;
            _discountGrpcService = discountGrpcService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet, Route("{userId}")]
        public async Task<ActionResult> GetBasket(int userId)
        {
            var basket = await _redisCache.GetStringAsync(userId.ToString());
            if (basket == null)
                return Ok(new BasketDetail(userId));
            return Ok(JsonConvert.DeserializeObject<BasketDetail>(basket));
        }

        [HttpPost, Route("[action]")]
        public async Task<ActionResult> UpdateBasket(BasketDetail basketDetail)
        {
            try
            {
                foreach (var item in basketDetail.Items)
                {
                    var coupon = await _discountGrpcService.GetDiscount(item.BookId);
                    item.Price -= coupon.Discount;
                }
                await _redisCache.SetStringAsync(basketDetail.UserId.ToString(), JsonConvert.SerializeObject(basketDetail));
                return Ok("Basket updated successfully.");
            }
            catch (Exception)
            {
                return BadRequest("Unable to update basket.");
                throw;
            }
        }

        [HttpPost, Route("[action]")]
        public async Task<ActionResult> CheckoutOrder(CheckoutOrder order)
        {
            try
            {
                var basket = await _redisCache.GetStringAsync(order.UserId.ToString());
                if (string.IsNullOrEmpty(basket))
                    return BadRequest("Don't have any rpoduct for checkout.");

                var basketModel = JsonConvert.DeserializeObject<BasketDetail>(basket);
                var eventMesage = _mapper.Map<BasketCheckoutEvent>(order);
                eventMesage.TotalPrice = basketModel.TotalPrice;
                eventMesage.Items = _mapper.Map<List<CheckoutOrderItem>>(basketModel.Items);
                await _publishEndpoint.Publish(eventMesage);

                await _redisCache.RemoveAsync(order.UserId.ToString());
                return Ok("order placed successfully.");
            }
            catch (Exception)
            {
                return BadRequest("Unable to place order.");
            }
        }

        [HttpDelete, Route("{userId}")]
        public async Task<ActionResult> DeleteBasket(int userId)
        {
            try 
            {
                await _redisCache.RemoveAsync(userId.ToString());
                return Ok("Basket deleted successfully.");
            }
            catch (Exception)
            {
                return BadRequest("Unable to delete basket.");
            }
        }
    }
}
