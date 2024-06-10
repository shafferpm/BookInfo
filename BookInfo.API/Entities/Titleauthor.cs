using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Titleauthor
{
    [Key]
    [MaxLength(11)]
    public string AuId { get; set; } = null!;

    [Required]
    [MaxLength(6)]
    public string TitleId { get; set; }

    public byte? AuOrd { get; set; }

    public int? Royaltyper { get; set; }

    [ForeignKey("AuId")]
    public virtual Author Au { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;

    public Titleauthor(string titleId)
    {
        TitleId = titleId;
    }
}
