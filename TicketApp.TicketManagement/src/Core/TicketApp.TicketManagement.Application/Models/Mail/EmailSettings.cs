using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.TicketManagement.Application.Models.Mail
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
