using BankAppBackend.Exceptions;
using BankAppBackend.Models;
using BankAppBackend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAppBackend.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPut("updateCustomer")]
        public ActionResult<Customer> UpdateCustomer(Customer customer)
        {
            try
            {
                return Ok(customerService.UpdateExistingCustomer(customer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            // Logic to fetch data and return a response

        }

        [HttpGet("allCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return Ok(customerService.GetAllCustomers());
        }


    }
}

