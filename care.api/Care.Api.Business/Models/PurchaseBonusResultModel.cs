namespace Care.Api.Business.Models;

public class PurchaseBonusResultModel
{
    public required string Id { get; set; }
    public required string ProductName { get; set; }
    public required int Amount { get; set; }
}