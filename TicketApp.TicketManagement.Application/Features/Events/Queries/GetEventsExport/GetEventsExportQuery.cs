using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TicketApp.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery : IRequest<EventExportFileVm>
    {

    }
}
