using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbProductTranslationMapping :BaseTable
{
    public Guid ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ShortDescription { get; set; }

    public Guid LanguageId { get; set; }

    public virtual TbLanguage Language { get; set; } = null!;

    public virtual TbProduct Product { get; set; } = null!;
}
