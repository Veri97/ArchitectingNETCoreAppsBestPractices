using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketApp.TicketManagement.Application.Models.Mail;

namespace TicketApp.TicketManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
