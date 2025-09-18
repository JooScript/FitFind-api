using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbLanguage :BaseTable
{
    public string LanguageCode { get; set; } = null!;

    public string? Name { get; set; }

    public bool? IsDefault { get; set; }

    public virtual ICollection<TbProductTranslationMapping> TbProductTranslationMappings { get; set; } = new List<TbProductTranslationMapping>();
}
