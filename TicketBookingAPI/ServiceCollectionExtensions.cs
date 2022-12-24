using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TicketBooking.Application.Mapping;

namespace TicketBooking
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MapProfile>();
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}