using StackExchange.Redis;

namespace BankAppBackend.Service
{
    public interface IRedisMessagePublisherService
    {
        public Task sendMessage(string message);
    }
}
