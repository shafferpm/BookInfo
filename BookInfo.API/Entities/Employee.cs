using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Employee
{
    [Key]
    [Required]
    [MaxLength(9)]
    public string EmpId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Fname { get; set; }

    public string? Minit { get; set; }

    [Required]
    [MaxLength(30)]
    public string Lname { get; set; }

    [Required]
    public short JobId { get; set; }

    public byte? JobLvl { get; set; }

    [Required]
    [MaxLength(4)]
    public string PubId { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual Publisher Pub { get; set; } = null!;

    public Employee(string Fname,
    string Lname,
    string PubId)
    {
        this.Fname = Fname;
        this.Lname = Lname;
        this.PubId = PubId;
    }
}
