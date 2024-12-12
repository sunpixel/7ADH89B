using back.Data;
using Humanizer.Bytes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using back.Additional;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetLoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetLoginController(AppDbContext context)
        {
            _context = context;
        }

        // Works

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials credentials)
        {
            // Find the user by username and password

            var sup = new Supplementary();

            // Each user must be made with this code

            var user = _context.Users.FirstOrDefault(u =>
            u.Username == credentials.Username.ToString() &&
            u.Password == sup.MakeHash(credentials.Password).ToString());


            if (user == null)
            {
                return NotFound("User not found or invalid credentials.");
            }

            return Ok(new { UserId = user.Id });
        }
    }
}




