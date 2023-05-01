using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Group
{
    public short IdGroup { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
