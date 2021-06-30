using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
