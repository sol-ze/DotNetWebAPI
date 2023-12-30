using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Data
{
    public class DatabaseConf : DbContext
    {
        public DatabaseConf(DbContextOptions<DatabaseConf> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        // public DbSet<City> UserRoles { get; set; }
    }
}
