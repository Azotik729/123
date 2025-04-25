using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Book
{
    public int idBook { get; set; }

    public int idUser { get; set; }

    public int idWriter { get; set; }

    public int idChapter { get; set; }

    public string? dataPost { get; set; }

    public decimal? price { get; set; }

    public string? name { get; set; }

    public virtual Chapter IdChapterNavigation { get; set; } = null!;

    public virtual Writer IdWriterNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
