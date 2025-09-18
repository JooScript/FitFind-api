using ECommerce.Bl.Contracts.Base;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Da.Models;
using ECommerce.Domains.Models;

namespace ECommerce.Bl.Contracts.Business;

public interface IProduct : IBaseService<TbProduct, ProductDto>
{
    Task<PagedResult<ProductDto>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50);
}
