﻿using Booking.DAL.Configurations;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Hoster> Hosters { get; set; }
        public DbSet<Location> Locations { get; set; }

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