using BankAppBackend.Models;

namespace BankAppBackend.Repositories
{
    public interface ITellerRepository
    {
        public Teller? GetTellerById(long tellerId);
    }
}
