using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TicketApp.TicketManagement.Application.Contracts.Persistence;
using TicketApp.TicketManagement.Persistence.Repositories;

namespace TicketApp.TicketManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services
            ,IConfiguration configuration)
        {
            services.AddDbContext<TicketAppDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("TicketManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IEventRepository, EventRepository>();

            return services;
        }
    }
}
