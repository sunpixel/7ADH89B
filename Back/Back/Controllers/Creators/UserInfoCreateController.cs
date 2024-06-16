using back.Additional;
using back.Data;
using back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers.Creators
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoCreateController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public UserInfoCreateController (AppDbContext context, ILogger<UserInfoCreateController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserInfoCredentials UIC)
        {
            try
            {
                _logger.LogInformation("UserInfo creation");
                var User_found = _context.Users
                    .Include(g => g.UserInfo)  // Ensure the HomeWorks collection is loaded
                    .FirstOrDefault(g => g.Id == UIC.User_Id);
                if (User_found == null)
                {
                    throw new Exception(message: $"Group with name '{UIC.User_Id.ToString()}' not found.");
                }
                else
                {
                    var info = new UserInfo
                    {
                        Id = 0,
                        FirstName = UIC.FirstName,
                        LastName = UIC.LastName,
                        Email = UIC.Email = "bob@bob.bob",
                        Phone = UIC.Phone = "+79252202222",
                        Grade = UIC.Grade = 0,
                        University = UIC.University,
                        Speciality = UIC.Speciality = "Not Set"
                    };

                    info.User = User_found;
                    _context.UsersInfos.Add(info);
                    _context.SaveChanges();

                }

                return Ok(UIC);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex} - ошибка");
                return BadRequest(ex.Message);
            }
        }
    }
}
