using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbTag :BaseTable
{
    public string Name { get; set; } = null!;

    public virtual ICollection<TbProductTagMapping> TbProductTagMappings { get; set; } = new List<TbProductTagMapping>();
}
