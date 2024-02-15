using BankAppBackend.Exceptions;
using BankAppBackend.Models;
using BankAppBackend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAppBackend.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> logger;
        private readonly ITransactionService transactionService;

        public TransactionController(ILogger<TransactionController> logger,
            ITransactionService transactionService)
        {
            this.logger = logger;
            this.transactionService = transactionService;
        }

        [HttpPost]
        public ActionResult<Applicant> AddTransaction([FromBody] TransactionExtended transaction)
        {
            try
            {
                return Ok(this.transactionService.AddTransaction(transaction));
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "AddTransaction failed");

                if (exception is EntityNotFoundException)
                    return NotFound(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactionById(Guid id)
        {
            try
            {
                return Ok(this.transactionService.GetTransactionById(id));
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "GetTransactionById failed for {id}", id);

                if (exception is EntityNotFoundException)
                    return NotFound(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }

        /*
         * why we need this?
         */
        [HttpGet]
        public ActionResult<List<Transaction>> GetAllTranscation()
        {
            IEnumerable<Transaction> txnList = this.transactionService.GetTransactions();
            return Ok(txnList);
        }

        [HttpGet("accountTransactions/{accountId}")]
        public ActionResult<List<Transaction>> GetAllTranscationByAccountId(Guid accountId)
        {
            IEnumerable<Transaction> txnList = this.transactionService.GetTransactionsByAccountId(accountId);
            return Ok(txnList);
        }
    }
}
