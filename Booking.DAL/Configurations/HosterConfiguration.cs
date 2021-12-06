using Booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DAL.Configurations
{
    public class HosterConfiguration : IEntityTypeConfiguration<Hoster>
    {
        public void Configure(EntityTypeBuilder<Hoster> builder)
        {
            builder.Property(note => note.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(note => note.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
