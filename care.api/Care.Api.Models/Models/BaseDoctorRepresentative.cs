using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class BaseDoctorRepresentative
{
    public string Doctor { get; set; }

    public string LicenseNumber { get; set; }

    public string LicenseState { get; set; }

    public string Doenca { get; set; }

    public string Representante { get; set; }

    public string Gerente { get; set; }
}
