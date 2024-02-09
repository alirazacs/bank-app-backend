using BankAppBackend.Exceptions;
using BankAppBackend.Models;
using BankAppBackend.Repositories;
using BankAppBackend.Repositories.Interfaces;
using BankAppBackend.Service.Interfaces;

namespace BankAppBackend.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;
        private IAccountService accountService;
        public CustomerService(ICustomerRepository customerRepository, IAccountService accountService)
        {
            this.customerRepository = customerRepository;
            this.accountService = accountService;
        }
        public Customer CreateCustomerAndAccount(Applicant applicant)
        {
            Customer existingCustomer = customerRepository.GetAllCustomers().FirstOrDefault(c => c.ApplicantId.Equals(applicant.Id)); ;
            if(existingCustomer != null)
            {
                throw new EntityAlreadyExist($"Customer already exist with id {existingCustomer.CustomerId}");
            }

            Customer customer = createNewCustomer(applicant);
            Account account = accountService.CreateNewAccount(customer);
            UpdateExistingCustomer(customer);
            return customer;
        }

        private Customer createNewCustomer(Applicant applicant)
        {
            Customer newCustomer = new Customer();
            // TODO : below line is redundant, should be removed.
            //newCustomer.ApplicantId = applicant.Id;
            newCustomer.Applicant = applicant;
            newCustomer.UserName = "";
            newCustomer.Password = "";
            newCustomer.Accounts = new List<Account>(); 
            customerRepository.CreateCustomer(newCustomer);
            return newCustomer;
        }

        public Customer UpdateExistingCustomer(Customer customer)
        {
            Customer existingCustomer = customerRepository.GetAllCustomers().FirstOrDefault(c => c.CustomerId.Equals(customer.CustomerId));
            if(existingCustomer == null)
            {
                throw new EntityNotFound($"Customer with id {customer.CustomerId} does not exist");
            }
            customer.ApplicantId = existingCustomer.ApplicantId;
            customerRepository.UpdateCustomer(customer);
            return existingCustomer;
        }

        public Customer? FindCustomerByApplicantId(long applicantId)
        {
            List<Customer> customers = customerRepository.GetAllCustomers();
            return customers.Find(customer => customer.ApplicantId.Equals(applicantId));
        }
        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }
    }
}
