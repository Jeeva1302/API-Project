using System;
using System.Collections.Generic;

namespace api_project.Models;

public partial class DoctorsDetail
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public string? Gender { get; set; }

    public string SpecialisedIn { get; set; } = null!;

    public long MobileNumber { get; set; }

    public string EmailId { get; set; } = null!;

    public string? WorkingHours { get; set; }

    public virtual ICollection<CourseDetail> Courses { get; set; } = new List<CourseDetail>();
}
