using ECommerce.Bl.Events.Args;

namespace ECommerce.Bl.Contracts.Events;

// Event Bus Interface (optional)
public interface IEventBus
{
    Task PublishAsync(CrudEventArgs @event);
    Task SubscribeAsync<EntityEventArgs, IEventSubscriber>();
}