using BankAppBackend.Models;

namespace BankAppBackend.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public void CreateCustomer(Customer customer);
        public List<Customer> GetAllCustomers();
    }
}
