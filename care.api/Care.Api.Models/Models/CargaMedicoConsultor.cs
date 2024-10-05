using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class CargaMedicoConsultor
{
    public int Id { get; set; }

    public string Crmmedico { get; set; }

    public string Medico { get; set; }

    public string Consultor { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public DateTime Data { get; set; }

    public string Usuario { get; set; }

    public string LicenseNumber { get; set; }

    public string Crmstate { get; set; }

    public Guid? DoctorId { get; set; }

    public Guid? RepresentativeId { get; set; }
}
