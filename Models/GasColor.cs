using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class GasColor
{
    public short IdGasColors { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Ga> GaColorAfterNavigations { get; set; } = new List<Ga>();

    public virtual ICollection<Ga> GaColorBeforeNavigations { get; set; } = new List<Ga>();
}
