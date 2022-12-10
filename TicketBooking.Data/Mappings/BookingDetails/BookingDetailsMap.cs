using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBooking.Data.Mappings.BookingDetails
{
    public class BookingDetailsMap : IEntityTypeConfiguration<TicketBooking.Entities.BookingDetail>
    {
        public const int CustomerName = 100;

        public void Configure(EntityTypeBuilder<TicketBooking.Entities.BookingDetail> builder)
        {

            builder
               .Property(o => o.BookingId)
               .IsRequired();

            builder
              .Property(o => o.BookingDetailId)
              .IsRequired();

            builder
             .Property(o => o.SeatNumber)
             .IsRequired();

            builder
             .Property(o => o.HallSeats)
             .IsRequired();


        }
    }
}

