using MediatR;
using System;

namespace TicketApp.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
