using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class CampaignConfiguration : IEntityTypeConfiguration<TbCampaign>
{
    public void Configure(EntityTypeBuilder<TbCampaign> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Campaigns");

        builder.ToTable("TbCampaigns", "marketing");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Description);
        builder.Property(e => e.EndDate);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);
        builder.Property(e => e.Name)
            .HasMaxLength(100);
        builder.Property(e => e.StartDate);


        builder.HasOne<AppUser>()
.WithMany(p => p.TbCampaigns)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbCampaigns_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbCampaigns)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbCampaigns_UserUpdator");

    }
}