using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Microclimate
{
    public short IdMicroclimate { get; set; }

    public string? Place { get; set; }

    public string? MicroclimateParamets { get; set; }

    public string? CharacteristicIndustrialPlaces { get; set; }

    public short? СategoryOfWorks { get; set; }

    public short? TimeOfYear { get; set; }

    public string? TempAirFact { get; set; }

    public string? TempAirNorm { get; set; }

    public string? TempHumFact { get; set; }

    public string? TempHumNorm { get; set; }

    public string? SpeedAirFact { get; set; }

    public string? SpeedAirNorm { get; set; }

    public bool? Status { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<HumidityAir> HumidityAirs { get; set; } = new List<HumidityAir>();

    public virtual ICollection<Tabel> Tabels { get; set; } = new List<Tabel>();

    public virtual ICollection<TempAir> TempAirs { get; set; } = new List<TempAir>();

    public virtual TimeOfYear? TimeOfYearNavigation { get; set; }

    public virtual CategoryOfWork? СategoryOfWorksNavigation { get; set; }
}
