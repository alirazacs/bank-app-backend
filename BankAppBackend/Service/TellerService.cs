using BankAppBackend.Models;

namespace BankAppBackend.Service
{
    public class TellerService : ITellerService
    {
        private IApplicantService applicantService;
        public TellerService(IApplicantService applicantService)
        {
            this.applicantService = applicantService;
        }
        public Applicant? ChangeApplicantStatus(long applicantId, AccountStatus accountStatus)
        {
            return applicantService.UpdateApplicantStatus(applicantId, accountStatus);
        }
    }
}
