using System;
using System.Collections.Generic;

namespace api_project.Models;

public partial class FeedbackDetail
{
    public int PatientId { get; set; }

    public string? Name { get; set; }

    public long MobileNumber { get; set; }

    public string? Query { get; set; }

    public virtual PatientDetail Patient { get; set; } = null!;
}
