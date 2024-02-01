using BankAppBackend.Models;

namespace BankAppBackend.Repositories
{
    public interface ICustomerRepository
    {
        public void CreateCustomer(Customer customer);
        public List<Customer> GetAllCustomers();
    }
}
