using JWTAuthAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthAPI.Data
{
    public class MyWorldDbContext:DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options):base(options)
        {
            
        }
        public DbSet<User> User { get; set;}
    }
}