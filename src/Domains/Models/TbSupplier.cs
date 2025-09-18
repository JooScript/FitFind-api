using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbSupplier :BaseTable
{
    public string Name { get; set; } = null!;

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<TbProductSupplier> TbProductSuppliers { get; set; } = new List<TbProductSupplier>();
}
