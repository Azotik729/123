using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class User
{
    public int idUser { get; set; }

    public string? login { get; set; }

    public string? password { get; set; }

    public int? role { get; set; }

    public string? adres { get; set; }

    public string? phone { get; set; }

    public DateOnly? dateOfBirth { get; set; }

    public string? fio { get; set; }

    public string? roly { get; set; }

    public virtual Authorization? LoginNavigation { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
