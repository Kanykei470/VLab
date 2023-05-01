using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class HumidityAir
{
    public short IdHumidityAir { get; set; }

    public short? Psychrometer { get; set; }

    public string? PsychrometerDry { get; set; }

    public string? PsychrometerHumid { get; set; }

    public string? RelativeHumidityByFormula { get; set; }

    public string? RelativeHumidityByTabel { get; set; }

    public short? IdMicroclimate { get; set; }

    public virtual Microclimate? IdMicroclimateNavigation { get; set; }

    public virtual Psychrometer? PsychrometerNavigation { get; set; }
}
