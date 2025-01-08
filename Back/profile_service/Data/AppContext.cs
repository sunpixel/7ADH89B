using Microsoft.EntityFrameworkCore;
using profile_service.Data_classes;


namespace profile_service.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Contract> Contracts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Users.db");   // To make it localised

            options.UseSqlite(@$"Data Source={path}");

            // Ensure the database is created

/*            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }*/
        }


    }
}
