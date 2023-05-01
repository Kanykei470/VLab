using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Mistake
{
    public short IdMistake { get; set; }

    public string? Description { get; set; }

    public string? DescriptionOfСonsequences { get; set; }
}
