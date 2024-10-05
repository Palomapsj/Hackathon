namespace Care.Api.Business.Models;

public class PurchaseListPartnerModel
{
    public required string ProgramCode { get; set; }
    public string? PartnerId { get; set; }
    public string? PartnerName { get; set; }
    public string? PartnerCnpj { get; set; }
    public string? Type { get; set; }
}