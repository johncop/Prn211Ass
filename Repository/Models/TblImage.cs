using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblImage
{
    public int ImageId { get; set; }

    public string? ImageUrl { get; set; }

    public int? EventId { get; set; }

    public string? ImageName { get; set; }

    public virtual TblEvent? Event { get; set; }
}
