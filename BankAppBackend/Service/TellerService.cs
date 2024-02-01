using BankAppBackend.Models;
using BankAppBackend.Repositories;
using BankAppBackend.Service.Interfaces;

namespace BankAppBackend.Service
{
    public class TellerService : ITellerService
    {
        private IApplicantService applicantService;
        private ITellerRepository tellerRepository;
        public TellerService(IApplicantService applicantService, ITellerRepository tellerRepository)
        {
            this.applicantService = applicantService;
            this.tellerRepository = tellerRepository;
        }
        public Applicant? ChangeApplicantStatus(long applicantId, AccountStatus accountStatus, long tellerId)
        {
            Teller? teller = tellerRepository.GetTellerById(tellerId);
            if(teller == null)
            {
                throw new Exception($"Teller not found with id: {tellerId}");
            }
            return applicantService.UpdateApplicantStatus(applicantId, accountStatus, teller);
        }

        public List<Teller> GetAllTellers()
        {
            return tellerRepository.GetAllTellers().ToList();
        }
    }
}
