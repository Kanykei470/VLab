using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Electricity
{
    public short IdElectricity { get; set; }

    public int? Frequency { get; set; }

    public int? VoltageU2 { get; set; }

    public int? VoltageUpr { get; set; }

    public int? Сurrent { get; set; }

    public int? Resistance { get; set; }

    public int? A { get; set; }
}
