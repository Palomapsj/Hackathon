namespace Care.Api.Business.Models;

public class PurchaseListPartnerResultModel
{
    public Guid Id { get; set; }
    public DateTime? SolicitationDate { get; set; }
    public string? PurchaseId { get; set; }
    public string? CodeSap { get; set; }
    public string? PartnerName { get; set; }
    public string? PartnerCnpj { get; set; }
    public string? PartnerEmail { get; set; }
    public bool IsConfirmed { get; set; }
    public string? Type { get; set; }
}