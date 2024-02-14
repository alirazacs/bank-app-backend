using BankAppBackend.Service.Interfaces;
using BankTrackingSystem.Models;
using StackExchange.Redis;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace BankAppBackend.Service
{
    public class RedisMessagePublisherService : IRedisMessagePublisherService
    {
        private static readonly RedisChannel Channel = RedisChannel.Pattern("bank-account-status-changed-channel");

        private readonly ILogger<RedisMessagePublisherService> _logger;
        private readonly ConnectionStringsOptions _options;

        public RedisMessagePublisherService(ILogger<RedisMessagePublisherService> logger,
            IOptions<ConnectionStringsOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        private IConnectionMultiplexer EstablishRedisConnection()
        {
            return ConnectionMultiplexer.Connect(_options.RedisConnectionString);
        }

        public async Task SendMessage(ApplicantMessagesModel applicantMessagesModel)
        {
            IConnectionMultiplexer connectionMultiplexer = EstablishRedisConnection();
            ISubscriber subscriber = connectionMultiplexer.GetSubscriber();

            try
            {
                _logger.LogInformation("{time} -- Message Published: {message}", DateTimeOffset.Now, applicantMessagesModel);
                await subscriber.PublishAsync(Channel,JsonConvert.SerializeObject(applicantMessagesModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing message to Redis");
            }
        }
    }
}
