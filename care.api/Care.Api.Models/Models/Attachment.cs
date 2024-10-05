using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Attachment : BaseEntity
{

    public static int EntityTypeCode => 306;
    public static string EntityName => "Attachment";


    public Guid? RegardingEntityId { get; set; }

    public string? FileName { get; set; }

    public string? Name { get; set; }

    public string? FileSize { get; set; }

    public string? MimeType { get; set; }

    public string? DocumentBody { get; set; }

    public Guid? AnnotationId { get; set; }

    public byte[] Version { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string? ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? OwnerId { get; set; }

    public string? OwnerIdName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public string? EntityOriginalValues { get; set; }

    public virtual Annotation? Annotation { get; set; }

    public virtual RegardingEntity? RegardingEntity { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }
}
