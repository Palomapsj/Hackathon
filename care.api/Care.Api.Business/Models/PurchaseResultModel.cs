namespace Care.Api.Business.Models;

public class PurchaseResultModel
{
    public required string GroupCode { get; set; }
    public required string PointOfPurchase { get; set; }
    public required string Cnpj { get; set; }
    public required string Identifier { get; set; }
    public List<PurchaseItemResultModel>? Items { get; set; }
}