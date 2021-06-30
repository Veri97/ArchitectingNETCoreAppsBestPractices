using TicketApp.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.TicketManagement.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
    }
}
