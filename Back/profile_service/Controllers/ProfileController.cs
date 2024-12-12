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
    public class ProfileController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public ProfileController(AppDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }


        // A test to see if the profile service is running
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            _logger.LogInformation("Getting all profiles");
            return await _context.Profiles.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProfile(int id, Profile profile)
        {
            if (id != profile.UserId)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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
        public bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.UserId == id);
        }

    }
}
