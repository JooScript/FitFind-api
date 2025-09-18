using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Da.Models;
using MediatR;

namespace ECommerce.Bl.Application.Product.Queries
{
    public record GetAllProductsQuery(int PageNumber, int PageSize) : IRequest<PagedResult<ProductDto>>;

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PagedResult<ProductDto>>
    {
        private readonly IProduct _productService;

        public GetAllProductsHandler(IProduct productService)
        {
            _productService = productService;
        }

        public async Task<PagedResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetPagedListAsync(request.PageNumber, request.PageSize);
        }
    }
}