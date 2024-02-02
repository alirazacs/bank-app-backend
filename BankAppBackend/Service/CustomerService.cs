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
                throw new Exception($"Customer already exist with id {existingCustomer.CustomerId}");
            }

            Customer customer = createNewCustomer(applicant);
            Account account = accountService.CreateNewAccount(customer);
            UpdateExistingCustomer(customer);
            return customer;
        }

        private Customer createNewCustomer(Applicant applicant)
        {
            Customer newCustomer = new Customer();
            newCustomer.ApplicantId = applicant.Id;
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
                throw new Exception($"Customer with id {customer.CustomerId} does not exist");
            }
            customerRepository.UpdateCustomer(customer);
            return existingCustomer;
        }
    }
}
