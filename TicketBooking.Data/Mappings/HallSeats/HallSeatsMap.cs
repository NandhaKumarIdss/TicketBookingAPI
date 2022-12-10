using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBooking.Data.Mappings.HallSeats
{
    public class HallSeatsMap : IEntityTypeConfiguration<TicketBooking.Entities.HallSeats>
    {

        public void Configure(EntityTypeBuilder<TicketBooking.Entities.HallSeats> builder)
        {
            builder
                .Property(o => o.HallId)
                .IsRequired();

            builder
               .Property(o => o.HallSeatId)
               .IsRequired();

            builder
              .Property(o => o.SeatColumn)
              .IsRequired();

            builder
             .Property(o => o.SeatNumber)
             .IsRequired();

            builder
            .Property(o => o.SeatRow)
            .IsRequired();

            builder
            .Property(o => o.SeatStatus)
            .IsRequired();

            //relationships
            builder.HasMany(o => o.BookingDetails)
                .WithOne(o => o.HallSeats)
                .HasForeignKey(o => o.HallSeatId)
                .OnDelete(DeleteBehavior.Restrict);

           
        }
    }
}

