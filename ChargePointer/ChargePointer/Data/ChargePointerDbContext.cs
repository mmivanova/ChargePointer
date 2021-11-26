using System;
using System.Linq;
using ChargePointer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Type = ChargePointer.Domain.Entities.Type;

namespace ChargePointer.Data
{
    public class ChargePointerDbContext : DbContext
    {
        public ChargePointerDbContext(DbContextOptions<ChargePointerDbContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<ChargePoint> ChargePoints { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Type> Types { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder
                .Entity<Location>()
                .HasKey(pk => pk.LocationId);

            builder
                .Entity<ChargePoint>()
                .HasKey(pk => pk.ChargePointId);
            
            
            builder
                .Entity<Status>()
                .Property(p => p.StatusId)
                .HasConversion<int>();

            builder.Entity<Status>().HasData(
                Enum.GetValues(typeof(StatusId))
                    .Cast<StatusId>()
                    .Select(jt => new Status()
                    {
                        StatusId = jt,
                        Name = jt.ToString()
                    })
            );

            builder
                .Entity<Type>()
                .Property(p => p.TypeId)
                .HasConversion<int>();

            builder.Entity<Type>().HasData(
                Enum.GetValues(typeof(TypeId))
                    .Cast<TypeId>()
                    .Select(jt => new Type()
                    {
                        TypeId = jt,
                        Name = jt.ToString()
                    })
            );
        }
    }
}