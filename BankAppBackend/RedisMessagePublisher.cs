using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Runtime.CompilerServices;

namespace BankAppBackend
{
    public class RedisMessagePublisher : BackgroundService
    {
        private readonly ILogger<RedisMessagePublisher> _logger;
        private readonly IConfiguration _configuration;
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private const string _channel = "test-channel";

        public RedisMessagePublisher(IConfiguration configuration, ILogger<RedisMessagePublisher> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379,password=redispw");
            //_connectionMultiplexer = ConnectionMultiplexer.Connect(_configuration[key: "ConnectionStrings:RedisConnectionString"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriber = _connectionMultiplexer.GetSubscriber();
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Producer running at: {time}", DateTimeOffset.Now);
                    await subscriber.PublishAsync(_channel, "Hello from the Publisher");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error publishing message to Redis");
                }

                await Task.Delay(5000, stoppingToken);
            }
        }

    }
}
