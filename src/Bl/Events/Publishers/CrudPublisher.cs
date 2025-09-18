using ECommerce.Bl.Contracts.Events;
using ECommerce.Bl.Events.Args;

namespace ECommerce.Bl.Events.Publishers;

public class CrudPublisher : ICrudPublisher
{
    public event EventHandler<EntityCreatedEventArgs>? Created;
    public event EventHandler<EntityStatusChangedEventArgs>? StatusChanged;
    public event EventHandler<EntityUpdatedEventArgs>? Updated;

    public void Publish<TArgs>(TArgs args) where TArgs : CrudEventArgs
    {
        switch (args)
        {
            case EntityCreatedEventArgs created:
                {
                    OnCreated(created);
                    break;
                }

            case EntityUpdatedEventArgs updated:
                {
                    OnUpdated(updated);
                    break;
                }

            case EntityStatusChangedEventArgs deleted:
                {
                    OnStatusChanged(deleted);
                    break;
                }
        }
    }

    protected virtual void OnCreated(EntityCreatedEventArgs e) => Created?.Invoke(this, e);
    protected virtual void OnUpdated(EntityUpdatedEventArgs e) => Updated?.Invoke(this, e);
    protected virtual void OnStatusChanged(EntityStatusChangedEventArgs e) => StatusChanged?.Invoke(this, e);
}