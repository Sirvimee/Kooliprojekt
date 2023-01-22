using Microsoft.EntityFrameworkCore;
using GameHouse.Data;

namespace GameHouse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GameHouse.Data.Room> Room { get; set; } = default!;

        public DbSet<GameHouse.Data.Booking> Booking { get; set; }

        public DbSet<GameHouse.Data.Gallery> Gallery { get; set; }
    }
}
