using BankAppBackend.Models;

namespace BankAppBackend.Service.Interfaces
{
    public interface ITransactionService
    {
        public Transaction AddTransaction(TransactionExtended transaction);
        public IEnumerable<Transaction> GetTransactions();  // its performance will degrade with more data; why we need this
        public IEnumerable<Transaction> GetTransactionsByAccountId(Guid accountId);

        public Transaction? GetTransactionById(Guid id);
    }
}
