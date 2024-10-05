﻿using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class SectionMetadataBkp24092021
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsAdvanced { get; set; }

    public bool? IsSystemSection { get; set; }

    public Guid? EntityMetadataId { get; set; }

    public string EntityMetadataIdName { get; set; }

    public string SectionIdHtm { get; set; }

    public string Tooltip { get; set; }

    public string Help { get; set; }

    public Guid? ProgramId { get; set; }

    public bool? IsVisibleInFormAdd { get; set; }

    public bool? IsVisibleInFormEdit { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string CreatedByName { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string DeletedByName { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? OwnerId { get; set; }

    public string OwnerIdName { get; set; }

    public bool? StateCode { get; set; }

    public string ReasonStateCode { get; set; }

    public string ReasonDeleted { get; set; }

    public string FriendlyCode { get; set; }

    public string ImportCode { get; set; }

    public string InternalControl { get; set; }

    public string EntityOriginalValues { get; set; }

    public bool HasSurvey { get; set; }

    public int? HasMap { get; set; }

    public bool HasCalendar { get; set; }
}
