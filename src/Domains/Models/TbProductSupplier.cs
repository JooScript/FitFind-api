using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbProductSupplier :BaseTable
{
    public Guid ProductId { get; set; }

    public Guid SupplierId { get; set; }

    public decimal CostPrice { get; set; }

    public int? LeadTimeDays { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual TbProduct Product { get; set; } = null!;

    public virtual TbSupplier Supplier { get; set; } = null!;
}
