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
        public ActionResult<Applicant?> GetApplicants(long applicantId, AccountStatus accountStatus, long tellerId )
        {
            return tellerSevice.ChangeApplicantStatus(applicantId, accountStatus, tellerId);
        }

        [HttpGet("getAllTellers")]
        public ActionResult<List<Teller>> GetAllTellers()
        {
            return tellerSevice.GetAllTellers();
        }

        

    }
}
