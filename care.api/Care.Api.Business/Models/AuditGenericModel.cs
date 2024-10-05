namespace Care.Api.Business.Models
{
    public class AuditGenericModel
    {
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }


        public List<AuditChange> AuditChanges { get; set; }
    }
}
