using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<TblEvent> TblEvents { get; } = new List<TblEvent>();
}
