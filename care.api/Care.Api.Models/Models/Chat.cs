using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Chat : BaseEntity
{
    public static int EntityTypeCode => 604;
    public static string EntityName => "Chat";

    public string Name { get; set; }

    public Guid? ChatTypeStringMapId { get; set; }

    public Guid? OperatorId { get; set; }

    public string Description { get; set; }

    public DateTime? ActualStart { get; set; }

    public DateTime? ActualEnd { get; set; }

    public int? Duration { get; set; }

    public Guid? RegardingEntityId { get; set; }

    public Guid? HealthProgramId { get; set; }
    
    public Guid? DeletedBy { get; set; }

    public string DeletedByName { get; set; }

    public string ReasonStateCode { get; set; }

    public string ReasonDeleted { get; set; }

    public string FriendlyCode { get; set; }

    public string ImportCode { get; set; }

    public string InternalControl { get; set; }

    public Guid? OriginRegardingEntityId { get; set; }

    public virtual ICollection<ChatDialog> ChatDialogs { get; } = new List<ChatDialog>();

    public virtual StringMap ChatTypeStringMap { get; set; }

    public virtual HealthProgram HealthProgram { get; set; }

    public virtual User Operator { get; set; }

    public virtual RegardingEntity OriginRegardingEntity { get; set; }

    public virtual RegardingEntity RegardingEntity { get; set; }

    public virtual StringMap StatusCodeStringMap { get; set; }
}
