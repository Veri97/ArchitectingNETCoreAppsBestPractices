using AutoMapper;
using TicketApp.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using TicketApp.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TicketApp.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TicketApp.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using TicketApp.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using TicketApp.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using TicketApp.TicketManagement.Application.Features.Events.Queries.GetEventList;
using TicketApp.TicketManagement.Domain.Entities;

namespace TicketApp.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();


        }
    }
}
