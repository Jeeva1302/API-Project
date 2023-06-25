using System;
using System.Collections.Generic;

namespace api_project.Models;

public partial class CourseDetail
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseDuration { get; set; } = null!;

    public decimal? Fees { get; set; }

    public virtual ICollection<DoctorsDetail> Doctors { get; set; } = new List<DoctorsDetail>();
}
