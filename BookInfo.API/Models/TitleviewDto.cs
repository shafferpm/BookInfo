using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class TitleviewDto
{
    public string Title { get; set; } = null!;

    public byte? AuOrd { get; set; }

    public string AuLname { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? YtdSales { get; set; }

    public string? PubId { get; set; }
}
