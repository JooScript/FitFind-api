using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class InventoryTransactionConfiguration : IEntityTypeConfiguration<TbInventoryTransaction>
{
    public void Configure(EntityTypeBuilder<TbInventoryTransaction> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_InventoryTransactions");

        builder.ToTable("TbInventoryTransactions", "inventory");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Notes);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.QuantityChange);
        builder.Property(e => e.ReferenceId);
        builder.Property(e => e.ReferenceType)
            .HasMaxLength(50);
        builder.Property(e => e.TransactionDate)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.TransactionType)
            .HasMaxLength(20);
        builder.Property(e => e.UserId);
        builder.Property(e => e.VariationId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Product)
            .WithMany(p => p.TbInventoryTransactions)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_InventoryTransactions_Product");

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbInventoryTransactions)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_InventoryTransactions_User");

        builder.HasOne(d => d.Variation)
            .WithMany(p => p.TbInventoryTransactions)
            .HasForeignKey(d => d.VariationId)
            .HasConstraintName("FK_InventoryTransactions_Variation");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbInventoryTransactions)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbInventoryTransactions_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbInventoryTransactions)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbInventoryTransactions_UserUpdator");

    }
}