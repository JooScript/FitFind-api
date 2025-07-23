using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbProductTranslationMapping
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ShortDescription { get; set; }

    public int LanguageId { get; set; }

    public bool IsDeleted { get; set; }


    public virtual TbLanguage Language { get; set; } = null!;

    public virtual TbProduct Product { get; set; } = null!;
}
