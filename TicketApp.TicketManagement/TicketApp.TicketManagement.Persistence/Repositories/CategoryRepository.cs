using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.TicketManagement.Application.Contracts.Persistence;
using TicketApp.TicketManagement.Domain.Entities;

namespace TicketApp.TicketManagement.Persistence.Repositories
{
    class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TicketAppDbContext _dbContext) : base(_dbContext)
        {
                 
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = await _dbContext.Categories.Include(c => c.Events).ToListAsync();

            if (!includePassedEvents)
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));

            return allCategories;
        }
    }
}
