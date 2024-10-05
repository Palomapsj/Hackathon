namespace Care.Api.Business.Models;

public class DoctorResultModel
{
    public Guid? DoctorId { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? DoctorName { get; set; }
    public string? DoctorCRMUF { get; set; }
    public string? DoctorSpecialty { get; set; }
    public string? Email { get; set; }
    public string? Mobilephone { get; set; }
    public string? AddressCity { get; set; }
    public string? AddressState { get; set; }
    public bool? StateCode { get; set; }
    public string? InactivationType { get; set; }
}
public class DoctorProgram
{
    public bool? ResultVivaRaras { get; set; }
    public bool? ResultVivaEm { get; set; }
    public bool? ResultVivaImuno { get; set; }

}

public class TermDoctorResult
{
    public Guid DoctorId { get; set; }
    public string? DoctorName { get; set; }
    public string? DoctorEmail { get; set; }
    public string? DoctorCPF { get; set; }
    public string? MobilePhone { get; set; }
    public string? LicenseNumber { get; set; }
    public string? LicenseState { get; set; }
    public bool? ConsentTreatment { get; set; }
    public bool? ConsentDiagnostic { get; set; }
    public string? ProgramCode { get; set; }
    public bool? ConsentTerms { get; set; }
    public bool? DoctorInactive { get; set; }
}

public class DoctorExistResultModel
{
    public Guid? DoctorId { get; set; }
    public string? Name { get; set; }
}
