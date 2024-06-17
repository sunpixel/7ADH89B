using back.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetScheduleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetScheduleController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{group_id}")]
        public async Task<ActionResult> GetSchedule(int group_id)
        {
            var Schedule = await _context.Schedules
                .Where(s => s.GroupId == group_id)
                .ToListAsync();

            if (Schedule == null)
            {
                return NotFound($"Group with id '{group_id.ToString()}' doesn't exist.");
            }
            else
            {

                return Ok(Schedule);
            }
        }
    }
}
