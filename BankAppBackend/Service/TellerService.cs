using BankAppBackend.Exceptions;
using BankAppBackend.Models;
using BankAppBackend.Repositories.Interfaces;
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
        public void ChangeApplicantStatus(long applicantId, AccountStatus accountStatus, long tellerId)
        {
            Teller? teller = tellerRepository.GetTellerById(tellerId);
            if(teller == null)
            {
                throw new EntityNotFound($"Teller not found with id: {tellerId}");
            }
            applicantService.UpdateApplicantStatus(applicantId, accountStatus, teller);
        }

        public Teller? GetTellerById(long id)
        {
            Teller teller = this.tellerRepository.GetTellerById(id);
            if(teller == null)
            {
                throw new EntityNotFound($"Teller not found with teller id {id}");
            }
            return teller;
        }
    }
}
