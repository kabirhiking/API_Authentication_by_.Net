
// /Models/AppDbContext.cs
using API_Authentication.Models;
using Microsoft.EntityFrameworkCore;

        namespace API_Authentication.Models
        {
            public class AppDbContext : DbContext
            {
                public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

                public DbSet<User> Users { get; set; }
            }
        }
