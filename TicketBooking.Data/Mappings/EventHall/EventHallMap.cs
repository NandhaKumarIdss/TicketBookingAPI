using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBooking.Data.Mappings.EventHall
{
    public class EventHallMap : IEntityTypeConfiguration<TicketBooking.Entities.EventHall>
    {
        public const int HallName = 100;

        public void Configure(EntityTypeBuilder<TicketBooking.Entities.EventHall> builder)
        {
            builder
                .Property(o => o.HallId)
                .IsRequired();

            builder
               .Property(o => o.HallName)
               .IsRequired()
               .HasMaxLength(HallName);

            builder
              .Property(o => o.HallStatus)
              .IsRequired(false);


            //relationships
            builder.HasMany(o => o.HallSeats)
                .WithOne(o => o.EventHall)
                .HasForeignKey(o => o.HallId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.BookingMasters)
                .WithOne(o => o.EventHall)
                .HasForeignKey(o => o.HallId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
