using ECommerce.Bl.Contracts.Business;
using MediatR;

namespace ECommerce.Bl.Application.Product.Commands
{
    public record DeleteProductCommand(Guid Id) : IRequest<bool>;

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProduct _productService;

        public DeleteProductHandler(IProduct productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.DeleteAsync(request.Id);
        }
    }
}