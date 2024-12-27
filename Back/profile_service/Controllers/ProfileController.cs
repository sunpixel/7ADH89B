using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using profile_service.Data_classes;
using profile_service.Workers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace profile_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileWorker _profileWorker;

        public ProfileController(ProfileWorker profileWorker)
        {
            _profileWorker = profileWorker;
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<IEnumerable<Profile_Request>>> GetProfiles()
        {
            var profiles = await _profileWorker.GetProfilesAsync();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult<Profile_Request>> GetProfile(int id)
        {
            var profile = await _profileWorker.GetProfileAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "EditPolicy")]
        public async Task<IActionResult> PutProfile(int id, [FromBody] Profile_Request request)
        {
            if (request == null)
            {
                return BadRequest("The request field is required.");
            }

            var result = await _profileWorker.UpdateProfileAsync(id, request);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "DeletePolicy")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var result = await _profileWorker.DeleteProfileAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
