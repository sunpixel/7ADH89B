using Microsoft.EntityFrameworkCore;
using dbapp.Data_classes;


namespace dbapp.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Database.db");   // To make it localised

            options.UseSqlite(@$"Data Source={path}");

            
            //using (var context = new AppDbContext())
            //{
            //    context.Database.EnsureCreated();
            //}
        }


    }
}