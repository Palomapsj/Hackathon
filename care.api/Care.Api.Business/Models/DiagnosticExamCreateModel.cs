namespace Care.Api.Business.Models;

public class DiagnosticExamCreateModel
{
    public string? LicenseNumber { get; set; }
    public string? LicenseState { get; set; }
    public string? DoctorName { get; set; }
    public string? ExamName { get; set; }
    public string? CPF { get; set; }
    public string? PatientName { get; set; }
    public DateTime? Birthdate { get; set; }
    public string? Disease { get; set; }
    public string? Mobilephone { get; set; }
    public string? Telephone { get; set; }
    public Guid? LaboratoryAnalysis { get; set; }
    public string? NameCaregiver { get; set; }
    public string? Mobilephone1Caregiver { get; set; }
    public string? CPFCaregiver { get; set; }
    public DateTime? BirthdateCaregiver { get; set; }
    public bool? HasOPS { get; set; }
    public string? HealthProgramCode { get; set; }
    public List<SurveyResponseModel>? SurveyResponses { get; set; }
    public string? Base64 { get; set; }
    public string? FileName { get; set; }
    public string? Email { get; set; }
}
