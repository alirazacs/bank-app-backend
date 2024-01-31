using BankAppBackend.Models;
using BankAppBackend.Service;
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
        public Applicant? GetApplicants(long applicantId, AccountStatus accountStatus )
        {
            return tellerSevice.ChangeApplicantStatus(applicantId, accountStatus);
        }
        

    }
}
