using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class RepresentativeDoctorByProgram
{
    public Guid Id { get; set; }

    public Guid RepresentativeId { get; set; }

    public Guid DoctorId { get; set; }

    public DateTime? RegisterDate { get; set; }

    public Guid? SituationStringMapId { get; set; }

    public Guid HealthProgramId { get; set; }

    public virtual Representative? Representative { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual StringMap? SituationStringMap { get; set; }

}
