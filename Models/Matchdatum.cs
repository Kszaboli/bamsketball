using System;
using System.Collections.Generic;

namespace basketball.Models;

public partial class Matchdatum
{
    public string Id { get; set; } = null!;

    public DateTime Belep { get; set; }

    public DateTime Lejon { get; set; }

    public int Try { get; set; }

    public int Goal { get; set; }

    public int Fault { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public string PlayerId { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
