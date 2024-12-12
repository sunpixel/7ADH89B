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
    public class HomeWorkCreateController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public HomeWorkCreateController (AppDbContext context, ILogger<HomeWorkCreateController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] HomeWorkCredentilas homeWork)
        {
            try
            {
                _logger.LogInformation("Homework creation");
                var Group_found = _context.Groups
                    .Include(g => g.HomeWorks)  // Ensure the HomeWorks collection is loaded
                    .FirstOrDefault(g => g.Id == homeWork.Group_Id);

                if (Group_found == null)
                {
                    _logger.LogInformation("No group found");
                    throw new InvalidOperationException($"Group with name '{homeWork.Group_Id.ToString()}' not found.");
                }
                else
                {
                    _logger.LogInformation("Group found");
                    // Not the best model needs revising.
                    // Better make subjects and connect Hw to them.
                    var Hw = new HomeWork
                    {
                        Id = 0,
                        Name = homeWork.Name,
                        DeadLine = homeWork.DeadLine,
                        Assignement = homeWork.Assignment,
                    };
                    _logger.LogInformation("Made Homework record");

                    Hw.Group = Group_found;

                    Group_found.HomeWorks.Add(Hw);
                    
                    _context.SaveChanges();

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex} - ошибка");
                return BadRequest();
            }
        }
    }
}
