using ECommerce.Bl.Contracts.Business;
using MediatR;

namespace ECommerce.Bl.Application.SupportTicket.Queries
{
    public record GetSupportTicketsCountQuery() : IRequest<int>;

    public class GetSupportTicketsCountHandler(ISupportTicket SupportTicketService) : IRequestHandler<GetSupportTicketsCountQuery, int>
    {
        public async Task<int> Handle(GetSupportTicketsCountQuery request, CancellationToken cancellationToken)
        {
            return await SupportTicketService.CountAsync();
        }
    }
}