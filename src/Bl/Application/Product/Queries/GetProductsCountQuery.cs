using ECommerce.Bl.Contracts.Business;
using MediatR;

namespace ECommerce.Bl.Application.Product.Queries
{
    public record GetProductsCountQuery() : IRequest<int>;

    public class GetProductsCountHandler : IRequestHandler<GetProductsCountQuery, int>
    {
        private readonly IProduct _productService;

        public GetProductsCountHandler(IProduct productService)
        {
            _productService = productService;
        }

        public async Task<int> Handle(GetProductsCountQuery request, CancellationToken cancellationToken)
        {
            return await _productService.CountAsync();
        }
    }
}