using BankAppBackend.Models;

namespace BankAppBackend.Service.Interfaces
{
    public interface ICustomerService
    {
        public Customer CreateCustomerAndAccount(Applicant applicant);
    }
}
