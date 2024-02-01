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
            return _databaseContext.applicants.Find(applicantId);
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            return _databaseContext.applicants;
        }

        public void UpdateApplicant(Applicant applicant) {
            _databaseContext.applicants.Update(applicant);
            _databaseContext.SaveChanges();
        }

    }
}
