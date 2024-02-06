using BankAppBackend.Service;
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

        /// <summary>
        /// Sends a message to the "bank-account-status-changed-channel" channel on Redis. (Built for interactive testing purposes)
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        [HttpPost]
        public async Task SendMessage([FromBody] string message)
        {
            await RedisMessagePublisherService.sendMessage(message);
        }

    }
}
