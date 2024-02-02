using BankAppBackend.Models;

namespace BankAppBackend.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public void CreateAccount(Account account);
    }
}
