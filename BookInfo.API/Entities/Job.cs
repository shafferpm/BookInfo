using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Entities;

public partial class Job
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public short JobId { get; set; }

    [Required]
    [MaxLength(50)]
    public string JobDesc { get; set; }

    [Required]
    public byte MinLvl { get; set; }

    [Required]
    public byte MaxLvl { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } 
        = new List<Employee>();

    public Job(string JobDesc)
    {
        this.JobDesc = JobDesc;
    }
}
