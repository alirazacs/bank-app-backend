using BankAppBackend.Models;

namespace BankAppBackend.Repositories.Interfaces
{
    public interface IApplicantRepository
    {
        public void AddApplicant(Applicant applicant);
        public IEnumerable<Applicant> GetApplicants();
        public Applicant? findApplicantById(long applicantId);
        public void UpdateApplicant(Applicant applicant);

    }
}
