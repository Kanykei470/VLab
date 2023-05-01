using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Thermometer
{
    public short IdThermometer { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TempAir> TempAirs { get; set; } = new List<TempAir>();
}
