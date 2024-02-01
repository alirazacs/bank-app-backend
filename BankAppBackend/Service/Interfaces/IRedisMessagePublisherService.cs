using StackExchange.Redis;

namespace BankAppBackend.Service.Interfaces
{
    public interface IRedisMessagePublisherService
    {
        public Task sendMessage(string message);
    }
}
