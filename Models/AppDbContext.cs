using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FlixNow.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Screening> Screening { get; set; }
    }

}