namespace Care.Api.Business.Models;

public class ResumeUsedVoucherModel
{
    public DateTime Date { get; set; }
    public required string Voucher { get; set; }
    public required string Product { get; set; }
    public required string Type { get; set; }
    public required int Amount { get; set; }
}