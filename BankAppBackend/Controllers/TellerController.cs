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

        [HttpPut("changeStatus")]
        public ActionResult ChangeApplicantStatus(long applicantId, AccountStatus accountStatus, long tellerId )
        {
            tellerSevice.ChangeApplicantStatus(applicantId, accountStatus, tellerId);
            return Ok(new {message="Applicant Status has been updated successfully."});
        }

        [HttpGet("{id}")]
        public ActionResult<Teller> GetTellerById(long id)
        {
            return tellerSevice.GetTellerById(id);
        }

        

    }
}
