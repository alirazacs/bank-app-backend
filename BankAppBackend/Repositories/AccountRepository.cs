using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;

namespace BankAppBackend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _databaseContext;  
        public AccountRepository(DatabaseContext databaseContext) {
            this._databaseContext = databaseContext;
        }

        public Account CreateAccount(Account account)
        {
            _databaseContext.Accounts.Add(account);
            _databaseContext.SaveChanges();
            return account;
        }

        public Account? GetAccountById(Guid id)
        {
            return this._databaseContext.Accounts.FirstOrDefault(account => account.AccountId.Equals(id));
        }
    }
}
