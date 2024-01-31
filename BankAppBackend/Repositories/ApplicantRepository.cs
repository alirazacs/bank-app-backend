using BankAppBackend.Models;

namespace BankAppBackend.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private DatabaseContext _databaseContext;
        public ApplicantRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void AddApplicant(Applicant applicant)
        {
            _databaseContext.applicants.Add(applicant);
            _databaseContext.SaveChanges();
        }

        public Applicant? findApplicantById(long applicantId)
        {
            List<Applicant> allApplicants = GetApplicants().ToList();
            return allApplicants.Find(applicants=>applicants.Id.Equals(applicantId));
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            return _databaseContext.applicants;
        }

        public void UpdateApplicant(Applicant applicant) {
            _databaseContext.applicants.Update(applicant);
        }

    }
}
