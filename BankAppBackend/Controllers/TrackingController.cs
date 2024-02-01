using BankAppBackend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly IRedisMessagePublisherService RedisMessagePublisherService;

        public TrackingController(IRedisMessagePublisherService redisMessagePublisherService)
        {
            RedisMessagePublisherService = redisMessagePublisherService;
        }

        [HttpPost]
        public async Task SendMessage([FromBody] string message)
        {
            await RedisMessagePublisherService.sendMessage(message);
        }

    }
}
