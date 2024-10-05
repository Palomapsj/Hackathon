namespace Care.Api.Business.Models
{
    public class ResourceWorkSettingRemoveModel
    {
        public Guid? Id { get; set; }
        public string? ProgramCode { get; set; }
        public Guid? AccountId { get; set; }
    }
}