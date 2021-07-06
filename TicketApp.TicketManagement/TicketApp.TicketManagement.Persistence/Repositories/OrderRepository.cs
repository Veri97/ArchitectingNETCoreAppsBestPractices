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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(TicketAppDbContext _dbContext) : base(_dbContext)
        {
                
        }

        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var pagedOrders = await _dbContext.Orders
                                               .Where(o => o.OrderPlaced.Month == date.Month
                                                  && o.OrderPlaced.Year == date.Year)
                                               .Skip((page - 1) * size)
                                               .Take(size)
                                               .AsNoTracking()
                                               .ToListAsync();

            return pagedOrders;
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            var totalOrdersForMonth = await _dbContext.Orders
                                                .CountAsync(o => o.OrderPlaced.Month == date.Month
                                                   && o.OrderPlaced.Year == date.Year);

            return totalOrdersForMonth;
        }
    }
}
