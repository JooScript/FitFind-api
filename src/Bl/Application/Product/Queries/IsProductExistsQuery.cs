using ECommerce.Bl.Contracts.Business;
using MediatR;

namespace ECommerce.Bl.Application.Product.Queries
{
    public record IsProductExistsQuery(Guid Id) : IRequest<bool>;

    public class IsProductExistsHandler : IRequestHandler<IsProductExistsQuery, bool>
    {
        private readonly IProduct _productService;

        public IsProductExistsHandler(IProduct productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(IsProductExistsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.IsExistsAsync(request.Id);
        }

    }
}