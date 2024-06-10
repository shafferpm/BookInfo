using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class PubInfoDto
{
    public string PubId { get; set; } = null!;

    public byte[]? Logo { get; set; }

    public string? PrInfo { get; set; }

    public virtual PublisherDto Pub { get; set; } = null!;
}
