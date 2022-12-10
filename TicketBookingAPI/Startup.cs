using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using TicketBooking.Data.TicketBookingDbContext;

namespace TicketBookingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<TicketBookingDbContext>(options =>
            //{
            //    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            //});
            services.AddDbContext<TicketBookingDbContext>(option => option.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddSwaggerGen();

            services.AddCors(options =>
            {

                IEnumerable<KeyValuePair<string, string>> hosts = Configuration.GetSection("AllowedHosts").AsEnumerable();
                string[] data = hosts.Where(o => o.Value != null).Select(o => o.Value).ToArray();

                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithOrigins(data)
                            .AllowCredentials()
                            .WithExposedHeaders("Content-Disposition");
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TicketBookingDbContext>();
                context.Database.Migrate();
            }

            app.UseCors("CorsPolicy");

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Booking API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}