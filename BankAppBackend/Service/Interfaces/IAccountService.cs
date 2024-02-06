using BankAppBackend.Models;

namespace BankAppBackend.Service.Interfaces
{
    public interface IAccountService
    {
        public Account CreateNewAccount(Customer customer);

        public Account GetAccountById(long id);

    }
}
