using back.Additional;
using back.Data;
using back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;

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

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] UserCredentials credentials)
        {
            _logger.LogInformation("entered creation mode");
            try
            {
                var _sup = new Supplementary();

                string User = _sup.MakeHash(credentials.Username);  // Hashing data 
                string Pass = _sup.MakeHash(credentials.Password);  // Hashing data
                string ID = await _sup.Id_creator();

                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == ID);

                // Проверяет маловероятную ситуацию, когда Guid сделал тот же ID для пользователя что уже существует

                if (existingUser == null)
                {

                    _logger.LogInformation($"Existing User: {existingUser}");
                    _logger.LogInformation($"Current User:  {ID}");


                    _logger.LogInformation("Final stage");
                    var check = _context.Users.FirstOrDefault(u =>
                    u.Username == User);
                    if (check == null)
                    {
                        _logger.LogInformation("Final check passed");
                        var User_data = new Models.User
                        {
                            Id = ID,
                            Username = User,
                            Password = Pass
                        };

                        _context.Users.Add(User_data);
                        _logger.LogInformation("User data added");
                        _logger.LogInformation($"User data = \nID:{User_data.Id} \nUsername{User_data.Username} \nPassword{User_data.Password}");
                        await _context.SaveChangesAsync();
                        _logger.LogWarning("Updated DB");

                    }
                }
                _logger.LogInformation("Loop exited");

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
