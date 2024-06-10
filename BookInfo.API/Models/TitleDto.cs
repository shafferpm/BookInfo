using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class TitleDto
{
    public string TitleId { get; set; } = null!;

    public string Title1 { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? PubId { get; set; }

    public decimal? Price { get; set; }

    public decimal? Advance { get; set; }

    public int? Royalty { get; set; }

    public int? YtdSales { get; set; }

    public string? Notes { get; set; }

    public DateTime Pubdate { get; set; }

    public virtual PublisherDto? Pub { get; set; }

    public virtual ICollection<SaleDto> Sales { get; set; } = new List<SaleDto>();

    public virtual ICollection<TitleauthorDto> Titleauthors { get; set; } = new List<TitleauthorDto>();
}
