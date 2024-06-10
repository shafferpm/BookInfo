using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class TitleauthorDto
{
    public string AuId { get; set; } = null!;

    public string TitleId { get; set; } = null!;

    public byte? AuOrd { get; set; }

    public int? Royaltyper { get; set; }

    public virtual AuthorDto Au { get; set; } = null!;

    public virtual TitleDto Title { get; set; } = null!;
}
