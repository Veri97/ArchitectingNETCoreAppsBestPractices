using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using TicketApp.TicketManagement.Application.Contracts.Persistence;
using TicketApp.TicketManagement.Application.Profiles;
using System.Threading.Tasks;
using TicketApp.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using System.Threading;
using Shouldly;
using TicketApp.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;

namespace TicketApp.TicketManagement.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListWithEventsQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetCategoriesListWithEventsQueryHandlerTest()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoriesListWithEvents();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListWithEventsNotIncludingPastEventsTest()
        {
            var handler = new GetCategoriesListWithEventsQueryHandler(_mapper,_mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListWithEventsQuery(), CancellationToken.None);

            _mockCategoryRepository.Verify(x => x.GetCategoriesWithEvents(false));

            result.ShouldBeOfType<List<CategoryEventListVm>>();

            result.Count.ShouldBeGreaterThanOrEqualTo(3);
        }

    }
}
