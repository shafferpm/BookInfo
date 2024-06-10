using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class StoreDto
{
    public string StorId { get; set; } = null!;

    public string? StorName { get; set; }

    public string? StorAddress { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public virtual ICollection<SaleDto> Sales { get; set; } = new List<SaleDto>();
}
