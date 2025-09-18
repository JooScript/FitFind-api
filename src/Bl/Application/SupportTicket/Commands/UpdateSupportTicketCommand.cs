using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Dtos.Business;
using MediatR;

namespace ECommerce.Bl.Application.SupportTicket.Commands
{
    public record UpdateSupportTicketCommand(Guid Id, SupportTicketDto SupportTicket) : IRequest<bool>;

    public class UpdateSupportTicketHandler : IRequestHandler<UpdateSupportTicketCommand, bool>
    {
        private readonly ISupportTicket _SupportTicketService;

        public UpdateSupportTicketHandler(ISupportTicket SupportTicketService)
        {
            _SupportTicketService = SupportTicketService;
        }

        public async Task<bool> Handle(UpdateSupportTicketCommand request, CancellationToken cancellationToken)
        {
            request.SupportTicket.Id = request.Id;
            return await _SupportTicketService.UpdateAsync(request.SupportTicket);
        }
    }
}