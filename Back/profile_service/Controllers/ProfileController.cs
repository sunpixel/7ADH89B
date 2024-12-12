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


        // Retrieve all user profiles

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            _logger.LogInformation("Getting all profiles");
            return await _context.Profiles.ToListAsync();
        }

        // EDIT: api/Profile/{id}

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

        [HttpPut("/img/{id}")]
        public async Task<IActionResult> EditProfilePicture(int id, IFormFile profilePicture)
        {
            if (profilePicture == null || profilePicture.Length == 0)
            {
                return BadRequest();
            }

            _logger.LogInformation("Editing profile picture for user with id: " + id);

            var profile = await _context.Profiles.FindAsync(id);

            if (profile == null)
            {
                _logger.LogInformation("Profile not found");
                return NotFound();
            }

            // Converting image to byte array to effectively store in database

            using (var memoryStream = new MemoryStream())
            {
                _logger.LogInformation("Converting image to byte array");
                await profilePicture.CopyToAsync(memoryStream);
                profile.Profile_picture = memoryStream.ToArray();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                _logger.LogInformation("Attempting to save data into the database");
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogInformation("Save attempt faild");

                if (!ProfileExists(id))
                {
                    _logger.LogInformation("Profile not found");
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
