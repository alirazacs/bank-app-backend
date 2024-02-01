using BankAppBackend.Models;

namespace BankAppBackend.Service.Interfaces
{
    public interface ICustomerService
    {
        public Customer CreateCustomer(Applicant applicant);
    }
}
