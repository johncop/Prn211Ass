using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblPayment
{
    public string? PaymentUrl { get; set; }

    public int? PaymentFee { get; set; }

    public string? PaymentDetail { get; set; }

    public int? EventId { get; set; }

    public int PaymentId { get; set; }

    public virtual TblEvent? Event { get; set; }
}
