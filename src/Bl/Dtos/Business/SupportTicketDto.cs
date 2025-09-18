using ECommerce.Bl.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using static ECommerce.Bl.Enums.Status.Status;
using static ECommerce.Core.Enums.Status;

namespace ECommerce.Bl.Dtos.Business;

public class SupportTicketDto : BaseDto<enSupportTicketState>
{
    [Required(ErrorMessage = "Ticket Subject is required.")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "Subject must be between {2} and {1} characters long.")]
    public string Subject { get; set; } = null!;

    [Required(ErrorMessage = "Ticket Message is required.")]
    [StringLength(5000, MinimumLength = 10, ErrorMessage = "Message must be between {2} and {1} characters long.")]
    [DataType(DataType.MultilineText)]
    public string Message { get; set; } = null!;

    [Required]
    [Range(1, 5, ErrorMessage = "Priority must be set between 1 (Low) and 5 (Critical).")]
    public enPriorityLevel Priority { get; set; } = enPriorityLevel.Medium;
}