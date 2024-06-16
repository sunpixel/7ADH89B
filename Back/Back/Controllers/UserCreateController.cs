using back.Additional;
using back.Data;
using back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;
using System.Text.RegularExpressions;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCreateController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public UserCreateController(ILogger<UserCreateController> logger, AppDbContext conext)
        {
            _context = conext;
            _logger = logger;
        }

        // Group ID is required when creating new USER

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] UserCredentials credentials)
        {
            _logger.LogInformation("entered creation mode");
            try
            {
                var _sup = new Supplementary();

                string User = credentials.Username;
                string Pass = _sup.MakeHash(credentials.Password);  // Hashing data
                string ID = await _sup.Id_creator();

                var G_Id = await _context.Groups.FirstOrDefaultAsync(g => g.Id == credentials.Group_Id);

                if (G_Id == null)
                {
                    var group = new Models.Group()
                    {
                        Id = credentials.Group_Id,
                        Number = "221-",
                        ModeOfStudy = "Full",
                    };

                    _context.Groups.Add(group);
                    _logger.LogInformation("Group created succesefuly");
                    _context.SaveChanges();

                    // throw new InvalidOperationException($"Group with name '{credentials.Group_Id.ToString()}' not found.");
                }

                if (G_Id != null) { _logger.LogInformation($"Group found {G_Id}"); }




                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == ID);

                // Проверяет маловероятную ситуацию, когда Guid сделал тот же ID для пользователя что уже существует

                var check = _context.Users.FirstOrDefault(u =>
                                    u.Username == User);
                if (check == null)
                {
                    var User_data = new User
                    {
                        Id = ID,
                        Username = User,
                        Password = Pass
                    };

                    var Group_found = _context.Groups
                       .Include(g => g.User) // Ensure the User collection is loaded
                       .FirstOrDefault(g => g.Id == credentials.Group_Id);
                    _logger.LogInformation($"Group found - {Group_found}");

                    User_data.Group = Group_found;
                    _logger.LogInformation("Group added into user");

                    Group_found.User.Add(User_data);
                    _logger.LogInformation("User added in Group");

                    //_context.Users.Add(User_data);

                    var User_info = new Models.UserInfo
                    {
                        FirstName = "Ivan",             // Making a default value
                        University = "None",             // Default value
                        UserId = ID
                    };


                    _logger.LogInformation($"User data = \nID:{User_data.Id} \nUsername{User_data.Username} \nPassword{User_data.Password}");
                    await _context.SaveChangesAsync();
                    //
                    char a = '-';
                    string dec = new(a, 25);
                    _logger.LogInformation($"{dec}");
                    //
                    _logger.LogInformation("Updated DB");

                }

                return Ok();
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex} - ошибка");
                return BadRequest();
            }
        }
    }
}
