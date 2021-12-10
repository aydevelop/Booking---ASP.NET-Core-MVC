using Booking.DAL.Configurations;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Hoster> Hosters { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Explorer> Explorers { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<ApartmentFeature> ApartmentFeature { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new HosterConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
