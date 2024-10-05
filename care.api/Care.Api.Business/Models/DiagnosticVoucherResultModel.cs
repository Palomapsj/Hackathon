namespace Care.Api.Business.Models;

public class DiagnosticVoucherResultModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }
    public DateTime? CreatedOn { get; set; }
    public List<VoucherResultModel>? Vouchers { get; set; }
    public List<VoucherUtilizedHistoryResultModel>? UtilizedHistory { get; set; }
}