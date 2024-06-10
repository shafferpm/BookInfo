using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class PubInfo
{
    [Key]
    [MaxLength(4)]
    public string PubId { get; set; } = null!;

    public byte[]? Logo { get; set; }

    public string? PrInfo { get; set; }

    public virtual Publisher Pub { get; set; } = null!;
}
