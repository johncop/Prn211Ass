using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TblUser
{
    public int UsersId { get; set; }

    public string? UsersName { get; set; }

    public string? UsersEmail { get; set; }

    public string? UsersPhone { get; set; }

    public string? UsersAddress { get; set; }

    public string? UsersPassword { get; set; }

    public virtual ICollection<TblEventParticipated> TblEventParticipateds { get; } = new List<TblEventParticipated>();
}
