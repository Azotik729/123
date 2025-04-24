using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Book
{
    public int IdBook { get; set; }

    public int IdUser { get; set; }

    public int IdWriter { get; set; }

    public int IdChapter { get; set; }

    public string? DataPost { get; set; }

    public decimal? Price { get; set; }

    public string? Name { get; set; }

    public virtual Chapter IdChapterNavigation { get; set; } = null!;

    public virtual Writer IdWriterNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
