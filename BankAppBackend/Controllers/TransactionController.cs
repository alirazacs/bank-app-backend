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
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        [HttpPost]
        public ActionResult<Applicant> AddTransaction([FromBody] TransactionExtended transaction)
        {
            try
            {
                return Ok(this._transactionService.AddTransaction(transaction));
            }
            catch (EntityNotFoundException exception)
            {
                Console.Write(exception.ToString());
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return BadRequest(exception.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactionById(Guid id)
        {
            try
            {
                return Ok(this._transactionService.GetTransactionById(id));
            }
            catch (EntityNotFoundException exception)
            {
                Console.Write(exception.ToString());
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return BadRequest(exception.Message);
            }
        }

        /*
         * why we need this?
         */
        [HttpGet]
        public ActionResult<List<Transaction>> GetAllTranscation()
        {
            IEnumerable<Transaction> txnList = this._transactionService.GetTransactions();
            return Ok(txnList);
        }

        [HttpGet("accountTransactions/{accountId}")]
        public ActionResult<List<Transaction>> GetAllTranscationByAccountId(Guid accountId)
        {
            IEnumerable<Transaction> txnList = this._transactionService.GetTransactionsByAccountId(accountId);
            return Ok(txnList);
        }
    }
}
