using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookInfo.API.Entities;

public class Author
{
    [Key]
    [MaxLength(11)]
    public string AuId { get; set; }

    [Required]
    [MaxLength(40)]
    public string AuLname { get; set; }

    [Required]
    [MaxLength(20)]
    public string AuFname { get; set; }

    [Required]
    [MaxLength(12)]
    public string Phone { get; set; }

    [MaxLength(40)]
    public string? Address { get; set; }

    [MaxLength(20)]
    public string? City { get; set; }

    [MaxLength(2)]
    public string? State { get; set; }

    [MaxLength(5)]
    public string? Zip { get; set; }

    [Required]
    public bool Contract { get; set; }

    public virtual ICollection<Titleauthor> Titleauthors { get; set; } 
        = new List<Titleauthor>();

    public Author(string AuId,
    string AuLname,
    string AuFname,
    string Phone)
    {
        this.AuId = AuId;
        this.AuLname = AuLname;
        this.AuFname = AuFname;
        this.Phone = Phone;
    }
}
