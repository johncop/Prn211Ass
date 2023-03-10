using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblVideo
{
    public int VideoId { get; set; }

    public string? VideoUrl { get; set; }

    public int? EventId { get; set; }

    public string? VideoName { get; set; }

    public virtual TblEvent? Event { get; set; }
}
