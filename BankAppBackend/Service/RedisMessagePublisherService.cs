using BankAppBackend.Models;
using StackExchange.Redis;

namespace BankAppBackend.Service
{
    public class RedisMessagePublisherService : IRedisMessagePublisherService
    {
        private readonly ILogger<RedisMessagePublisherService> _logger;
        private readonly IConfiguration Configuration;
        private static readonly RedisChannel Channel = RedisChannel.Pattern("bank-account-status-changed-channel");

        public RedisMessagePublisherService(IConfiguration configuration, ILogger<RedisMessagePublisherService> logger)
        {
            _logger = logger;
            Configuration = configuration;
        }

        private IConnectionMultiplexer EstablishRedisConnection()
        {
            // Reads the `ConnectionStrings` section from appsettings.json and stores it in an instance of `ConnectionStringsOptions`
            // Had to do this because otherwise a warning is emitted always saying `RedisConnectionString` may be null
            // Read more at https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-8.0
            ConnectionStringsOptions connectionStringsOptions = new ConnectionStringsOptions();
            Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings).Bind(connectionStringsOptions);

            return ConnectionMultiplexer.Connect(connectionStringsOptions.RedisConnectionString);
        }

        public async Task sendMessage(string message)
        {
            IConnectionMultiplexer connectionMultiplexer = EstablishRedisConnection();
            ISubscriber subscriber = connectionMultiplexer.GetSubscriber();

            try
            {
                _logger.LogInformation("{time} -- Message Published: {message}", DateTimeOffset.Now, message);
                await subscriber.PublishAsync(Channel, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing message to Redis");
            }
        }
    }
}
