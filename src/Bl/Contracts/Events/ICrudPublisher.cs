using ECommerce.Bl.Events.Args;

namespace ECommerce.Bl.Contracts.Events;

public interface ICrudPublisher

{
    //// Primary channel-based publishing
    //ValueTask PublishAsync(DomainEventArgs @event, CancellationToken ct = default);

    //// Direct sync publishing (optional fallback)
    //Task PublishDirectAsync(DomainEventArgs @event);

    //// Required channel access
    //ChannelWriter<DomainEventArgs> ChannelWriter { get; }

    event EventHandler<EntityCreatedEventArgs>? Created;
    event EventHandler<EntityStatusChangedEventArgs>? StatusChanged;
    event EventHandler<EntityUpdatedEventArgs>? Updated;

    void Publish<TArgs>(TArgs args) where TArgs : CrudEventArgs;

}