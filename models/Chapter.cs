using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Chapter
{
    public int id { get; set; }

    public string? name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
