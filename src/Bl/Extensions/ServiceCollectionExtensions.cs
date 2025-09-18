using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Bl.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection _services)
    {
        _services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
    }
}
