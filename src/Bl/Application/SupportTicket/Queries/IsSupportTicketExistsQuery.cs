using ECommerce.Bl.Contracts.Business;
using MediatR;

namespace ECommerce.Bl.Application.SupportTicket.Queries
{
    public record IsSupportTicketExistsQuery(Guid Id) : IRequest<bool>;

    public class IsSupportTicketExistsHandler : IRequestHandler<IsSupportTicketExistsQuery, bool>
    {
        private readonly ISupportTicket _SupportTicketService;

        public IsSupportTicketExistsHandler(ISupportTicket SupportTicketService)
        {
            _SupportTicketService = SupportTicketService;
        }

        public async Task<bool> Handle(IsSupportTicketExistsQuery request, CancellationToken cancellationToken)
        {
            return await _SupportTicketService.IsExistsAsync(request.Id);
        }

    }
}