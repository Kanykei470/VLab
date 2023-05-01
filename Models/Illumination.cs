using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Illumination
{
    public short IdIllumination { get; set; }

    public string? MeasuringPoint { get; set; }

    public int? Bv { get; set; }

    public int? Bn { get; set; }

    public int? KeoResults { get; set; }

    public int? KeoGarf { get; set; }

    public string? CategoryOfWorks { get; set; }

    public string? TypeOfWork { get; set; }

    public int? DiscriminationObjectSize { get; set; }
}
