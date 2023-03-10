using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblEventParticipated
{
    public int EventId { get; set; }

    public int UsersId { get; set; }

    public DateTime? DateParticipated { get; set; }

    public bool? PaymentStatus { get; set; }

    public bool? UsersStatus { get; set; }

    public virtual TblEvent Event { get; set; } = null!;

    public virtual ICollection<TblFeedback> TblFeedbacks { get; } = new List<TblFeedback>();

    public virtual TblUser Users { get; set; } = null!;
}
