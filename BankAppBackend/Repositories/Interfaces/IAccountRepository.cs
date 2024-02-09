using BankAppBackend.Models;

namespace BankAppBackend.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Account CreateAccount(Account account);
        public Account? GetAccountById(Guid id);

    }
}
