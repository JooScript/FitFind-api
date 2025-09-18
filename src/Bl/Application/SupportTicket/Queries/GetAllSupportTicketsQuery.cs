using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Da.Models;
using MediatR;

namespace ECommerce.Bl.Application.SupportTicket.Queries
{
    public record GetAllSupportTicketsQuery(int PageNumber, int PageSize) : IRequest<PagedResult<SupportTicketDto>>;

    public class GetAllSupportTicketsHandler : IRequestHandler<GetAllSupportTicketsQuery, PagedResult<SupportTicketDto>>
    {
        private readonly ISupportTicket _SupportTicketService;

        public GetAllSupportTicketsHandler(ISupportTicket SupportTicketService)
        {
            _SupportTicketService = SupportTicketService;
        }

        public async Task<PagedResult<SupportTicketDto>> Handle(GetAllSupportTicketsQuery request, CancellationToken cancellationToken)
        {
            return await _SupportTicketService.GetPagedListAsync(request.PageNumber, request.PageSize);
        }
    }
}