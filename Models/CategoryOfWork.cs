using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class CategoryOfWork
{
    public short IdCategoryOfWork { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Microclimate> Microclimates { get; set; } = new List<Microclimate>();
}
