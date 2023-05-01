using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Psychrometer
{
    public short IdPsychrometer { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<HumidityAir> HumidityAirs { get; set; } = new List<HumidityAir>();
}
