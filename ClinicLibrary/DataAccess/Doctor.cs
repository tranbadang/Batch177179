using System;
using System.Collections.Generic;

namespace ClinicLibrary.DataAccess;

public partial class Doctor
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual DoctorDetail? DoctorDetail { get; set; }
    public int DoctorID { get; internal set; }
}
