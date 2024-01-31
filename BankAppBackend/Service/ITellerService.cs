using BankAppBackend.Models;

namespace BankAppBackend.Service
{
    public interface ITellerService
    {
        public Applicant? ChangeApplicantStatus(long applicantId, AccountStatus accountStatus);
    }
}
