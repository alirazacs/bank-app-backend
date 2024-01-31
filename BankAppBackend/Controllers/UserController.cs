using Microsoft.AspNetCore.Mvc;
using BankAppBackend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BankAppBackend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class HomeController1(DatabaseContext context) : ControllerBase
    {
        private readonly DatabaseContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            // Logic to fetch data and return a response
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> FindUserById(long id)
        {
            var users = await _context.Users.FindAsync(id);
            if(users == null)
            {
                return NotFound($"User not found with id {id}");
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new {message = "User Added successfully", data = user});
        }

    }
}
