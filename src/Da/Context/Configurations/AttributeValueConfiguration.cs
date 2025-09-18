using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class AttributeValueConfiguration : IEntityTypeConfiguration<TbAttributeValue>
{
    public void Configure(EntityTypeBuilder<TbAttributeValue> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Attribute_Value");

        builder.ToTable("TbAttributeValues", "products");

        builder.HasIndex(e => new { e.AttributeId, e.Value }, "UQ_Attribute_&_Value").IsUnique();

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.AttributeId);
        builder.Property(e => e.DisplayOrder).HasDefaultValue(0);
        builder.Property(e => e.Value).HasMaxLength(100);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Attribute)
            .WithMany(p => p.TbAttributeValues)
            .HasForeignKey(d => d.AttributeId)
            .HasConstraintName("FK_AttributeValues_Attribute");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbAttributeValues)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbAttributeValues_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbAttributeValues)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbAttributeValues_UserUpdator");
    }
}