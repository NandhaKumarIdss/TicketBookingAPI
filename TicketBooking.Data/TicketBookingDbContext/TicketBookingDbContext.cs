using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TicketBooking.Data.TicketBookingDbContext
{
    public class TicketBookingDbContext : DbContext
    {
        public TicketBookingDbContext(DbContextOptions<TicketBookingDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
