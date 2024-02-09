﻿using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;

namespace BankAppBackend.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TransactionRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public Transaction AddTransaction(Transaction transaction)
        {
            this._databaseContext.transactions.Add(transaction);
            this._databaseContext.SaveChanges();
            return transaction;
        }
        public Transaction? GetTransactionById(Guid id)
        {
            return _databaseContext.transactions.FirstOrDefault(transaction=>transaction.TransactionId.Equals(id));
        }

        public IEnumerable<Transaction> GetTransactions()
        {
          return this._databaseContext.transactions;
        }
    }
}
