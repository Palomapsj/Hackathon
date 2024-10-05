namespace Care.Api.Models;

public partial class RegardingEntity : BaseEntity
{
    public int? RegardingEntityTypeCodeTarget { get; set; }

    public string? RegardingEntityNameTarget { get; set; }

    public Guid? RegardingObjectIdTarget { get; set; }

    public string? RegardingObjectIdNameTarget { get; set; }

    public int? RegardingEntityTypeCodeSource { get; set; }

    public string? RegardingEntityNameSource { get; set; }

    public Guid? RegardingObjectIdSource { get; set; }

    public string? RegardingObjectIdNameSource { get; set; }

    public new Guid? ModifiedBy { get; set; }

    public new string? ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public new bool IsDeleted { get; set; }

    public new Guid? OwnerId { get; set; }

    public new string? OwnerIdName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public new string? EntityOriginalValues { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual ICollection<Annotation> Annotations { get; } = new List<Annotation>();

    public virtual ICollection<Attachment> Attachments { get; } = new List<Attachment>();

    public virtual ICollection<Chat> ChatOriginRegardingEntities { get; } = new List<Chat>();

    public virtual ICollection<Chat> ChatRegardingEntities { get; } = new List<Chat>();

    public virtual ICollection<Communication> CommunicationFroms { get; } = new List<Communication>();

    public virtual ICollection<Communication> CommunicationOriginRegardingEntities { get; } = new List<Communication>();

    public virtual ICollection<Communication> CommunicationRegardingEntities { get; } = new List<Communication>();

    public virtual ICollection<Communication> CommunicationTos { get; } = new List<Communication>();

    public virtual ICollection<Email> EmailOriginRegardingEntities { get; } = new List<Email>();

    public virtual ICollection<Email> EmailRegardingEntities { get; } = new List<Email>();

    public virtual ICollection<Incident> Incidents { get; } = new List<Incident>();

    public virtual ICollection<PhoneCall> PhoneCallCallForRegardingEntities { get; } = new List<PhoneCall>();

    public virtual ICollection<PhoneCall> PhoneCallCallFromRegardingEntities { get; } = new List<PhoneCall>();

    public virtual ICollection<PhoneCall> PhoneCallOriginRegardingEntities { get; } = new List<PhoneCall>();

    public virtual ICollection<PhoneCall> PhoneCallRegardingEntities { get; } = new List<PhoneCall>();

    public virtual ICollection<Sms> SmOriginRegardingEntities { get; } = new List<Sms>();

    public virtual ICollection<Sms> SmRegardingEntities { get; } = new List<Sms>();

    public virtual ICollection<Sms> SmSmsfromRegardingEntities { get; } = new List<Sms>();

    public virtual ICollection<Sms> SmSmstoRegardingEntities { get; } = new List<Sms>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<SurveyResponse> SurveyResponses { get; } = new List<SurveyResponse>();

    public virtual ICollection<Task> TaskOriginRegardingEntities { get; } = new List<Task>();

    public virtual ICollection<Task> TaskRegardingEntities { get; } = new List<Task>();
}
