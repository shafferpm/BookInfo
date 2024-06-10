using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class JobDto
{
    public short JobId { get; set; }

    public string JobDesc { get; set; } = null!;

    public byte MinLvl { get; set; }

    public byte MaxLvl { get; set; }

    public virtual ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
}
