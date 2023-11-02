using Basket.API.Model;
using Microsoft.AspNetCore.Http;
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

        public BasketController(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
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
                await _redisCache.SetStringAsync(basketDetail.UserId.ToString(), JsonConvert.SerializeObject(basketDetail));
                return Ok("Basket updated successfully.");
            }
            catch (Exception)
            {
                return BadRequest("Unable to update basket.");
                throw;
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
