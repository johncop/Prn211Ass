using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblFeedback
{
    public int FeedbackId { get; set; }

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public DateTime? CreatedTime { get; set; }

    public int? EventId { get; set; }

    public int? UsersId { get; set; }

    public virtual TblEventParticipated? TblEventParticipated { get; set; }
}
