using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class CampaignProductMappingConfiguration : IEntityTypeConfiguration<TbCampaignProductMapping>
{
    public void Configure(EntityTypeBuilder<TbCampaignProductMapping> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_tb_campaign_products");

        builder.ToTable("TbCampaignProductMappings", "marketing");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CampaignId);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);



        builder.HasOne<AppUser>()
.WithMany(p => p.TbCampaignProductMappings)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbCampaignProductMappings_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbCampaignProductMappings)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbCampaignProductMappings_UserUpdator");



    }
}