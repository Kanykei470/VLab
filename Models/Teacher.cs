using System;
using System.Collections.Generic;

namespace VLab.Models;

public partial class Teacher
{
    public short IdTeacher { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
