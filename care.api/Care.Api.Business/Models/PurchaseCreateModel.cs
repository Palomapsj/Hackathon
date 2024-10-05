namespace Care.Api.Business.Models;

public class PurchaseCreateModel
{
    public required Guid VoucherId { get; set; }
    public required string ProgramCode { get; set; }
    public required List<PurchaseItemCreateModel> Items { get; set; }
    public required Boolean IsGeneratePurchase { get; set; }
}