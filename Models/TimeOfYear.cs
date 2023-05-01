using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class TimeOfYear
{
    public short IdTimeOfYear { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Microclimate> Microclimates { get; set; } = new List<Microclimate>();
}
