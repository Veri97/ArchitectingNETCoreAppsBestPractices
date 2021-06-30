using AutoMapper;
using TicketApp.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TicketApp.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
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
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();

            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();

        }
    }
}
