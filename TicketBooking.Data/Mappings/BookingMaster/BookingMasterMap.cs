using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBooking.Data.Mappings.BookingMaster
{
    public class BookingMasterMap : IEntityTypeConfiguration<TicketBooking.Entities.BookingMaster>
    {
        public const int CustomerName = 100;
        public void Configure(EntityTypeBuilder<TicketBooking.Entities.BookingMaster> builder)
        {

            builder.ToTable(nameof(TicketBooking.Entities.BookingMaster));

            builder
               .Property(o => o.CustomerName)
               .HasMaxLength(CustomerName)
               .IsRequired();

            builder
              .Property(o => o.NumberOfSeats)
              .IsRequired();

            builder
             .Property(o => o.HallId)
             .IsRequired();



            //relationships
            builder.HasMany(o => o.BookingDetails)
                .WithOne(o => o.BookingMasters)
                .HasForeignKey(o => o.BookingId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

