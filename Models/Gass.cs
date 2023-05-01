using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Gass
{
    public short IdGases { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Ga> Gas { get; set; } = new List<Ga>();
}
