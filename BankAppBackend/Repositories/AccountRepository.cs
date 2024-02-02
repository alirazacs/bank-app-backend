using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;

namespace BankAppBackend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext databaseContext;  
        public AccountRepository(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public void CreateAccount(Account account)
        {
            databaseContext.Accounts.Add(account);
            databaseContext.SaveChanges();
        }
    }
}
