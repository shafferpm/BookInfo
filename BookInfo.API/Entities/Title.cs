using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Title
{
    [Key]
    [MaxLength(6)]
    public string TitleId { get; set; } = null!;

    [Required]
    [MaxLength(80)]
    public string Title1 { get; set; } = null!;

    [Required]
    [MaxLength(12)]
    public string Type { get; set; } = null!;

    public string? PubId { get; set; }

    public decimal? Price { get; set; }

    public decimal? Advance { get; set; }

    public int? Royalty { get; set; }

    public int? YtdSales { get; set; }

    public string? Notes { get; set; }

    [Required]
    public DateTime Pubdate { get; set; }

    public virtual Publisher? Pub { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } 
        = new List<Sale>();

    public virtual ICollection<Titleauthor> Titleauthors { get; set; } 
        = new List<Titleauthor>();

    public Title(string Title1, string Type)
    {
        this.Title1 = Title1;
        this.Type = Type;
    }
}
