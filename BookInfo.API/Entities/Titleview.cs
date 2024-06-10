using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Titleview
{
    [Key]    
    [MaxLength(80)]
    public string Title { get; set; } = null!;

    public byte? AuOrd { get; set; }

    public string AuLname { get; set; }

    public decimal? Price { get; set; }

    public int? YtdSales { get; set; }

    public string? PubId { get; set; }

    public Titleview(string auLname)
    {
        AuLname = auLname;
    }
}
