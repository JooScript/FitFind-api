using ECommerce.Domains.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Da.Identity;

public class AppUser : IdentityUser<Guid>
{
    public AppUser() : base() { }

    public AppUser(string userName) : base(userName) { }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateTimeOffset LastLogin { get; set; }

    /// <summary>
    /// Gets or sets the current state of the entity.
    /// Possible values:
    /// 0 = Deleted
    /// 1 = Active
    /// 2 = Inactive
    /// </summary>
    public int CurrentState { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }


    #region Navigation Properties

    public virtual ICollection<TbAddress> TbAddresses { get; set; } = new List<TbAddress>();

    public virtual ICollection<TbAttribute> TbAttributes { get; set; } = new List<TbAttribute>();

    public virtual ICollection<TbCampaign> TbCampaigns { get; set; } = new List<TbCampaign>();

    public virtual ICollection<TbSeoMetum> TbSeoMeta { get; set; } = new List<TbSeoMetum>();

    public virtual ICollection<TbOrderItem> TbOrderItems { get; set; } = new List<TbOrderItem>();

    public virtual ICollection<TbTaxRate> TbTaxRates { get; set; } = new List<TbTaxRate>();

    public virtual ICollection<TbSupplier> TbSuppliers { get; set; } = new List<TbSupplier>();

    public virtual ICollection<TbPayment> TbPayments { get; set; } = new List<TbPayment>();

    public virtual ICollection<TbWishlistItem> TbWishlistItems { get; set; } = new List<TbWishlistItem>();

    public virtual ICollection<TbProductCategoryMapping> TbProductCategoryMappings { get; set; } = new List<TbProductCategoryMapping>();

    public virtual ICollection<TbVariationAttributeMapping> TbVariationAttributeMappings { get; set; } = new List<TbVariationAttributeMapping>();

    public virtual ICollection<TbCampaignProductMapping> TbCampaignProductMappings { get; set; } = new List<TbCampaignProductMapping>();

    public virtual ICollection<TbProductTranslationMapping> TbProductTranslationMappings { get; set; } = new List<TbProductTranslationMapping>();

    public virtual ICollection<TbRefreshToken> TbRefreshTokens { get; set; } = new List<TbRefreshToken>();

    public virtual ICollection<TbTag> TbTags { get; set; } = new List<TbTag>();

    public virtual ICollection<TbVariation> TbVariations { get; set; } = new List<TbVariation>();

    public virtual ICollection<TbPaymentTransaction> TbPaymentTransactions { get; set; } = new List<TbPaymentTransaction>();

    public virtual ICollection<TbImage> TbImages { get; set; } = new List<TbImage>();

    public virtual ICollection<TbMethod> TbMethods { get; set; } = new List<TbMethod>();

    public virtual ICollection<TbShipment> TbShipments { get; set; } = new List<TbShipment>();

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();

    public virtual ICollection<TbProductSupplier> TbProductSuppliers { get; set; } = new List<TbProductSupplier>();

    public virtual ICollection<TbProductTagMapping> TbProductTagMappings { get; set; } = new List<TbProductTagMapping>();

    public virtual ICollection<TbDiscountCategoryMapping> TbDiscountCategoryMappings { get; set; } = new List<TbDiscountCategoryMapping>();

    public virtual ICollection<TbShipmentItemMapping> TbShipmentItemMappings { get; set; } = new List<TbShipmentItemMapping>();

    public virtual ICollection<TbLanguage> TbLanguages { get; set; } = new List<TbLanguage>();

    public virtual ICollection<TbOrderReturn> TbOrderReturns { get; set; } = new List<TbOrderReturn>();

    public virtual ICollection<TbCartItem> TbCartItems { get; set; } = new List<TbCartItem>();

    public virtual ICollection<TbDiscount> TbDiscounts { get; set; } = new List<TbDiscount>();

    public virtual ICollection<TbDiscountProductMapping> TbDiscountProductMappings { get; set; } = new List<TbDiscountProductMapping>();

    public virtual ICollection<TbInvoice> TbInvoices { get; set; } = new List<TbInvoice>();

    public virtual ICollection<TbAttributeValue> TbAttributeValues { get; set; } = new List<TbAttributeValue>();

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

    #endregion

}
