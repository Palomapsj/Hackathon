namespace Care.Api.Models.Models;

public class PatientUploadFilesModel
{
    public required string ProgramCode { get; set; }
    public required string CpfPatient { get; set; }
    public required List<PatientUploadFileModel> Files { get; set; }
}

public class PatientUploadFileModel
{
    public required string FileName { get; set; }
    public required string Base64 { get; set; }
}