using System;
using System.Collections.Generic;
using System.Security;

namespace VLab.Models;

public partial class Teacher
{
    public short IdTeacher { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public SecureString Password { get; set; } = null!;
}
