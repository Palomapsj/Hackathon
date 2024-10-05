namespace Care.Api.Business.Models
{
    public class AuditModel<T>
    {
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }


        public List<AuditChange> AuditChanges { get; set; }

    }

    public class AuditChange 
    {
        public Guid Id { get; set; }
        public string Field { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

    }

}
