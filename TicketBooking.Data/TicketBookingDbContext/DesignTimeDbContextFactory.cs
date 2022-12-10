using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TicketBooking.Data.TicketBookingDbContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TicketBookingDbContext>
    {
        public TicketBookingDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TicketBookingDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);
            return new TicketBookingDbContext(builder.Options);
        }
    }
}
