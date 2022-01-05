using ChargePointer.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChargePointer.Infrastructure.Data
{
    public class ChargePointerDbContext : DbContext
    {
        public ChargePointerDbContext(DbContextOptions<ChargePointerDbContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<ChargePoint> ChargePoints { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Location>()
                .HasKey(pk => pk.LocationId);

            builder
                .Entity<ChargePoint>()
                .HasKey(pk => pk.ChargePointId);
        }
    }
}