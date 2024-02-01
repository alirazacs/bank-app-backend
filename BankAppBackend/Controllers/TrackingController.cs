using BankAppBackend.Service.Interfaces;
using BankTrackingSystem.Models;
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
        public async Task SendMessage([FromBody] ApplicantMessagesModel message)
        {
            await RedisMessagePublisherService.sendMessage(message);
        }

    }
}
