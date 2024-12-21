using Microsoft.AspNetCore.Mvc;
using profile_service.Data_classes;
using profile_service.Workers;

namespace profile_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserWorker _userWorker;

        public UsersController(UserWorker userWorker)
        {
            _userWorker = userWorker;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userWorker.GetUsersAsync();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userWorker.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User_Request request)
        {
            if (request == null)
            {
                return BadRequest("User data is null.");
            }

            var result = await _userWorker.UpdateUserAsync(id, request);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User_Response>> PostUser(User_Request request)
        {
            if (request == null)
            {
                return BadRequest("User data is null.");
            }

            var user = await _userWorker.CreateUserAsync(request);

            var userResponse = new User_Response
            {
                Id = user.Id,
                Username = user.Username
            };

            return Ok(userResponse);
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userWorker.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
