using System;
using System.Collections.Generic;
using System.Security;

namespace VLab.Models;

public partial class Student
{
    public short IdStudents { get; set; }

    public string FullName { get; set; } = null!;

    public short IdGroup { get; set; }

    public string Email { get; set; } = null!;

    public SecureString Password { get; set; } = null!;

    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual ICollection<Tabel> Tabels { get; set; } = new List<Tabel>();
}
