namespace Care.Api.Business.Models;

public class ExamPendenciesModel
{
    public Guid Id { get; set; }
    public List<Guid>? PendenciesId { get; set; }
    public string? PendencyDetailed { get; set; }
}
