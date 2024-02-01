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
        public Customer CreateCustomer(Applicant applicant)
        {
            Customer customer = customerRepository.GetAllCustomers().FirstOrDefault(c => c.ApplicantId.Equals(applicant.Id)); ;
            if(customer!=null)
            {
                throw new Exception($"Customer already exist with id {customer.CustomerId}");
            }
            Customer newCustomer = new Customer();
            newCustomer.ApplicantId = applicant.Id;
            newCustomer.Applicant = applicant;
            newCustomer.UserName = "";
            newCustomer.Password = "";

            customerRepository.CreateCustomer(newCustomer);
            return newCustomer;
        }

        public Customer CreateNewCustomerAndAccount(Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}
