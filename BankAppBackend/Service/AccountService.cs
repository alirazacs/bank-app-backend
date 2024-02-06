using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;
using BankAppBackend.Service.Interfaces;

namespace BankAppBackend.Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }
        public Account CreateNewAccount(Customer customer)
        {
            Account account = new Account();
            account.AccountId = Guid.NewGuid();
            account.AccountType = customer.Applicant.AccountType;
            account.Customer = customer;
            account = _accountRepository.CreateAccount(account);
            return account;
        }

        public Account GetAccountById(Guid id)
        {
            Account account = _accountRepository.GetAccountById(id);
            if(account == null) {
                throw new Exception($"Account does not exist with account id : {id}");
            }
            return account;
        }
    }
}
