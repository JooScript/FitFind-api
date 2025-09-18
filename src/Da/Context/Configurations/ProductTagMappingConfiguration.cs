using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ProductTagMappingConfiguration : IEntityTypeConfiguration<TbProductTagMapping>
{
    public void Configure(EntityTypeBuilder<TbProductTagMapping> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_ProductTags");

        builder.ToTable("TbProductTagMappings", "products");

        builder.HasIndex(e => e.ProductId, "IX_tb_product_tag_mapping_product_id");

        builder.HasIndex(e => e.TagId, "IX_tb_product_tag_mapping_tag_id");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.ProductId);
        builder.Property(e => e.TagId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Product)
            .WithMany(p => p.TbProductTagMappings)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductTagMappings_Product");

        builder.HasOne(d => d.Tag)
            .WithMany(p => p.TbProductTagMappings)
            .HasForeignKey(d => d.TagId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductTagMappings_Tag");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbProductTagMappings)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbProductTagMappings_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbProductTagMappings)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbProductTagMappings_UserUpdator");



    }
}