using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblAdmin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string? AdminPhone { get; set; }

    public string? AdminEmail { get; set; }

    public string? AdminPassword { get; set; }

    public string? AdminRole { get; set; }

    public bool? AdminStatus { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<TblEvent> TblEvents { get; } = new List<TblEvent>();
}
