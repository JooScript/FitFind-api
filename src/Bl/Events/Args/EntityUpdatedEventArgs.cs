using ECommerce.Domains.Base;
using static ECommerce.Bl.Enums.Events.EntityEnums;

namespace ECommerce.Bl.Events.Args;

public class EntityUpdatedEventArgs : CrudEventArgs
{
    public BaseTable OriginalEntity { get; }

    public EntityUpdatedEventArgs(BaseTable entity, Guid userId, BaseTable originalEntity) : base(entity, userId)
    {
        Operation = enCrudOp.Update;
        OriginalEntity = originalEntity;
    }

}
