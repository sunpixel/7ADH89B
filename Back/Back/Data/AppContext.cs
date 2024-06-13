using back.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UsersInfos { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Schedule> Schedules { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "DataBase.db");

            options.UseSqlite(@$"Data Source={path}");
        }


    }
}
