using BankAppBackend.Models;

namespace BankAppBackend.Service.Interfaces
{
    public interface IApplicantService
    {
        public void AddApplicant(Applicant applicant);
        public List<Applicant> GetAllApplicantList();
        public Applicant? GetApplicantById(long applicantId);
        public Applicant? UpdateApplicantStatus(long applicantId, AccountStatus accountStatus, Teller teller);
    }
}
