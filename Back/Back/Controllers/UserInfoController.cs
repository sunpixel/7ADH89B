using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using back.Data; // Update with your namespace
using back.Models; // Update with your namespace

namespace back.Controllers // Update with your namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserInfoController(AppDbContext context)
        {
            _context = context;
        }

/*        // GET: api/UserInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(int id)
        {
            var userInfo = await _context.UserInfos.FindAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo); // Returns JSON data
        }*/
    }
}
