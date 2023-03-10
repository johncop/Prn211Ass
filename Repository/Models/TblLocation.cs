using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblLocation
{
    public int LocationId { get; set; }

    public string? LocationDetail { get; set; }

    public string? LocationStatus { get; set; }

    public virtual ICollection<TblEvent> TblEvents { get; } = new List<TblEvent>();
}
