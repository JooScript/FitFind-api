using AutoMapper;
using ECommerce.Bl.Contracts.Auth;
using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Contracts.Events;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Bl.Services.Base;
using ECommerce.Da.Contracts;
using ECommerce.Da.Models;
using ECommerce.Domains.Models;

namespace ECommerce.Bl.Services.Business;

public class SupportTicketService(ITableQryRepo<TbSupportTicket> repoQuery, ITableCmdRepo<TbSupportTicket> repoCommand, IMapper mapper, IUserQryService userServiceQuery, ICrudPublisher publisher) : BaseService<TbSupportTicket, SupportTicketDto>(repoQuery, repoCommand, mapper, userServiceQuery, publisher), ISupportTicket
{
    public async Task<PagedResult<SupportTicketDto>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
    {
        return await repoQuery.GetPagedListAsync(
             pageNumber,
             pageSize,
             filter: (e => e.CurrentState > 0),
             selector: p => mapper.Map<SupportTicketDto>(p),
             orderBy: null,
             isDescending: false,
             cancellationToken: default);
    }

}