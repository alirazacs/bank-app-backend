﻿using BankAppBackend.Models;
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
        //private ITellerService tellerService;
        public ApplicantService(IApplicantRepository applicantRepository, IRedisMessagePublisherService redisMessagePublisherService, ICustomerService customerService)
        {
            this.applicantRepository = applicantRepository;
            this.redisMessagePublisherService = redisMessagePublisherService;
            this.customerService = customerService;
            //this.tellerService = tellerService;
        }

        public Applicant AddApplicant(Applicant applicant)
        {
            //Teller teller = this.tellerService.GetTellerById(applicant.TellerId);
            if (applicantRepository.FindApplicantByCNIC(applicant.CNIC) != null)
            {
                throw new Exception($"Applicant already exist with CNIC number : {applicant.CNIC}");
            }
            applicant.AccountStatus = AccountStatus.PENDING;
            //applicant.Teller = teller;
            applicantRepository.AddApplicant(applicant);
            return applicant;
        }

        public List<Applicant> GetAllApplicantList()
        {
            return applicantRepository.GetApplicants().ToList();
        }

        public Applicant? GetApplicantById(long applicantId)
        {
            return applicantRepository.findApplicantById(applicantId);
        }

        public void UpdateApplicantStatus(long applicantId, AccountStatus accountStatus, Teller teller)
        {
            Applicant? applicant = GetApplicantById(applicantId);
            if (applicant == null)
            {
                throw new Exception($"Applicant with id {applicantId} not found");
            }

            if (customerService.FindCustomerByApplicantId(applicantId) != null)
            {
                throw new Exception($"Customer with applicant id {applicantId} already exist");
            }
            applicant.Teller = teller;
            applicant.AccountStatus = accountStatus;

            applicantRepository.UpdateApplicant(applicant);
            if (applicant.AccountStatus.Equals(AccountStatus.APPROVED))
            {
                customerService.CreateCustomerAndAccount(applicant);
            }

            //preparing model to send on queue for another MVC App.
            ApplicantMessagesModel applicantMessageModel = new ApplicantMessagesModel();
            applicantMessageModel.ApplicantId = (int)applicant.Id;
            applicantMessageModel.message = $"Dear Applicant {applicant.ApplicateName}, your status has been updated to {accountStatus}";
            redisMessagePublisherService.sendMessage(applicantMessageModel);
        }
    }
}