namespace Care.Api.Business.Models;

public class VoucherUtilizedHistoryResultModel
{
    public DateTime? UseDate { get; set; }
    public string? Locality { get; set; }
    public string? Number { get; set; }
    public string? DiscountType { get; set; }
    public int? DeadlineInDays { get; set; }
    public decimal? DiscountValue { get; set; }
}