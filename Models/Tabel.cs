using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Tabel
{
    public short IdTabel { get; set; }

    public short IdStudent { get; set; }

    public short? IdMicroclimate { get; set; }

    public short? IdGas { get; set; }

    public virtual Ga? IdGasNavigation { get; set; }

    public virtual Microclimate? IdMicroclimateNavigation { get; set; }

    public virtual Student IdStudentNavigation { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
