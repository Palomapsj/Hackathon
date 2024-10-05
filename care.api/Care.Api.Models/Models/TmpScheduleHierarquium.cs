using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpScheduleHierarquium
{
    public string ConsultorSchedule { get; set; }

    public string Name { get; set; }

    public Guid? RequestDoctorId { get; set; }

    public string MedicoSchedule { get; set; }

    public string MedicoConsultor { get; set; }

    public string MedicoGerente { get; set; }

    public Guid RepresentativeId { get; set; }

    public Guid? DoctorsRepresentativeId { get; set; }

    public string ConsultorGerente { get; set; }
}
