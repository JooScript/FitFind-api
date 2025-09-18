using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Dtos.Business;
using MediatR;

namespace ECommerce.Bl.Application.SupportTicket.Commands
{
    public record AddSupportTicketCommand(SupportTicketDto SupportTicket) : IRequest<Guid>;

    public class AddSupportTicketHandler : IRequestHandler<AddSupportTicketCommand, Guid>
    {
        private readonly ISupportTicket _SupportTicketService;

        public AddSupportTicketHandler(ISupportTicket SupportTicketService)
        {
            _SupportTicketService = SupportTicketService;
        }

        public async Task<Guid> Handle(AddSupportTicketCommand request, CancellationToken cancellationToken)
        {
            var result = await _SupportTicketService.AddAsync(request.SupportTicket);
            return result.success ? result.id : Guid.Empty;
        }
    }

}