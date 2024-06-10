using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class RoyschedDto
{
    public string TitleId { get; set; } = null!;

    public int? Lorange { get; set; }

    public int? Hirange { get; set; }

    public int? Royalty { get; set; }

    public virtual TitleDto Title { get; set; } = null!;
}
