using Booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DAL.Configurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.Property(note => note.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(note => note.Name).IsUnique();
            builder.Property(note => note.Address).IsRequired().HasMaxLength(200);

            builder.HasOne(p => p.Hoster)
                .WithMany(q => q.Apartments)
                .HasForeignKey(i => i.HosterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
