using BankAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAppBackend.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CustomerRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }
        public void CreateCustomer(Customer customer)
        {
            _databaseContext.Customers.Add(customer);
            _databaseContext.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _databaseContext.Customers.Include(customer=>customer.Applicant).ToList();
        }
    }
}
