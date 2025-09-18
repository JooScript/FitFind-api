using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Dtos.Business;
using MediatR;

namespace ECommerce.Bl.Application.Product.Queries
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProduct _productService;

        public GetProductByIdHandler(IProduct productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetByIdAsync(request.Id);
        }
    }
}