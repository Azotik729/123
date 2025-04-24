using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public int IdBook { get; set; }

    public int? IdUser { get; set; }

    public string? DataPost { get; set; }

    public string? DataGet { get; set; }

    public int? TicketNum { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }
}
