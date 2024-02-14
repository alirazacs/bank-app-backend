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
        private ITellerService tellerSevice;
        
        public TellerController(ITellerService applicantService)
        {
            tellerSevice = applicantService;
        }

        [HttpPut("changeStatus/{applicantId}")]
        public ActionResult ChangeApplicantStatus(long applicantId, [FromBody] ApplicantStatus accountStatus)
        {
            try
            {
                tellerSevice.ChangeApplicantStatus(applicantId, accountStatus.AccountStatus, accountStatus.TellerId);
                return Ok();
            }
            catch (EntityAlreadyExistException exception)
            {
                Console.WriteLine(exception.ToString());
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
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
            catch (EntityAlreadyExistException exception)
            {
                Console.WriteLine(exception.ToString());
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
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
            catch (EntityAlreadyExistException exception)
            {
                return Conflict(exception.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            } 
        }
    }
}
