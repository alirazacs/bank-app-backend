using Microsoft.AspNetCore.Mvc;
using BankAppBackend.Models;
using BankAppBackend.Service.Interfaces;
using BankAppBackend.Exceptions;

namespace BankAppBackend.Controllers
{
    [Route("api/applicant")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<ApplicantController> logger;
        private readonly IApplicantService applicantService;
        
        public ApplicantController(ILogger<ApplicantController> logger,
            IApplicantService applicantService)
        {
            this.logger = logger;
            this.applicantService = applicantService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Applicant>> GetAllApplicants()
        {
            // Logic to fetch data and return a response
            return Ok(applicantService.GetAllApplicantList());
        }

        [HttpGet("{id}")]
        public  ActionResult<Applicant> FindApplicantById(long id)
        {
            try
            {
                var applicant = applicantService.GetApplicantById(id);
                return Ok(applicant);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "FindApplicantById failed for {id}", id);

                if (exception is EntityAlreadyExistException)
                    return NotFound(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult<Applicant> AddApplicant([FromBody] Applicant applicant)
        {
            try
            {
                Applicant savedApplicant = applicantService.AddApplicant(applicant);
                return Ok(savedApplicant);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "AddApplicant failed");

                if (exception is EntityAlreadyExistException)
                    return Conflict(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }

        [HttpGet("/api/applicant/email/{emailAddress}")]
        public ActionResult<Applicant> FindApplicantByEmailAddress(string emailAddress)
        {
            try
            {
                var applicant = applicantService.GetApplicantByEmail(emailAddress);
                return Ok(applicant);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "FindApplicantByEmailAddress failed for {emailAddress}", emailAddress);

                if (exception is EntityAlreadyExistException)
                    return NotFound(exception.Message);
                else
                    return BadRequest(exception.Message);
            }
        }
    }
}
