using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TicketBooking.Data.Mappings.Users
{
    public class UsersMap: IEntityTypeConfiguration<TicketBooking.Entities.Users>
    {

        public void Configure(EntityTypeBuilder<TicketBooking.Entities.Users> builder)
        {
            builder.ToTable(nameof(TicketBooking.Entities.Users));

            builder
                .Property(o => o.FirstName)
                .IsRequired();

            builder
              .Property(o => o.LastName)
              .IsRequired();

            builder
             .Property(o => o.EmailId)
             .IsRequired();

            builder
            .Property(o => o.Password)
            .IsRequired();

            builder
            .Property(o => o.PhoneNumber)
            .IsRequired();

            builder
            .Property(o => o.ConfirmPassword)
            .IsRequired();

            //relationships
            builder.HasMany(o => o.BookingDetails)
                .WithOne(o => o.Users)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(o => o.BookingMasters)
               .WithOne(o => o.Users)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.HallSeats)
              .WithOne(o => o.Users)
              .HasForeignKey(o => o.UserId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.EventHalls)
              .WithOne(o => o.Users)
              .HasForeignKey(o => o.UserId)
              .OnDelete(DeleteBehavior.Restrict);


        }
    }
}


