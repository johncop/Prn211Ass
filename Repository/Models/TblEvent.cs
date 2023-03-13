using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public partial class TblEvent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public string? EventContent { get; set; }

    public DateTime? EventStart { get; set; }

    public bool? EventStatus { get; set; }

    public int? CategoryId { get; set; }

    public int? LocationId { get; set; }

    public int AdminId { get; set; }

    public DateTime? EventEnd { get; set; }

    public virtual TblAdmin? Admin { get; set; }

    public virtual TblCategory? Category { get; set; }

    public virtual TblLocation? Location { get; set; }

    public virtual ICollection<TblEventParticipated> TblEventParticipateds { get; } = new List<TblEventParticipated>();

    public virtual ICollection<TblImage> TblImages { get; } = new List<TblImage>();

    public virtual ICollection<TblPayment> TblPayments { get; } = new List<TblPayment>();

    public virtual ICollection<TblVideo> TblVideos { get; } = new List<TblVideo>();
}
