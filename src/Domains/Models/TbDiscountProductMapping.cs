using ECommerce.Domains.Base;
 



namespace ECommerce.Domains.Models;

public partial class TbDiscountProductMapping :BaseTable
{
    public Guid DiscountId { get; set; }

    public Guid ProductId { get; set; }

    public virtual TbDiscount Discount { get; set; } = null!;

    public virtual TbProduct Product { get; set; } = null!;
}
