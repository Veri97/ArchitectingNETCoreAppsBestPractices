using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketApp.TicketManagement.Application.Contracts.Persistence;
using TicketApp.TicketManagement.Domain.Entities;

namespace TicketApp.TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(TicketAppDbContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = await _dbContext.Events.AnyAsync(e => e.Name.Equals(name)
                                                    && e.Date.Date.Equals(eventDate.Date));

            return matches;
        }
    }
}
