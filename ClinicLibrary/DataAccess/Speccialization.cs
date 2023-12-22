using System;
using System.Collections.Generic;

namespace ClinicLibrary.DataAccess;

public partial class Speccialization
{
    public int Id { get; set; }

    public string SpeccializationName { get; set; } = null!;

    public virtual ICollection<DoctorDetail> DoctorDetails { get; set; } = new List<DoctorDetail>();
}
