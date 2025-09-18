using ECommerce.Bl.Contracts.Business;
using MediatR;

namespace ECommerce.Bl.Application.SupportTicket.Commands
{
    public record DeleteSupportTicketCommand(Guid Id) : IRequest<bool>;

    public class DeleteSupportTicketHandler : IRequestHandler<DeleteSupportTicketCommand, bool>
    {
        private readonly ISupportTicket _SupportTicketService;

        public DeleteSupportTicketHandler(ISupportTicket SupportTicketService)
        {
            _SupportTicketService = SupportTicketService;
        }

        public async Task<bool> Handle(DeleteSupportTicketCommand request, CancellationToken cancellationToken)
        {
            return await _SupportTicketService.DeleteAsync(request.Id);
        }
    }
}