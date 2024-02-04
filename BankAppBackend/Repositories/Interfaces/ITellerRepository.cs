using BankAppBackend.Models;

namespace BankAppBackend.Repositories.Interfaces
{
    public interface ITellerRepository
    {
        public Teller? GetTellerById(long tellerId);
    }
}
