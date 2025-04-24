using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Authorization
{
    public string Login { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
