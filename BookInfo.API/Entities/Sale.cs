using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Sale
{
    [Key]
    [MaxLength(4)]
    public string StorId { get; set; }

    [Required]
    [MaxLength(20)]
    public string OrdNum { get; set; }

    [Required]
    public DateTime OrdDate { get; set; }

    [Required]
    public short Qty { get; set; }

    [Required]
    [MaxLength(12)]
    public string Payterms { get; set; }

    [Required]
    [MaxLength(6)]
    public string TitleId { get; set; }

    public virtual Store Stor { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;

    public Sale(string StorId, string OrdNum, string Payterms, string TitleId)
    {
        this.StorId = StorId;
        this.OrdNum = OrdNum;
        this.Payterms = Payterms;
        this.TitleId = TitleId;
    }
}
