using System;
using System.Collections.Generic;

namespace api_project.Models;

public partial class PatientDetail
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public int Age { get; set; }

    public string? Gender { get; set; }

    public long MobileNumber { get; set; }

    public string? Address { get; set; }

    public string? TypeOfPatient { get; set; }

    public string? Problem { get; set; }
}
