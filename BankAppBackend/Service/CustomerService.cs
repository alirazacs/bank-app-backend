using BankAppBackend.Models;
using BankAppBackend.Repositories;
using BankAppBackend.Repositories.Interfaces;
using BankAppBackend.Service.Interfaces;

namespace BankAppBackend.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Customer CreateCustomerAndAccount(Applicant applicant)
        {
            Customer existingCustomer = customerRepository.GetAllCustomers().FirstOrDefault(c => c.ApplicantId.Equals(applicant.Id)); ;
            if(existingCustomer != null)
            {
                throw new Exception($"Customer already exist with id {existingCustomer.CustomerId}");
            }

            Customer customer = createNewCustomer(applicant);
            return createNewAccount(customer);
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

        private Customer createNewAccount(Customer customer)
        {
            Account account = new Account();
            account.AccountType = customer.Applicant.AccountType;
            account.Balance = 0.00;
            account.CustomerId = customer.CustomerId;
            account.Customer = customer;
            customerRepository.CreateAccount(account);
            customer.Accounts.Add(account);
            customerRepository.UpdateCustomer(customer);
            return customer;
        }

        public Customer CreateNewCustomerAndAccount(Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}
