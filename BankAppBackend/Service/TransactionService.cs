using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;
using BankAppBackend.Service.Interfaces;

namespace BankAppBackend.Service
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountService _accountService;

        public TransactionService(ITransactionRepository transactionRepository,IAccountService accountService) {
            this._transactionRepository = transactionRepository;
            this._accountService = accountService;
        }
        public Transaction AddTransaction(Transaction transaction)
        {
            Account account = this._accountService.GetAccountById(transaction.AccountId);
            transaction.Account = account;
            transaction.TransactionId = Guid.NewGuid();
            transaction.Amount = ValidateAmountAndReturn(transaction);
            return this._transactionRepository.AddTransaction(transaction);
        }

        public Transaction? GetTransactionById(long id)
        {
           return this._transactionRepository.GetTransactionById(id);
        }

        public double ValidateAmountAndReturn(Transaction txn)
        {
            if (txn.TransactionType == TransactionType.CREDIT)
            {
                if (txn.Amount > 0)
                {
                    txn.Account.Balance = txn.Account.Balance + txn.Amount;
                }
                else
                {
                    throw new InvalidOperationException("Invalid Operation.");
                }

            }
            else if(txn.TransactionType == TransactionType.DEBIT)
            {
                if (txn.Account.Balance >= txn.Amount)
                {

                    txn.Account.Balance = txn.Account.Balance - txn.Amount;
                }
                else
                {
                    throw new InvalidOperationException("Insufficient account balance");
                }

            }
            return txn.Amount;

        }

        public IEnumerable<Transaction> GetTransactions()
        {
           return this._transactionRepository.GetTransactions();
            
        }
    }
}
