using static ECommerce.Bl.Enums.Status.Status;

namespace ECommerce.Bl.Dtos.Base;

/// <summary>
/// Base Data Transfer Object (DTO) containing common properties for all entities.
/// </summary>
public abstract class BaseDto<TState> where TState : Enum
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    /// <example>"3fa85f64-5717-4562-b3fc-2c963f66afa6"</example>
    public Guid Id { get; set; }

    public TState CurrentState { get; set; }
}