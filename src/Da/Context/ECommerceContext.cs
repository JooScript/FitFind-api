using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.Da.Context;

public partial class ECommerceContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public ECommerceContext() { }

    public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

    #region DbSets

    public virtual DbSet<TbAddress> TbAddresses { get; set; }

    public virtual DbSet<TbAttribute> TbAttributes { get; set; }

    public virtual DbSet<TbAttributeValue> TbAttributeValues { get; set; }

    public virtual DbSet<TbAuditLog> TbAuditLogs { get; set; }

    public virtual DbSet<TbCampaign> TbCampaigns { get; set; }

    public virtual DbSet<TbCampaignProductMapping> TbCampaignProductMappings { get; set; }

    public virtual DbSet<TbCartItem> TbCartItems { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbDiscount> TbDiscounts { get; set; }

    public virtual DbSet<TbDiscountCategoryMapping> TbDiscountCategoryMappings { get; set; }

    public virtual DbSet<TbDiscountProductMapping> TbDiscountProductMappings { get; set; }

    public virtual DbSet<TbImage> TbImages { get; set; }

    public virtual DbSet<TbInventoryTransaction> TbInventoryTransactions { get; set; }

    public virtual DbSet<TbInvoice> TbInvoices { get; set; }

    public virtual DbSet<TbLanguage> TbLanguages { get; set; }

    public virtual DbSet<TbMethod> TbMethods { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderItem> TbOrderItems { get; set; }

    public virtual DbSet<TbOrderReturn> TbOrderReturns { get; set; }

    public virtual DbSet<TbOrderStatusHistory> TbOrderStatusHistories { get; set; }

    public virtual DbSet<TbPayment> TbPayments { get; set; }

    public virtual DbSet<TbPaymentTransaction> TbPaymentTransactions { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbProductCategoryMapping> TbProductCategoryMappings { get; set; }

    public virtual DbSet<TbProductSupplier> TbProductSuppliers { get; set; }

    public virtual DbSet<TbProductTagMapping> TbProductTagMappings { get; set; }

    public virtual DbSet<TbProductTranslationMapping> TbProductTranslationMappings { get; set; }

    public virtual DbSet<TbReview> TbReviews { get; set; }

    public virtual DbSet<TbSeoMetum> TbSeoMeta { get; set; }

    public virtual DbSet<TbShipment> TbShipments { get; set; }

    public virtual DbSet<TbShipmentItemMapping> TbShipmentItemMappings { get; set; }

    public virtual DbSet<TbShoppingCart> TbShoppingCarts { get; set; }

    public virtual DbSet<TbSubscription> TbSubscriptions { get; set; }

    public virtual DbSet<TbSupplier> TbSuppliers { get; set; }

    public virtual DbSet<TbSupportTicket> TbSupportTickets { get; set; }

    public virtual DbSet<TbTag> TbTags { get; set; }

    public virtual DbSet<TbTaxRate> TbTaxRates { get; set; }

    public virtual DbSet<TbTicketReply> TbTicketReplies { get; set; }

    public virtual DbSet<TbUserActivity> TbUserActivities { get; set; }

    public virtual DbSet<TbVariation> TbVariations { get; set; }

    public virtual DbSet<TbVariationAttributeMapping> TbVariationAttributeMappings { get; set; }

    public virtual DbSet<TbWishlist> TbWishlists { get; set; }

    public virtual DbSet<TbWishlistItem> TbWishlistItems { get; set; }

    public virtual DbSet<TbRefreshToken> TbRefreshTokens { get; set; }

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { if (!optionsBuilder.IsConfigured) { } }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100);
        configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
