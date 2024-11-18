using System;
using System.Collections.Generic;

namespace basketball.Models;

public partial class Matchdatum
{
    public Guid? Id { get; set; }

    public DateTime Belep { get; set; }

    public DateTime Lejon { get; set; }

    public int Try { get; set; }

    public int Goal { get; set; }

    public int Fault { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public Guid PlayerId { get; set; }

    public virtual Player Player { get; set; } = null!;
}
