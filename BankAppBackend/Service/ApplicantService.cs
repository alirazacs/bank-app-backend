using BankAppBackend.Models;
using BankAppBackend.Repositories;
using BankAppBackend.Repositories.Interfaces;
using BankAppBackend.Service.Interfaces;
using BankTrackingSystem.Models;

namespace BankAppBackend.Service
{
    public class ApplicantService : IApplicantService
    {
        private IApplicantRepository applicantRepository;
        private IRedisMessagePublisherService redisMessagePublisherService;
        private ICustomerService customerService;
        public ApplicantService(IApplicantRepository applicantRepository,IRedisMessagePublisherService redisMessagePublisherService, ICustomerService customerService)
        {
            this.applicantRepository = applicantRepository;
            this.redisMessagePublisherService = redisMessagePublisherService;
            this.customerService = customerService;
        }

        public void AddApplicant(Applicant applicant)
        {
            applicantRepository.AddApplicant(applicant);
        }

        public List<Applicant> GetAllApplicantList()
        {
            return applicantRepository.GetApplicants().ToList();
        }

        public Applicant? GetApplicantById(long applicantId)
        {
            return applicantRepository.findApplicantById(applicantId);
        }

        public void UpdateApplicant(Applicant applicant)
        {

            throw new NotImplementedException();
        }

        public Applicant? UpdateApplicantStatus(long applicantId, AccountStatus accountStatus, Teller teller) {
            Applicant? applicant = GetApplicantById(applicantId);
            if (applicant == null)
            {
                throw new Exception($"Applicant with id {applicantId} not found");
            }

            applicant.TellerId = teller.Id;
            applicant.Teller = teller;
            applicant.accountStatus = accountStatus;

            applicantRepository.UpdateApplicant(applicant);
            if(applicant.accountStatus.Equals(AccountStatus.APPROVED))
            {
                customerService.CreateCustomer(applicant);
            }

            ApplicantMessagesModel applicantMessageModel = new ApplicantMessagesModel();
            applicantMessageModel.ApplicantId = (int) applicant.Id;
            applicantMessageModel.message = $"Dear Applicant {applicant.name}, your status has been updated to {accountStatus}";
            redisMessagePublisherService.sendMessage(applicantMessageModel);
            return applicant;
        }
    }
}
