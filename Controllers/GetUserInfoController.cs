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
    public class GetUserInfoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetUserInfoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInfo/5
        // Works

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserInfo(string id)
        {
            var userInfo = await _context.UsersInfos.FirstOrDefaultAsync(u => u.UserId == id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo); // Returns JSON data
        }
    }
}
