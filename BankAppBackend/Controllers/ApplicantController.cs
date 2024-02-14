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
        private readonly IApplicantService applicantService;
        
        public ApplicantController(IApplicantService applicantService)
        {
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
        public ActionResult<Applicant> AddApplicant([FromBody] Applicant applicant)
        {
            try
            {
                Applicant savedApplicant = applicantService.AddApplicant(applicant);
                return Ok(savedApplicant);
            }
            catch(EntityAlreadyExistException exception)
            {
                Console.WriteLine(exception.ToString());
                return Conflict(exception.Message);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.ToString());
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

    }
}
