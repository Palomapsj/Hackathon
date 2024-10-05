using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

public partial class DoctorsRepresentative
{
    [NotMapped]
    public static int EntityTypeCode => 302;

    [NotMapped]
    public static string EntityName => "DoctorsRepresentative";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("B8A25B0A-34D4-4648-90C7-93B520D8A510");

    public Guid Id { get; set; }

    public Guid? RepresentativeId { get; set; }

    public Guid? ManagerId { get; set; }

    public Guid? DoctorId { get; set; }

    public Guid? HealthProgramId { get; set; }

    public Guid? MedicamentId { get; set; }

    public Guid? DiseaseId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string? ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? OwnerId { get; set; }

    public string? OwnerIdName { get; set; }

    public bool? StateCode { get; set; }

    public Guid? StatusCodeStringMapId { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public string? EntityOriginalValues { get; set; }

    public string? Name { get; set; }

    public Guid? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Disease? Disease { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual Representative? Manager { get; set; }

    public virtual Medicament? Medicament { get; set; }

    public virtual Representative? Representative { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }
}
