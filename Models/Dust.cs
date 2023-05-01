using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Dust
{
    public short IdNumOfTest { get; set; }

    public int? TemperatureInRoom { get; set; }

    public int? BarometricPressure { get; set; }

    public int? FilterWeightBefore { get; set; }

    public int? FilterWeightAfter { get; set; }

    public int? AirThroughRotameter { get; set; }

    public int? MeasurementTime { get; set; }

    public int? VolumeOfAirThroughFilter { get; set; }

    public int? VolumeOfAirReducedToStandard { get; set; }

    public int? DustConcentrationInAir { get; set; }

    public int? MaxAllowableConcentrationOfDust { get; set; }
}
