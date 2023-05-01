using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class TempAir
{
    public short IdTempAir { get; set; }

    public string? Place { get; set; }

    public short? ThermometerId { get; set; }

    public string? _01M { get; set; }

    public string? _10M { get; set; }

    public string? _15M { get; set; }

    public short? IdMicroclimate { get; set; }

    public virtual Microclimate? IdMicroclimateNavigation { get; set; }

    public virtual Thermometer? Thermometer { get; set; }
}
