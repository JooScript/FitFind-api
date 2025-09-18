using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Dtos.Business;
using MediatR;

namespace ECommerce.Bl.Application.SupportTicket.Queries
{
    public record GetSupportTicketByIdQuery(Guid Id) : IRequest<SupportTicketDto?>;

    public class GetSupportTicketByIdHandler : IRequestHandler<GetSupportTicketByIdQuery, SupportTicketDto?>
    {
        private readonly ISupportTicket _SupportTicketService;

        public GetSupportTicketByIdHandler(ISupportTicket SupportTicketService)
        {
            _SupportTicketService = SupportTicketService;
        }

        public async Task<SupportTicketDto?> Handle(GetSupportTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _SupportTicketService.GetByIdAsync(request.Id);
        }
    }
}