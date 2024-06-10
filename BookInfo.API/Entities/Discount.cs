using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Discount
{
    [Key]
    [MaxLength(40)]
    public string Discounttype { get; set; }

    public string? StorId { get; set; }

    public short? Lowqty { get; set; }

    public short? Highqty { get; set; }

    public decimal Discount1 { get; set; }

    public virtual Store? Stor { get; set; }

    public Discount(string Discounttype)
    {
        this.Discounttype = Discounttype;
    }
}
