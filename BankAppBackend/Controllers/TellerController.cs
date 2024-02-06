using BankAppBackend.Models;
using BankAppBackend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            tellerSevice.ChangeApplicantStatus(applicantId, accountStatus.AccountStatus, accountStatus.TellerId);
            return Ok(new {message="Applicant Status has been updated successfully."});
        }

        [HttpGet("{id}")]
        public ActionResult<Teller> GetTellerById(long id)
        {
            return tellerSevice.GetTellerById(id);
        }

        

    }
}
