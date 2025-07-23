using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbLanguage
{
    public int Id { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string? Name { get; set; }

    public bool? IsDefault { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbProductTranslationMapping> TbProductTranslationMappings { get; set; } = new List<TbProductTranslationMapping>();
}
