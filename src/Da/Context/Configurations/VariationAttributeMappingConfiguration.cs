using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class VariationAttributeMappingConfiguration : IEntityTypeConfiguration<TbVariationAttributeMapping>
{
    public void Configure(EntityTypeBuilder<TbVariationAttributeMapping> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_VariationAttributeMappings");

        builder.ToTable("TbVariationAttributeMappings", "products");

        builder.HasIndex(e => e.AttributeId, "IX_tb_variation_attribute_mapping_attribute_id");

        builder.HasIndex(e => e.ValueId, "IX_tb_variation_attribute_mapping_value_id");

        builder.HasIndex(e => e.VariationId, "IX_tb_variation_attribute_mapping_variation_id");

        builder.Property(e => e.Id)
          .HasDefaultValueSql("NEWSEQUENTIALID()")
          .ValueGeneratedOnAdd();
        builder.Property(e => e.AttributeId);
        builder.Property(e => e.ValueId);
        builder.Property(e => e.VariationId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Attribute).WithMany(p => p.TbVariationAttributeMappings)
            .HasForeignKey(d => d.AttributeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_VariationAttributeMappings_Attribute");

        builder.HasOne(d => d.Value).WithMany(p => p.TbVariationAttributeMappings)
            .HasForeignKey(d => d.ValueId)
            .HasConstraintName("FK_VariationAttributeMappings_Value");

        builder.HasOne(d => d.Variation).WithMany(p => p.TbVariationAttributeMappings)
            .HasForeignKey(d => d.VariationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_VariationAttributeMappings_Variation");


        builder.HasOne<AppUser>()
.WithMany(p => p.TbVariationAttributeMappings)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbVariationAttributeMappings_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbVariationAttributeMappings)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbVariationAttributeMappings_UserUpdator");

    }
}