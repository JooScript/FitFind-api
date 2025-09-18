using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ProductTranslationMappingConfiguration : IEntityTypeConfiguration<TbProductTranslationMapping>
{
    public void Configure(EntityTypeBuilder<TbProductTranslationMapping> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_tb_product_translations");

        builder.ToTable("TbProductTranslationMappings", "products");

        builder.HasIndex(e => e.LanguageId, "IX_tb_product_translation_mapping_language_id");

        builder.HasIndex(e => e.ProductId, "IX_tb_product_translation_mapping_product_id");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Description);
        builder.Property(e => e.LanguageId);
        builder.Property(e => e.Name)
            .HasMaxLength(100);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.ShortDescription)
            .HasMaxLength(255);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Language)
            .WithMany(p => p.TbProductTranslationMappings)
            .HasForeignKey(d => d.LanguageId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductTranslationMappings_Language");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.TbProductTranslationMappings)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductTranslationMappings_Product");





        builder.HasOne<AppUser>()
.WithMany(p => p.TbProductTranslationMappings)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbProductTranslationMappings_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbProductTranslationMappings)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbProductTranslationMappings_UserUpdator");



    }
}