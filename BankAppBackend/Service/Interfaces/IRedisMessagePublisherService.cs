using BankTrackingSystem.Models;
using StackExchange.Redis;

namespace BankAppBackend.Service.Interfaces
{
    public interface IRedisMessagePublisherService
    {
        public Task SendMessage(ApplicantMessagesModel applicantMessagesModel);
    }
}
