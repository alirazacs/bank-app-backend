using BankAppBackend.Models;

namespace BankAppBackend.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        public Transaction AddTransaction(Transaction transaction);
        public IEnumerable<Transaction> GetTransactions();
        public Transaction? GetTransactionById(Guid id);
    }
}
