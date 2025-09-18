using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<TbInvoice>
{
    public void Configure(EntityTypeBuilder<TbInvoice> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Invoices");

        builder.ToTable("TbInvoices", "orders");

        builder.HasIndex(e => e.InvoiceNumber, "UQ_Invoices").IsUnique();

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.DueDate);
        builder.Property(e => e.InvoiceNumber)
            .HasMaxLength(50);
        builder.Property(e => e.IssuedDate)
            .HasDefaultValueSql("(sysdatetimeoffset())");

        builder.Property(e => e.OrderId);

        builder.Property(e => e.TaxAmount)

            .HasColumnType("decimal(12, 2)");

        builder.Property(e => e.TotalAmount)
            .HasColumnType("decimal(12, 2)");

        builder.Property(e => e.CurrentState)
            .HasDefaultValue(1);

        builder.HasOne(d => d.Order)
            .WithMany(p => p.TbInvoices)
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("FK_Invoices_Order");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbInvoices)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbInvoices_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbInvoices)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbInvoices_UserUpdator");

    }
}