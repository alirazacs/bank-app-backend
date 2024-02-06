using BankAppBackend.Models;
using BankAppBackend.Repositories;
using BankAppBackend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAppBackend.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService) {
            this._transactionService = transactionService;
        }

        [HttpPost]
        public ActionResult<Applicant> AddTransaction([FromBody] TransactionExtended transaction)
        {
            Transaction savedtxn = this._transactionService.AddTransaction(transaction);
            return Ok(new { message = "Transaction Added successfully", data = savedtxn });
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactionById(long id)
        {
            Transaction? txn = this._transactionService.GetTransactionById(id);
            if (txn == null)
            {
                return NotFound($"Transaction not found with id {id}");
            }
            return Ok(new { message = "Transaction Retrieved successfully", data = txn });
        }

        [HttpGet]
        public ActionResult<List<Transaction>> GetAllTranscation()
        {
            IEnumerable<Transaction> txnList = this._transactionService.GetTransactions();
            return Ok(new { message = "Transaction Retrieved successfully", data = txnList });
        }
    }
}
