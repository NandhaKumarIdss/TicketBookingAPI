using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TicketBooking.Data.TicketBookingDbContext
{
        public class TicketBookingDbContext : DbContext
        {
            public TicketBookingDbContext(DbContextOptions options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }
}
