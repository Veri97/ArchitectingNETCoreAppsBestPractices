using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TicketApp.TicketManagement.Application.Contracts.Infrastructure;
using TicketApp.TicketManagement.Application.Models.Mail;
using TicketApp.TicketManagement.Infrastructure.Mail;

namespace TicketApp.TicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
