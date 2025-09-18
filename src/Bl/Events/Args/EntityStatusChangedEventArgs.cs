using ECommerce.Domains.Base;
using static ECommerce.Bl.Enums.Events.EntityEnums;

namespace ECommerce.Bl.Events.Args;

public class EntityStatusChangedEventArgs : CrudEventArgs
{
    public int PreviousState { get; set; }
    public int NewState { get; set; }

    public EntityStatusChangedEventArgs(BaseTable entity, Guid userId, int previousState, int newState) : base(entity, userId)
    {
        Operation = enCrudOp.ChangeState;
        PreviousState = previousState;
        NewState = newState;
    }
}
