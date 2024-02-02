using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;
using BankAppBackend.Service.Interfaces;

namespace BankAppBackend.Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public Account CreateNewAccount(Customer customer)
        {
            Account account = new Account();
            account.AccountType = customer.Applicant.AccountType;
            account.Balance = 0.00;
            account.CustomerId = customer.CustomerId;
            account.Customer = customer;
            accountRepository.CreateAccount(account);
            customer.Accounts.Add(account);
            return account;
        }
    }
}
