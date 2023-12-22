using System;
using System.Collections.Generic;

namespace ClinicLibrary.DataAccess;

public partial class DoctorDetail
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public int SpecializatioId { get; set; }

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Speccialization Specializatio { get; set; } = null!;
}
