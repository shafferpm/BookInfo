using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Store
{
    [Key]
    [MaxLength(4)]
    public string StorId { get; set; } = null!;

    public string? StorName { get; set; }

    public string? StorAddress { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } 
        = new List<Sale>();
}
