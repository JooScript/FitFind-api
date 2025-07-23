using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ECommerce.Da;

public partial class ECommerceContext : IdentityDbContext<AppUser>
{
    public ECommerceContext()
    {
    }

    public ECommerceContext(DbContextOptions<ECommerceContext> options)
        : base(options)
    {
    }

    #region DbSets Props

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

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(200);
        configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2");
        // configurationBuilder.Properties<decimal>().HasColumnType("decimal(18,2)");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TbAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Addresses");

            entity.ToTable("TbAddresses", "core");

            entity.Property(e => e.Id)
                .HasColumnName("Id");
            entity.Property(e => e.AddressType)
                .HasMaxLength(20)
                .HasColumnName("AddressType");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("City");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("Country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("CreatedAt");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(false)
                .HasColumnName("IsDefault");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("PostalCode");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("State");
            entity.Property(e => e.StreetAddress1)
                .HasMaxLength(100)
                .HasColumnName("StreetAddress1");
            entity.Property(e => e.StreetAddress2)
                .HasMaxLength(100)
                .HasColumnName("StreetAddress2");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("UpdatedAt");
            entity.Property(e => e.UserId)
                .HasColumnName("UserId");
            entity.Property(e => e.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            entity.HasOne(d => d.User)
                .WithMany(p => p.TbAddresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Addresses_User");
        });

        modelBuilder.Entity<TbAttribute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Attributes");

            entity.ToTable("TbAttributes", "products");

            entity.HasIndex(e => e.Name, "UQ_AttributeName").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("Name");
            entity.Property(e => e.Description).HasColumnName("Description");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

        });

        modelBuilder.Entity<TbAttributeValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Attribute_Value");

            entity.ToTable("TbAttributeValues", "products");

            entity.HasIndex(e => new { e.AttributeId, e.Value }, "UQ_Attribute_&_Value").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.AttributeId).HasColumnName("AttributeId");
            entity.Property(e => e.DisplayOrder).HasDefaultValue(0).HasColumnName("DisplayOrder");
            entity.Property(e => e.Value).HasMaxLength(100).HasColumnName("Value");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Attribute)
                .WithMany(p => p.TbAttributeValues)
                .HasForeignKey(d => d.AttributeId)
                .HasConstraintName("FK_AttributeValues_Attribute");
        });

        modelBuilder.Entity<TbAuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AuditLogs");

            entity.ToTable("TbAuditLogs", "core");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.Details).HasColumnName("Details");
            entity.Property(e => e.Entity)
                .HasMaxLength(100)
                .HasColumnName("entity");
            entity.Property(e => e.EntityId).HasColumnName("EntityId");
            entity.Property(e => e.LogDate)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("log_date");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.Property(e => e.UserId).HasColumnName("UserId");

            entity.HasOne(d => d.User)
                  .WithMany(p => p.TbAuditLogs)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("FK_AuditLogs_User");
        });

        modelBuilder.Entity<TbCampaign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Campaigns");

            entity.ToTable("TbCampaigns", "marketing");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Description).HasColumnName("Description");
            entity.Property(e => e.EndDate).HasColumnName("EndDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("IsActive");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("Name");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            entity.Property(e => e.StartDate).HasColumnName("StartDate");
        });

        modelBuilder.Entity<TbCampaignProductMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_campaign_products");

            entity.ToTable("TbCampaignProductMappings", "marketing");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CampaignId).HasColumnName("CampaignId");
            entity.Property(e => e.ProductId).HasColumnName("ProductId");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbCartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cart_Items");

            entity.ToTable("TbCartItems", "customers");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("AddedAt");
            entity.Property(e => e.CartId).HasColumnName("CartId");
            entity.Property(e => e.ProductId).HasColumnName("ProductId");
            entity.Property(e => e.Quantity).HasColumnName("Quantity");
            entity.Property(e => e.VariationId).HasColumnName("VariationId");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Cart).WithMany(p => p.TbCartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_CartItems_Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.TbCartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_CartItems_Product");

            entity.HasOne(d => d.Variation).WithMany(p => p.TbCartItems)
                .HasForeignKey(d => d.VariationId)
                .HasConstraintName("FK_CartItems_Variation");
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Category");

            entity.ToTable("TbCategories", "products");

            entity.HasIndex(e => e.Slug, "UQ_Category_Slug").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Description).HasColumnName("Description");
            entity.Property(e => e.DisplayOrder)
                .HasDefaultValue(0)
                .HasColumnName("DisplayOrder");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("IsActive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("Name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryId");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("Slug");
            entity.Property(e => e.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            entity.HasOne(d => d.User)
               .WithMany(p => p.TbCategories)
               .HasForeignKey(d => d.ModifiedBy)
               .HasConstraintName("FK_Categories_User");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK_InverseParentCategories_ParentCategory");
        });

        modelBuilder.Entity<TbDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Discount");

            entity.ToTable("TbDiscounts", "marketing");

            entity.HasIndex(e => e.Code, "UQ_Discount").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Amount");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("Code");
            entity.Property(e => e.CurrentUses)
                .HasDefaultValue(0)
                .HasColumnName("CurrentUses");
            entity.Property(e => e.Description).HasColumnName("Description");
            entity.Property(e => e.DiscountType)
                .HasMaxLength(20)
                .HasColumnName("DiscountType");
            entity.Property(e => e.EndDate).HasColumnName("EndDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("IsActive");
            entity.Property(e => e.IsSingleUse)
                .HasDefaultValue(false)
                .HasColumnName("IsSingleUse");
            entity.Property(e => e.MaxUses).HasColumnName("MaxUses");
            entity.Property(e => e.MinOrderAmount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("MinOrderAmount");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("Name");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.Property(e => e.StartDate).HasColumnName("StartDate");
        });

        modelBuilder.Entity<TbDiscountCategoryMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_discount_categories");

            entity.ToTable("TbDiscountCategoryMappings", "marketing");

            entity.HasIndex(e => e.CategoryId, "IX_tb_discount_category_mapping_category_id");

            entity.HasIndex(e => e.DiscountId, "IX_tb_discount_category_mapping_discount_id");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Category).WithMany(p => p.TbDiscountCategoryMappings)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__discount___categ__2BFE89A6");

            entity.HasOne(d => d.Discount).WithMany(p => p.TbDiscountCategoryMappings)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__discount___disco__2B0A656D");
        });

        modelBuilder.Entity<TbDiscountProductMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_discount_products");

            entity.ToTable("TbDiscountProductMappings", "marketing");

            entity.HasIndex(e => e.DiscountId, "IX_tb_discount_product_mapping_discount_id");

            entity.HasIndex(e => e.ProductId, "IX_tb_discount_product_mapping_product_id");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Discount)
                .WithMany(p => p.TbDiscountProductMappings)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__discount___disco__2739D489");

            entity.HasOne(d => d.Product).WithMany(p => p.TbDiscountProductMappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__discount___produ__282DF8C2");
        });

        modelBuilder.Entity<TbImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__images__DC9AC955C10A25A0");

            entity.ToTable("TbImages", "products");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.AltText)
                .HasMaxLength(100)
                .HasColumnName("AltText");
            entity.Property(e => e.DisplayOrder)
                .HasDefaultValue(0)
                .HasColumnName("DisplayOrder");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValue(false)
                .HasColumnName("is_primary");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.TbImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__images__product___59063A47");
        });

        modelBuilder.Entity<TbInventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__inventor__85C600AF8DFDE60A");

            entity.ToTable("TbInventoryTransactions", "inventory");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.QuantityChange).HasColumnName("quantity_change");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(50)
                .HasColumnName("reference_type");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .HasColumnName("transaction_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VariationId).HasColumnName("variation_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.TbInventoryTransactions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__inventory__produ__4E53A1AA");

            entity.HasOne(d => d.User).WithMany(p => p.TbInventoryTransactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__inventory__user___5224328E");

            entity.HasOne(d => d.Variation).WithMany(p => p.TbInventoryTransactions)
                .HasForeignKey(d => d.VariationId)
                .HasConstraintName("FK__inventory__varia__4F47C5E3");
        });

        modelBuilder.Entity<TbInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__invoices__F58DFD49D1BB3566");

            entity.ToTable("TbInvoices", "orders");

            entity.HasIndex(e => e.InvoiceNumber, "UQ__invoices__8081A63AF3DA1EA1").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .HasColumnName("invoice_number");
            entity.Property(e => e.IssuedDate)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("issued_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("tax_amount");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Order).WithMany(p => p.TbInvoices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__invoices__order___6CD828CA");
        });

        modelBuilder.Entity<TbLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Languages"); ;

            entity.ToTable("TbLanguages", "core");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(false)
                .HasColumnName("is_default");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(10)
                .HasColumnName("language_code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Methods");

            entity.ToTable("TbMethods", "shipping");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CalculationMethod)
                .HasMaxLength(20)
                .HasColumnName("calculation_method");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__4659622900F7E894");

            entity.ToTable("TbOrders", "orders");

            entity.HasIndex(e => e.UserId, "idx_orders_user_id");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.BillingAddressId).HasColumnName("billing_address_id");
            entity.Property(e => e.DiscountAmount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("discount_amount");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(50)
                .HasColumnName("order_number");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .HasColumnName("order_status");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.ShippingAddressId).HasColumnName("shipping_address_id");
            entity.Property(e => e.ShippingAmount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("shipping_amount");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(50)
                .HasColumnName("shipping_method");
            entity.Property(e => e.TaxAmount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("tax_amount");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.TbOrderBillingAddresses)
                .HasForeignKey(d => d.BillingAddressId)
                .HasConstraintName("FK__orders__billing___778AC167");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.TbOrderShippingAddresses)
                .HasForeignKey(d => d.ShippingAddressId)
                .HasConstraintName("FK__orders__shipping__787EE5A0");

            entity.HasOne(d => d.User).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__orders__user_id__71D1E811");
        });

        modelBuilder.Entity<TbOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_it__3764B6BCBA7EA358");

            entity.ToTable("TbOrderItems", "orders");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.DiscountAmount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("discount_amount");
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(20)
                .HasColumnName("item_status");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TaxAmount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("tax_amount");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("unit_price");
            entity.Property(e => e.VariationId).HasColumnName("variation_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Order).WithMany(p => p.TbOrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__order_ite__order__7B5B524B");

            entity.HasOne(d => d.Product).WithMany(p => p.TbOrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__order_ite__produ__7C4F7684");

            entity.HasOne(d => d.Variation).WithMany(p => p.TbOrderItems)
                .HasForeignKey(d => d.VariationId)
                .HasConstraintName("FK__order_ite__varia__7D439ABD");
        });

        modelBuilder.Entity<TbOrderReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__returns__35C23473EFD75761");

            entity.ToTable("TbOrderReturns", "orders");

            entity.HasIndex(e => e.OrderItemId, "IX_tb_order_returns_order_item_id");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.ProcessedAt).HasColumnName("processed_at");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.Property(e => e.RequestedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("requested_at");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.OrderItem).WithMany(p => p.TbOrderReturns)
                .HasForeignKey(d => d.OrderItemId)
                .HasConstraintName("FK__returns__order_i__671F4F74");
        });

        modelBuilder.Entity<TbOrderStatusHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_st__096AA2E90118DDC9");

            entity.ToTable("TbOrderStatusHistories", "orders");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.StatusDate)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("status_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Order).WithMany(p => p.TbOrderStatusHistories)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__order_sta__order__02FC7413");

            entity.HasOne(d => d.User).WithMany(p => p.TbOrderStatusHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__order_sta__user___04E4BC85");
        });

        modelBuilder.Entity<TbPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payments__ED1FC9EA68D0DEAF");

            entity.ToTable("TbPayments", "payments");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BillingAddressId).HasColumnName("billing_address_id");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .HasDefaultValue("USD")
                .HasColumnName("currency");
            entity.Property(e => e.GatewayResponse).HasColumnName("gateway_response");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .HasColumnName("payment_status");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("transaction_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.TbPayments)
                .HasForeignKey(d => d.BillingAddressId)
                .HasConstraintName("FK__payments__billin__0B91BA14");

            entity.HasOne(d => d.Order).WithMany(p => p.TbPayments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__payments__order___07C12930");
        });

        modelBuilder.Entity<TbPaymentTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment___85C600AFA1BB98D9");

            entity.ToTable("TbPaymentTransactions", "payments");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.GatewayTransactionId)
                .HasMaxLength(100)
                .HasColumnName("gateway_transaction_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.ResponseCode)
                .HasMaxLength(20)
                .HasColumnName("response_code");
            entity.Property(e => e.ResponseMessage).HasColumnName("response_message");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .HasColumnName("transaction_type");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Payment).WithMany(p => p.TbPaymentTransactions)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__payment_t__payme__0E6E26BF");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__47027DF55CAF7E08");

            entity.ToTable("TbProducts", "products");

            entity.HasIndex(e => e.Sku, "UQ__products__DDDF4BE71C9483E5").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CostPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cost_price");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("height");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDigital)
                .HasDefaultValue(false)
                .HasColumnName("is_digital");
            entity.Property(e => e.Length)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("length");
            entity.Property(e => e.LowStockThreshold)
                .HasDefaultValue(5)
                .HasColumnName("low_stock_threshold");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(255)
                .HasColumnName("short_description");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("sku");
            entity.Property(e => e.StockQuantity)
                .HasDefaultValue(0)
                .HasColumnName("stock_quantity");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("updated_at");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("weight");
            entity.Property(e => e.Width)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("width");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbProductCategoryMapping>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TbProductCategoryMappings", "products");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValue(false)
                .HasColumnName("is_primary");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Category).WithMany(p => p.TbProductCategoryMappings)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product_c__categ__5535A963");

            entity.HasOne(d => d.Product).WithMany(p => p.TbProductCategoryMappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product_c__produ__5441852A");
        });

        modelBuilder.Entity<TbProductSupplier>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TbProductSuppliers", "inventory");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CostPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cost_price");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValue(false)
                .HasColumnName("is_primary");
            entity.Property(e => e.LeadTimeDays).HasColumnName("lead_time_days");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.TbProductSuppliers)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product_s__produ__57DD0BE4");

            entity.HasOne(d => d.Supplier).WithMany(p => p.TbProductSuppliers)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product_s__suppl__58D1301D");
        });

        modelBuilder.Entity<TbProductTagMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_product_tags");

            entity.ToTable("TbProductTagMappings", "products");

            entity.HasIndex(e => e.ProductId, "IX_tb_product_tag_mapping_product_id");

            entity.HasIndex(e => e.TagId, "IX_tb_product_tag_mapping_tag_id");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.TbProductTagMappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product_t__produ__73852659");

            entity.HasOne(d => d.Tag).WithMany(p => p.TbProductTagMappings)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product_t__tag_i__74794A92");


        });

        modelBuilder.Entity<TbProductTranslationMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_product_translations");

            entity.ToTable("TbProductTranslationMappings", "products");

            entity.HasIndex(e => e.LanguageId, "IX_tb_product_translation_mapping_language_id");

            entity.HasIndex(e => e.ProductId, "IX_tb_product_translation_mapping_product_id");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(255)
                .HasColumnName("short_description");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Language).WithMany(p => p.TbProductTranslationMappings)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_product_translations_tb_languages");

            entity.HasOne(d => d.Product).WithMany(p => p.TbProductTranslationMappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product_t__produ__0B5CAFEA");
        });

        modelBuilder.Entity<TbReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reviews__60883D90FEF6BE02");

            entity.ToTable("TbReviews", "customers");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasColumnName("is_approved");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("review_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__reviews__product__32AB8735");

            entity.HasOne(d => d.User).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__reviews__user_id__339FAB6E");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbSeoMetum>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TbSeoMeta", "products");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CanonicalUrl)
                .HasMaxLength(255)
                .HasColumnName("canonical_url");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(255)
                .HasColumnName("meta_description");
            entity.Property(e => e.MetaKeywords)
                .HasMaxLength(255)
                .HasColumnName("meta_keywords");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(100)
                .HasColumnName("meta_title");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.TbSeoMeta)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__seo_meta__produc__7755B73D");
        });

        modelBuilder.Entity<TbShipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shipment__41466E5962A3E801");

            entity.ToTable("TbShipments", "shipping");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.ActualDeliveryDate).HasColumnName("actual_delivery_date");
            entity.Property(e => e.Carrier)
                .HasMaxLength(50)
                .HasColumnName("carrier");
            entity.Property(e => e.EstimatedDeliveryDate).HasColumnName("estimated_delivery_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ShipmentDate).HasColumnName("shipment_date");
            entity.Property(e => e.ShipmentStatus)
                .HasMaxLength(20)
                .HasColumnName("shipment_status");
            entity.Property(e => e.ShippingCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("shipping_cost");
            entity.Property(e => e.ShippingMethodId).HasColumnName("shipping_method_id");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(100)
                .HasColumnName("tracking_number");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Order).WithMany(p => p.TbShipments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__shipments__order__17036CC0");

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.TbShipments)
                .HasForeignKey(d => d.ShippingMethodId)
                .HasConstraintName("FK__shipments__shipp__17F790F9");
        });

        modelBuilder.Entity<TbShipmentItemMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shipment__731D6A95F9E9C668");

            entity.ToTable("TbShipmentItemMappings", "shipping");

            entity.HasIndex(e => e.OrderItemId, "IX_tb_shipment_item_mapping_order_item_id");

            entity.HasIndex(e => e.ShipmentId, "IX_tb_shipment_item_mapping_shipment_id");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ShipmentId).HasColumnName("shipment_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.OrderItem).WithMany(p => p.TbShipmentItemMappings)
                .HasForeignKey(d => d.OrderItemId)
                .HasConstraintName("FK__shipment___order__1CBC4616");

            entity.HasOne(d => d.Shipment).WithMany(p => p.TbShipmentItemMappings)
                .HasForeignKey(d => d.ShipmentId)
                .HasConstraintName("FK__shipment___shipm__1BC821DD");
        });

        modelBuilder.Entity<TbShoppingCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shopping__2EF52A2757A8E06B");

            entity.ToTable("TbShoppingCarts", "customers");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("created_at");
            entity.Property(e => e.SessionId)
                .HasMaxLength(100)
                .HasColumnName("session_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.TbShoppingCarts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__shopping___user___43D61337");
        });

        modelBuilder.Entity<TbSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subscrip__863A7EC1E33CC7B0");

            entity.ToTable("TbSubscriptions", "orders");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("created_at");
            entity.Property(e => e.Frequency)
                .HasMaxLength(20)
                .HasColumnName("frequency");
            entity.Property(e => e.NextBillingDate).HasColumnName("next_billing_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.TbSubscriptions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__subscript__produ__16CE6296");

            entity.HasOne(d => d.User).WithMany(p => p.TbSubscriptions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__subscript__user___15DA3E5D");
        });

        modelBuilder.Entity<TbSupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__6EE594E818AE7C46");

            entity.ToTable("TbSuppliers", "inventory");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .HasColumnName("contact_person");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbSupportTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__support___D596F96B0C17649A");

            entity.ToTable("TbSupportTickets", "core");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("created_at");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(100)
                .HasColumnName("subject");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            entity.HasOne(d => d.User).WithMany(p => p.TbSupportTickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__support_t__user___7A3223E8");
        });

        modelBuilder.Entity<TbTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tags__4296A2B658388606");

            entity.ToTable("TbTags", "products");

            entity.HasIndex(e => e.Name, "UQ__tags__72E12F1BCC2F292B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbTaxRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tax_rate__4B78B333FEE8F069");

            entity.ToTable("TbTaxRates", "marketing");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .HasColumnName("country");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(false)
                .HasColumnName("is_default");
            entity.Property(e => e.Rate)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("rate");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .HasColumnName("state");
            entity.Property(e => e.TaxName)
                .HasMaxLength(50)
                .HasColumnName("tax_name");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .HasColumnName("zip_code");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbTicketReply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ticket_r__EE405698DE1279BE");

            entity.ToTable("TbTicketReplies", "core");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.RepliedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("replied_at");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TbTicketReplies)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__ticket_re__ticke__7FEAFD3E");

            entity.HasOne(d => d.User).WithMany(p => p.TbTicketReplies)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ticket_re__user___00DF2177");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        });

        modelBuilder.Entity<TbUserActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_act__482FBD630BD37819");

            entity.ToTable("TbUserActivities", "core");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.Page)
                .HasMaxLength(255)
                .HasColumnName("page");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.TbUserActivities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__user_acti__user___04AFB25B");

        });

        modelBuilder.Entity<TbVariation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__variatio__B03CFD0A4BE23787");

            entity.ToTable("TbVariations", "products");

            entity.HasIndex(e => e.Sku, "UQ__variatio__DDDF4BE785394C8E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PriceAdjustment)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price_adjustment");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("sku");
            entity.Property(e => e.StockQuantity)
                .HasDefaultValue(0)
                .HasColumnName("stock_quantity");
            entity.Property(e => e.VariationName)
                .HasMaxLength(100)
                .HasColumnName("variation_name");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.TbVariations)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__variation__produ__5EBF139D");
        });

        modelBuilder.Entity<TbVariationAttributeMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_variation_attributes");

            entity.ToTable("TbVariationAttributeMappings", "products");

            entity.HasIndex(e => e.AttributeId, "IX_tb_variation_attribute_mapping_attribute_id");

            entity.HasIndex(e => e.ValueId, "IX_tb_variation_attribute_mapping_value_id");

            entity.HasIndex(e => e.VariationId, "IX_tb_variation_attribute_mapping_variation_id");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.ValueId).HasColumnName("value_id");
            entity.Property(e => e.VariationId).HasColumnName("variation_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Attribute).WithMany(p => p.TbVariationAttributeMappings)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__variation__attri__6D0D32F4");

            entity.HasOne(d => d.Value).WithMany(p => p.TbVariationAttributeMappings)
                .HasForeignKey(d => d.ValueId)
                .HasConstraintName("FK__variation__value__6E01572D");

            entity.HasOne(d => d.Variation).WithMany(p => p.TbVariationAttributeMappings)
                .HasForeignKey(d => d.VariationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__variation__varia__6C190EBB");
        });

        modelBuilder.Entity<TbWishlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Wishlists");

            entity.ToTable("TbWishlists", "customers");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(false)
                .HasColumnName("is_default");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.TbWishlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__wishlists__user___395884C4");
        });

        modelBuilder.Entity<TbWishlistItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Wishlist_Item");

            entity.ToTable("TbWishlistItems", "customers");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("added_at");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.WishlistId).HasColumnName("wishlist_id");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.TbWishlistItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__wishlist___produ__40058253");

            entity.HasOne(d => d.Wishlist).WithMany(p => p.TbWishlistItems)
                .HasForeignKey(d => d.WishlistId)
                .HasConstraintName("FK_WishlistItems_Wishlist");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
