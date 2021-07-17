using AutoMapper;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketApp.TicketManagement.Application.Contracts.Persistence;
using TicketApp.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using TicketApp.TicketManagement.Application.Profiles;
using TicketApp.TicketManagement.Domain.Entities;
using Xunit;

namespace TicketApp.TicketManagement.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public CreateCategoryTest()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mapper,_mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();

            allCategories.Count.ShouldBe(5);
        }

        [Fact]
        public async Task Handle_NonValidCategory_WhenCategoryNameIsEmptyOrTooLong()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            var createdCommandResponseWithCategoryEmptyName =  await handler.Handle(new CreateCategoryCommand() 
                                                    { Name = string.Empty }, CancellationToken.None);

            createdCommandResponseWithCategoryEmptyName.Success.ShouldBeFalse();
            createdCommandResponseWithCategoryEmptyName.ValidationErrors.Count.ShouldBeGreaterThan(0);


            var createdCommandResponseWithCategoryNameTooLong = await handler.Handle(new CreateCategoryCommand()
                                                    { Name = "testtesttesttesttesttesttesttesttesttesttesttesttest" }
                                                     , CancellationToken.None);

            createdCommandResponseWithCategoryNameTooLong.Success.ShouldBeFalse();
            createdCommandResponseWithCategoryNameTooLong.ValidationErrors.Count.ShouldBeGreaterThan(0);

        }
    }
}
