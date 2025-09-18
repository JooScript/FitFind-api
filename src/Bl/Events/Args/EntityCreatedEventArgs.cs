using ECommerce.Domains.Base;
using static ECommerce.Bl.Enums.Events.EntityEnums;

namespace ECommerce.Bl.Events.Args;

public class EntityCreatedEventArgs : CrudEventArgs
{
    public EntityCreatedEventArgs(BaseTable entity, Guid userId) : base(entity, userId)
    {
        Operation = enCrudOp.Create;
    }
}
