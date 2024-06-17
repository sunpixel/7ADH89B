using back.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetHomeWorkController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetHomeWorkController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{group_id}")]
        public async Task<ActionResult> GetHomeWork(int group_id)
        {
            var group = await _context.Groups.FindAsync(group_id);
            if (group == null) 
            {
                return NotFound($"Group with id '{group_id.ToString()}' doesn't exist.");
            }

            var Schedule = await _context.HomeWorks
                .Where(s => s.Group == group)
                .ToListAsync();

            if (Schedule == null)
            {
                return NotFound($"Schedule for group '{group_id.ToString()}' doesn't exist.");
            }
            else
            {

                return Ok(Schedule);
            }
        }

    }
}
