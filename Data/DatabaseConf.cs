using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Name;
using UsersAPI.Models;

namespace UsersAPI.Data
{
    public class DatabaseConf : DbContext
    {
        public DatabaseConf(DbContextOptions<DatabaseConf> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<UserVerificationCode> UserVerificationCodes { get; set; }
    }
}
