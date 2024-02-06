using BankAppBackend.Models;

namespace BankAppBackend.Service.Interfaces
{
    public interface ITransactionService
    {
        public Transaction AddTransaction(TransactionExtended transaction);
        public IEnumerable<Transaction> GetTransactions();

        public Transaction? GetTransactionById(long id);
    }
}
