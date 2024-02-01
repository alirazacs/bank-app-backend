using BankAppBackend.Models;

namespace BankAppBackend.Service.Interfaces
{
    public interface ITellerService
    {
        public Applicant? ChangeApplicantStatus(long applicantId, AccountStatus accountStatus, long tellerId);
        public List<Teller> GetAllTellers();
    }
}
