using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class SaleDto
{
    public string StorId { get; set; } = null!;

    public string OrdNum { get; set; } = null!;

    public DateTime OrdDate { get; set; }

    public short Qty { get; set; }

    public string Payterms { get; set; } = null!;

    public string TitleId { get; set; } = null!;

    public virtual StoreDto Stor { get; set; } = null!;

    public virtual TitleDto Title { get; set; } = null!;
}
