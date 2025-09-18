using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<TbReview>
{
    public void Configure(EntityTypeBuilder<TbReview> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Reviews");

        builder.ToTable("TbReviews", "customers");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Comment);
        builder.Property(e => e.IsApproved)
            .HasDefaultValue(false);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.Rating);
        builder.Property(e => e.ReviewDate)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.Title)
            .HasMaxLength(100);
        builder.Property(e => e.UserId);

        builder.HasOne(d => d.Product)
            .WithMany(p => p.TbReviews)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_Reviews_Product");

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbReviews)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Reviews_User");

        builder.Property(e => e.CurrentState).HasDefaultValue(1);


        builder.HasOne<AppUser>()
.WithMany(p => p.TbReviews)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbReviews_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbReviews)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbReviews_UserUpdator");

    }
}