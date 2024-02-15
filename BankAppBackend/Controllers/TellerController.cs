using BankAppBackend.Exceptions;
using BankAppBackend.Models;
using BankAppBackend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAppBackend.Controllers
{
    [Route("api/teller")]
    [ApiController]
    public class TellerController : ControllerBase
    {
        private readonly ILogger<TellerController> logger;
        private readonly ITellerService tellerSevice;
        
        public TellerController(ILogger<TellerController> logger,
            ITellerService applicantService)
        {
            this.logger = logger;
            this.tellerSevice = applicantService;
        }

        [HttpPut("changeStatus/{applicantId}")]
        public ActionResult ChangeApplicantStatus(long applicantId, [FromBody] ApplicantStatus accountStatus)
        {
            try
            {
                tellerSevice.ChangeApplicantStatus(applicantId, accountStatus.AccountStatus, accountStatus.TellerId);
                return Ok();
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "ChangeApplicantStatus failed for {applicantId}", applicantId);

                if (exception is EntityAlreadyExistException)
                    return NotFound(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Teller> GetTellerById(long id)
        {
            try
            {
                return tellerSevice.GetTellerById(id);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "GetTellerById for {id}", id);

                if (exception is EntityAlreadyExistException)
                    return NotFound(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult<Teller> RegisterTeller(Teller teller)
        {
            try
            {
                return tellerSevice.RegisterTeller(teller);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "RegisterTeller failed");

                if (exception is EntityAlreadyExistException)
                    return Conflict(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }
    }
}
