using Care.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models;

public class RepresentativeByDoctorResultModel
{
    public Guid? Id { get; set; }
    public Guid? RepresentativeId { get; set; }
    public string? ProfessionalName { get; set; }
    public string? LicenseNumber { get; set; }
    public string? LicenseState { get; set; }
    public string? ProfessionalTypeName { get; set; }
    public Guid? ProfessionalTypeStringMap { get; set; }
    public string? DoctorName { get; set; }
    public string? DoctorCrmNumber { get; set; }
    public string? DoctorCrmState { get; set; }
    public string? SituationName { get; set; }
    public Guid? SituationStringMap { get; set; }
    public DateTime? RegisterDate { get; set; }
}
public class RepresentativeDoctorByProgramRequest
{
    public Guid? RepresentativeId { get; set; }
    public Guid? DoctorId { get; set; }
    public string? Programcode { get; set; }
    public string? Flag { get; set; }
}

public class RepresentativeExistResultModel
{
    public Guid? RepresentativeId { get; set; }
    public string? Name { get; set; }
}