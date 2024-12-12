using back.Controllers.Creators;
using back.Data;
using back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetScheduleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public GetScheduleController (AppDbContext context, ILogger<ScheduleCreateController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{group_id}")]
        public async Task<ActionResult> GetSchedule(int group_id)
        {
            var group = await _context.Groups.FindAsync(group_id);
            if (group == null)
            {
                return NotFound($"Group with id '{group_id.ToString()}' doesn't exist.");
            }

            var Schedule = await _context.Schedules
                .Where(s => s.Group == group)
                .ToListAsync();

            if (Schedule == null)
            {
                return NotFound($"Schedule for group '{group_id.ToString()}' doesn't exist.");
            }
            else
            {
                var groupDto = new Group
                {
                    Schedule = group.Schedule.Select(s => new Schedule
                    {
                        Id = s.Id,
                        Subject_Name = s.Subject_Name,
                        Day = s.Day,
                        Time = s.Time
                    }).ToList(),
                };

                return Ok(groupDto);
            }
        }
    }
}
