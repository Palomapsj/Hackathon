namespace Care.Api.Business.Models;

public class PurchaseItemResultModel
{
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
    public required string Ean { get; set; }
    public int Amount { get; set; }
}