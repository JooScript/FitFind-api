using ECommerce.Bl.Contracts.Events;

namespace ECommerce.Api.Middlewares;

public class EventsSubscriptionMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, ICrudPublisher publisher, IAuditLogSubscriber subscriber)
    {
        subscriber.Subscribe(publisher);
        await next(context);
    }
}