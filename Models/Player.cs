using System;
using System.Collections.Generic;

namespace basketball.Models;

public partial class Player
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int Height { get; set; }

    public int Weight { get; set; }

    public int CreatedAt { get; set; }

    public virtual ICollection<Matchdatum> Matchdata { get; set; } = new List<Matchdatum>();
}
