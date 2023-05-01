using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Result
{
    public short IdResults { get; set; }

    public short IdStudent { get; set; }

    public short IdLabWork { get; set; }

    public short IdTabel { get; set; }

    public short? Mark { get; set; }

    public virtual LabWork IdLabWorkNavigation { get; set; } = null!;

    public virtual Student IdStudentNavigation { get; set; } = null!;

    public virtual Tabel IdTabelNavigation { get; set; } = null!;
}
