using Microsoft.AspNetCore.Mvc;
using BankAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAppBackend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class ApplicantController(DatabaseContext context) : ControllerBase
    {
        private readonly DatabaseContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetAllApplicantsAsync()
        {
            // Logic to fetch data and return a response
            return await _context.applicants.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Applicant>> FindApplicantById(long id)
        {
            var applicants = await _context.applicants.FindAsync(id);
            if(applicants == null)
            {
                return NotFound($"applicant not found with id {id}");
            }
            return Ok(applicants);
        }

        [HttpPost]
        public async Task<ActionResult<Applicant>> AddApplicant([FromBody] Applicant applicant)
        {
            _context.applicants.Add(applicant);
            await _context.SaveChangesAsync();
            return Ok(new {message = "Applicant Added successfully", data = applicant });
        }

    }
}
