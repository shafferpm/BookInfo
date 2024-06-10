using System;
using System.Collections.Generic;

namespace BookInfo.API.Models;

public partial class PublisherDto
{
    public string PubId { get; set; } = null!;

    public string? PubName { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

    public virtual PubInfoDto? PubInfo { get; set; }

    public virtual ICollection<TitleDto> Titles { get; set; } = new List<TitleDto>();
}
