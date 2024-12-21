using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using profile_service.Data;
using profile_service.Data_classes;

namespace profile_service.Workers
{
    public class ProfileWorker
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProfileWorker> _logger;

        public ProfileWorker(AppDbContext context, ILogger<ProfileWorker> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Profile>> GetProfilesAsync()
        {
            _logger.LogInformation("Fetching all profiles from the database.");
            return await _context.Profiles.ToListAsync();
        }

        public async Task<Profile> GetProfileAsync(int id)
        {
            _logger.LogInformation($"Fetching profile with ID {id} from the database.");
            return await _context.Profiles.FindAsync(id);
        }

        public async Task<bool> UpdateProfileAsync(int id, Profile_Request request)
        {
            _logger.LogInformation($"Updating profile with ID {id}.");
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                _logger.LogWarning($"Profile with ID {id} not found.");
                return false;
            }

            profile.F_name = request.F_name;
            profile.Enrolment_day = request.Enrolment_day;
            profile.Enrolllment_status = request.Enrolllment_status;

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Profile with ID {id} updated successfully.");
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProfileExists(id))
                {
                    _logger.LogWarning($"Profile with ID {id} does not exist.");
                    return false;
                }
                else
                {
                    _logger.LogError(ex, $"Concurrency error occurred while updating profile with ID {id}.");
                    throw;
                }
            }
        }

        public async Task<bool> DeleteProfileAsync(int id)
        {
            _logger.LogInformation($"Deleting profile with ID {id}.");
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                _logger.LogWarning($"Profile with ID {id} not found.");
                return false;
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Profile with ID {id} deleted successfully.");

            return true;
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.UserId == id);
        }
    }
}