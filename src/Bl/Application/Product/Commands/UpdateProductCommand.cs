using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Dtos.Business;
using MediatR;

namespace ECommerce.Bl.Application.Product.Commands
{
    public record UpdateProductCommand(Guid Id, ProductDto Product) : IRequest<bool>;

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProduct _productService;

        public UpdateProductHandler(IProduct productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            request.Product.Id = request.Id;
            return await _productService.UpdateAsync(request.Product);
        }
    }
}