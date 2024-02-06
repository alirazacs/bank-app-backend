﻿using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;

namespace BankAppBackend.Repositories
{
    public class TellerRepository : ITellerRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TellerRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public Teller? GetTellerById(long tellerId)
        {
            return _databaseContext.Tellers.Find(tellerId);
        }

        public IEnumerable<Teller> GetAllTellers() {
            return _databaseContext.Tellers;
        }

    }
}