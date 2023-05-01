using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class LabWork
{
    public short IdLabWork { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
