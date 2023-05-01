using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class LevelsOfNoise
{
    public short IdLevelsOfNoise { get; set; }

    public string? Place { get; set; }

    public int? _63Lvl { get; set; }

    public int? _125Lvl { get; set; }

    public int? _250Lvl { get; set; }

    public int? _500Lvl { get; set; }

    public int? _1000Lvl { get; set; }

    public int? _2000Lvl { get; set; }

    public int? _4000Lvl { get; set; }

    public int? _8000Lvl { get; set; }

    public int? LevelOfDba { get; set; }
}
