namespace ECommerce.Domains.Base;

/// <summary>
/// Provides a base class for entity tables with common audit properties.
/// Implements <see cref="IBaseTable<enCurrentState>"/> interface.
/// </summary>
/// <remarks>
/// This class serves as a foundation for entity models, including standard audit fields
/// and state tracking functionality.
/// </remarks>
public abstract class BaseTable
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    /// <value>
    /// A <see cref="Guid"/> that uniquely identifies the entity.
    /// </value>
    public Guid Id { get; set; }

    public int CurrentState { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    /// <value>
    /// A <see cref="DateTimeOffset"/> representing the creation timestamp with timezone offset.
    /// </value>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who created the entity.
    /// </summary>
    /// <value>
    /// A <see cref="Guid"/> representing the creator of the entity.
    /// </value>
    public Guid CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    /// <value>
    /// A nullable <see cref="DateTimeOffset"/> representing the last modification timestamp with timezone offset.
    /// Null indicates the entity hasn't been updated since creation.
    /// </value>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who last updated the entity.
    /// </summary>
    /// <value>
    /// A nullable <see cref="Guid"/> representing the user who last modified the entity.
    /// Null indicates the entity hasn't been updated since creation.
    /// </value>
    public Guid? UpdatedBy { get; set; }

}