using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using profile_service.Data;
using profile_service.Data_classes;

namespace profile_service.Workers
{
    public class UserWorker
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserWorker> _logger;

        public UserWorker(AppDbContext context, ILogger<UserWorker> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            _logger.LogInformation("Fetching all users from the database.");
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            _logger.LogInformation($"Fetching user with ID {id} from the database.");
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> UpdateUserAsync(int id, User_Request request)
        {
            _logger.LogInformation($"Updating user with ID {id}.");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {id} not found.");
                return false;
            }

            user.Username = request.Username;
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Email = request.Email;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation($"User with ID {id} updated successfully.");
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(id))
                {
                    _logger.LogWarning($"User with ID {id} does not exist.");
                    return false;
                }
                else
                {
                    _logger.LogError(ex, $"Concurrency error occurred while updating user with ID {id}.");
                    throw;
                }
            }
        }

        // User creation
        public async Task<User> CreateUserAsync(User_Request request)
        {
            _logger.LogInformation("Creating a new user.");
            var user = new User
            {
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Email,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            if (user.Profile == null)
            {
                byte[] defaultPicture = System.IO.File.ReadAllBytes("defaults/picture.png");

                user.Profile = new Profile
                {
                    UserId = user.Id,
                    F_name = string.Empty,
                    Profile_picture = defaultPicture,
                    Enrolment_day = default,
                    Enrolllment_status = EnrollmentStatus.Pending
                };
                _context.Profiles.Add(user.Profile);
                await _context.SaveChangesAsync();
            }

            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            _logger.LogInformation($"Deleting user with ID {id}.");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {id} not found.");
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"User with ID {id} deleted successfully.");

            return true;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
