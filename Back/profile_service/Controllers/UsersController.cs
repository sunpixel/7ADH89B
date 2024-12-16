using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using profile_service.Data;
using profile_service.Data_classes;

namespace profile_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(AppDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            _logger.LogInformation("Getting all users");
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User_Request request)
        {
            // Ensure the user object is valid
            if (request == null)
            {
                return BadRequest("User data is null.");
            }


            // Create a new User
            var user = new User
            {
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Email,
                CreatedAt = DateTime.UtcNow
            };

            // Hash the user's password
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.CreatedAt = DateTime.UtcNow;

            // Add the user to the context
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Check if the profile is null and create an empty profile if necessary
            if (user.Profile == null)
            {
                // Load a random picture from a file or resource
                byte[] defaultPicture = System.IO.File.ReadAllBytes("defaults/picture.png");

                user.Profile = new Profile
                {
                    UserId = user.Id,
                    F_name = string.Empty,
                    Profile_picture = defaultPicture,
                    Enrolment_day = default,
                    Enrolllment_status = EnrollmentStatus.Pending
                };
                _context.Profiles.Add(user.Profile);
                await _context.SaveChangesAsync();
            }

            // Create a User_Response object to send back as JSON
            var userResponse = new User_Response
            {
                Id = user.Id,
                Username = user.Username
            };

            // Return the created user as JSON
            return Ok(userResponse);
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            var userResponse = new User_Response
            {
                Id = user.Id,
                Username = user.Username
            };

            // Return the created user as JSON
            return Ok(userResponse);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
