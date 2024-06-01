using back.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public loginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials userCredentials)
        {
            // Find the user by username and password
            var user = _context.Users.FirstOrDefault(u => u.Username == userCredentials.Username && u.Password == userCredentials.Password);

            if (user == null)
            {
                return NotFound("User not found or invalid credentials.");
            }

            return Ok(new { UserId = user.Id });
        }
    }

    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

