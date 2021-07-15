using System;
using System.Collections.Generic;
using System.Text;
using TicketApp.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace TicketApp.TicketManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
