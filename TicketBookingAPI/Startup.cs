using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TicketBooking;
using TicketBooking.Application.Auth;
using TicketBooking.Application.BookingDetail.Model;
using TicketBooking.Application.BookingDetail.Service;
using TicketBooking.Application.BookingMaster.Model;
using TicketBooking.Application.BookingMaster.Service;
using TicketBooking.Application.EventHall.Model;
using TicketBooking.Application.EventHall.Service;
using TicketBooking.Application.HallSeats.Model;
using TicketBooking.Application.HallSeats.Service;
using TicketBooking.Application.Mapping;
using TicketBooking.Application.Users.Service;
using TicketBooking.Data.Mappings.HallSeats;
using TicketBooking.Data.TicketBookingDbContext;
using TicketBooking.Repositories.GenericRepository;

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
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<HallSeatsMap>();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped<IHallSeatsService, HallSeatsService>();

            services.AddControllers();

            services.AddDbContext<TicketBookingDbContext>(option => option.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ticket Booking API V1",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Nandhakumar S",
                        Email = "nandha14596@gmail.com"
                    }
                });
            });

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
                            .WithOrigins()
                            .AllowCredentials()
                            .SetIsOriginAllowed(data => true)
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

            app.UseGlobalExceptionHandling();

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
