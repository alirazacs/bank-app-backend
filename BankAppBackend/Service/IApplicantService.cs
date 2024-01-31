using BankAppBackend.Models;

namespace BankAppBackend.Service
{
    public interface IApplicantService
    {
        public void AddApplicant(Applicant applicant);
        public List<Applicant> GetAllApplicantList();
        public Applicant? GetApplicantById(long applicantId);
        public void UpdateApplicant(Applicant applicant);
        public Applicant? UpdateApplicantStatus(long applicantId, AccountStatus accountStatus);
    }
}
