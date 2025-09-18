

namespace ECommerce.Core.Enums;

public class Status
{
    /// <summary>
    /// Represents the priority level of a support ticket.
    /// </summary>
    public enum enPriorityLevel : int
    {
        /// <summary>
        /// Low priority issue. Minimal business impact.
        /// </summary>
        Low = 1,

        /// <summary>
        /// Medium priority issue. Moderate business impact.
        /// </summary>
        Medium = 2,

        /// <summary>
        /// High priority issue. Significant business impact.
        /// </summary>
        High = 3,

        /// <summary>
        /// Urgent issue. Critical business impact requiring immediate attention.
        /// </summary>
        Urgent = 4,

        /// <summary>
        /// Critical system-down issue. Requires all-hands-on-deck resolution.
        /// </summary>
        Critical = 5
    }
}
