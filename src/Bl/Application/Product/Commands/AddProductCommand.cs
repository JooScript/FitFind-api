using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Dtos.Business;
using MediatR;

namespace ECommerce.Bl.Application.Product.Commands
{
    public record AddProductCommand(ProductDto Product) : IRequest<Guid>;

    public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProduct _productService;

        public AddProductHandler(IProduct productService)
        {
            _productService = productService;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.AddAsync(request.Product);
            return result.success ? result.id : Guid.Empty;
        }
    }

}