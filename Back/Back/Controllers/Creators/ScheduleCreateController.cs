using back.Additional;
using back.Data;
using back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace back.Controllers.Creators
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleCreateController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public ScheduleCreateController(AppDbContext context, ILogger<ScheduleCreateController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ScheduleCredentials homeWork)
        {
            try
            {
                _logger.LogInformation("Schedule creation");
                var Group_found = _context.Groups
                    .Include(g => g.Schedule)   // Ensure the Schedule is loaded
                    .FirstOrDefault(g => g.Id == homeWork.Group_Id);
                
                if (Group_found == null)
                {
                    
                    throw new Exception(message: $"Group with name '{homeWork.Group_Id.ToString()}' not found.");
                }

                else
                {
                    _logger.LogInformation("Group found");

                    var sc = new Schedule
                    {
                        Id = 0,
                        Day = homeWork.Day,
                        Time = homeWork.Time,
                        Subject_Name = homeWork.Subject_Name
                    };

                    sc.Group = Group_found;

                    Group_found.Schedule.Add(sc);

                    _context.SaveChanges();

                    return Ok();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex} - ошибка");
                return BadRequest(ex.Message);
            }
        }

    }
}
