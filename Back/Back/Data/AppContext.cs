using back.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserIfnoModel> UsersIfno { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "DataBase.db");

            options.UseSqlite(@$"Data Source={path}");
        }


    }
}
