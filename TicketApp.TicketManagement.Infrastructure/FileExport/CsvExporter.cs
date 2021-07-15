using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using TicketApp.TicketManagement.Application.Contracts.Infrastructure;
using TicketApp.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace TicketApp.TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();

            using(var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, 
                    new CsvConfiguration(cultureInfo: CultureInfo.InvariantCulture));

                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
