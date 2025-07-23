using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public DateTimeOffset LastLogin { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbAddress> TbAddresses { get; set; } = new List<TbAddress>();

    public virtual ICollection<TbAuditLog> TbAuditLogs { get; set; } = new List<TbAuditLog>();

    public virtual ICollection<TbCategory> TbCategories { get; set; } = new List<TbCategory>();

    public virtual ICollection<TbInventoryTransaction> TbInventoryTransactions { get; set; } = new List<TbInventoryTransaction>();

    public virtual ICollection<TbOrderStatusHistory> TbOrderStatusHistories { get; set; } = new List<TbOrderStatusHistory>();

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();

    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();

    public virtual ICollection<TbShoppingCart> TbShoppingCarts { get; set; } = new List<TbShoppingCart>();

    public virtual ICollection<TbSubscription> TbSubscriptions { get; set; } = new List<TbSubscription>();

    public virtual ICollection<TbSupportTicket> TbSupportTickets { get; set; } = new List<TbSupportTicket>();

    public virtual ICollection<TbTicketReply> TbTicketReplies { get; set; } = new List<TbTicketReply>();

    public virtual ICollection<TbUserActivity> TbUserActivities { get; set; } = new List<TbUserActivity>();

    public virtual ICollection<TbWishlist> TbWishlists { get; set; } = new List<TbWishlist>();

}
