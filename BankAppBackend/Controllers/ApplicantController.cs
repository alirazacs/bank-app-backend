using Microsoft.AspNetCore.Mvc;
using BankAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using BankAppBackend.Service;

namespace BankAppBackend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private IApplicantService applicantService;
        
        public ApplicantController(IApplicantService applicantService)
        {
            this.applicantService = applicantService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Applicant>> GetAllApplicantsAsync()
        {
            // Logic to fetch data and return a response
            return Ok(applicantService.GetAllApplicantList());
        }

        [HttpGet("{id}")]
        public  ActionResult<Applicant> FindApplicantById(long id)
        {
            var applicant = applicantService.GetApplicantById(id);
            if (applicant == null)
            {
                return NotFound($"applicant not found with id {id}");
            }
            return Ok(applicant);
        }

        [HttpPost]
        public ActionResult<Applicant> AddApplicant([FromBody] Applicant applicant)
        {
            applicantService.AddApplicant(applicant);

            return Ok(new { message = "Applicant Added successfully", data = applicant });
        }

    }
}
