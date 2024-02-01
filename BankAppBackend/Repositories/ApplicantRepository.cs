using BankAppBackend.Models;
using Microsoft.EntityFrameworkCore;

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
            _databaseContext.Applicants.Add(applicant);
            _databaseContext.SaveChanges();
        }

        public Applicant? findApplicantById(long applicantId)
        {
            List<Applicant> applicantsList = GetApplicants().ToList();
            return applicantsList.Find(applicant=>applicant.Id.Equals(applicantId));
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            return _databaseContext.Applicants.Include(a => a.Teller).Include(a=>a.customer);
        }

        public void UpdateApplicant(Applicant applicant) {
            _databaseContext.Applicants.Update(applicant);
            _databaseContext.SaveChanges();
        }

    }
}
