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
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomerService customerService;
        private readonly IAccountService accountService;

        public CustomerController(ILogger<CustomerController> logger,
            ICustomerService customerService,
            IAccountService accountService)
        {
            this.logger = logger;
            this.customerService = customerService;
            this.accountService = accountService;
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

        /*
         * why we need this?
         */
        [HttpGet("allCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return Ok(customerService.GetAllCustomers());
        }

        [HttpGet("{customerId}")]
        public ActionResult<Customer> GetCustomerDetailsById(long customerId)
        {
            try
            {
                return Ok(customerService.FindCustomerById(customerId));
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "GetCustomerDetailsById failed for {customerId}", customerId);

                if (exception is EntityNotFoundException)
                    return NotFound(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }

        [HttpGet("customerAccounts/{customerId}")]
        public ActionResult<List<Account>> GetAccountsByCustomerId(long customerId)
        {
            return Ok(accountService.GetAccountsAgainstCustomerId(customerId));
        }

        [HttpGet("customerAccount/{customerId}")]
        public ActionResult<Account> GetAccountByCustomerId(long customerId)
        {
            return Ok(accountService.GetAccountAgainstCustomerId(customerId));
        }

    }
}

