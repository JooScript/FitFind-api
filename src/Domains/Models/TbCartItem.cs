using ECommerce.Domains.Base;
 



namespace ECommerce.Domains.Models;

public partial class TbCartItem :BaseTable
{
    public Guid? CartId { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? VariationId { get; set; }

    public int Quantity { get; set; }

    public virtual TbShoppingCart? Cart { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual TbVariation? Variation { get; set; }
}
