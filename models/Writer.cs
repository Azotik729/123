using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Writer
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
