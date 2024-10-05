namespace Care.Api.Business.Models;

public class AttachCreateModel
{
    public string? FileName { get; set; }
    public string? DocumentBody { get; set; }
    public string? ContentType { get; set; }
    public string? FileSize { get; set; }
    public string? FileType { get; set; }
    public string? AnnotationTypeStringMapCode { get; set; }
    public Guid? AnnotationTypeStringMapId { get; set; }
    public string? HealthProgramCode { get; set; }
    public string? Name { get; set; }
}