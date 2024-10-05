namespace Care.Api.Business.Models
{
    public class VoucherValidateModel
    {
        public Guid? Id { get; set; }
        public required string Name { get; set; }
        public string? CrmDoctor { get; set; }
        public string? CrmUfDoctor { get; set; }
        public string? ProgramCode { get; set; }
    }
}
