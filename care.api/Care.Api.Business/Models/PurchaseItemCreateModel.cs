namespace Care.Api.Business.Models;

public class PurchaseItemCreateModel
{
    public required Guid ProductId { get; set; }
    public required int Amount { get; set; }
}