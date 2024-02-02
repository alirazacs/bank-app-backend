using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;
using BankAppBackend.Service.Interfaces;

namespace BankAppBackend.Service
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository) {
            this._transactionRepository = transactionRepository;
        }
        public Transaction AddTransaction(Transaction transaction)
        {
           return this._transactionRepository.AddTransaction(transaction);
        }

        public Transaction? GetTransactionById(Guid id)
        {
           return this._transactionRepository.GetTransactionById(id);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
           return this._transactionRepository.GetTransactions();
            
        }
    }
}
