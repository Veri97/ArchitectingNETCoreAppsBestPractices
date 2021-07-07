using TicketApp.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp.TicketManagement.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size);
        Task<int> GetTotalCountOfOrdersForMonth(DateTime date);
    }
}
