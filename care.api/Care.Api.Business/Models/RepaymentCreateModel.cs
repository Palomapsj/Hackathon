namespace Care.Api.Business.Models;

public class RepaymentCreateModel
{
    public required string ProgramCode { get; set; }
    public required List<PurchaseItemCreateModel> Items { get; set; }
}