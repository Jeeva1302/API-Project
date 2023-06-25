using System;
using System.Collections.Generic;

namespace api_project.Models;

public partial class AppointmentDetail
{
    public int? PatientId { get; set; }

    public string? Name { get; set; }

    public short? Age { get; set; }

    public long? MobileNumber { get; set; }

    public string? TimeSlot { get; set; }

    public DateTime? DateToVisit { get; set; }

    public string? PurposeOfVisit { get; set; }

    public string SpecializationLookingFor { get; set; } = null!;

    public int? DoctorId { get; set; }

    public virtual DoctorsDetail? Doctor { get; set; }

    public virtual PatientDetail? Patient { get; set; }
}
