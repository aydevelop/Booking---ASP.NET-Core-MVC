using Booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DAL.Configurations
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            //builder.HasOne(p => p.Apartment)
            //.WithMany(t => t.Rates)
            //.OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(p => p.Rent)
            //.WithOne(q => q.Rate)
            //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
