using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Ga
{
    public short IdGas { get; set; }

    public short? Gas { get; set; }

    public string? AirVolume { get; set; }

    public string? Time { get; set; }

    public short? ColorBefore { get; set; }

    public short? ColorAfter { get; set; }

    public string? PoisonConcentration { get; set; }

    public string? Pdk { get; set; }

    public bool? Status { get; set; }

    public string? Coment { get; set; }

    public virtual GasColor? ColorAfterNavigation { get; set; }

    public virtual GasColor? ColorBeforeNavigation { get; set; }

    public virtual Gass? GasNavigation { get; set; }

    public virtual ICollection<Tabel> Tabels { get; set; } = new List<Tabel>();
}
