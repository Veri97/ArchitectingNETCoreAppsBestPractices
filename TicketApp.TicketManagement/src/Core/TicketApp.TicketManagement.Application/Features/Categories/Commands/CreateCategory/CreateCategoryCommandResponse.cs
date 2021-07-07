using TicketApp.TicketManagement.Application.Responses;

namespace TicketApp.TicketManagement.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommandResponse: BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {

        }

        public CreateCategoryDto Category { get; set; }
    }
}