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

public class ProductService(ITableRepoQry<TbProduct> repoQuery, ITableRepoCmd<TbProduct> repoCommand, IMapper mapper, IUserServiceQry userServiceQuery, ICrudPublisher publisher) : BaseService<TbProduct, ProductDto>(repoQuery, repoCommand, mapper, userServiceQuery, publisher), IProduct
{
    public async Task<PagedResult<ProductDto>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
    {
        return await repoQuery.GetPagedListAsync(
             pageNumber,
             pageSize,
             filter: (e => e.CurrentState > 0),
             selector: p => mapper.Map<ProductDto>(p),
             orderBy: null,
             isDescending: false,
             cancellationToken: default);
    }
}