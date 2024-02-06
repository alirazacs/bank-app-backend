﻿using BankAppBackend.Models;

namespace BankAppBackend.Service.Interfaces
{
    public interface ITellerService
    {
        public void ChangeApplicantStatus(long applicantId, AccountStatus accountStatus, long tellerId);
        public Teller GetTellerById(long id);
    }
}