using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Material
{
    public short IdMaterials { get; set; }

    public short? IdLabWork { get; set; }

    public string? Name { get; set; }

    public string? Material1 { get; set; }

    public virtual LabWork? IdLabWorkNavigation { get; set; }
}
