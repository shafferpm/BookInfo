using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Roysched
{
    [Key]
    [MaxLength(6)]
    public string TitleId { get; set; } = null!;

    public int? Lorange { get; set; }

    public int? Hirange { get; set; }

    public int? Royalty { get; set; }

    public virtual Title Title { get; set; } = null!;
}
