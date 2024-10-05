namespace Care.Api.Business.Models;

public class VoucherResultModel
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public string? DiscountType { get; set; }
    public int? DeadlineInDays { get; set; }
    public decimal? DiscountValue { get; set; }
    public Guid? Status { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? Name { get; set; }
    public string? Note { get; set; }
}