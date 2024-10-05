using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

public partial class Representative
{

    [NotMapped]
    public static int EntityTypeCode => 207;

    [NotMapped]
    public static string EntityName => "Representative";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("3F415D6F-A664-4C15-9123-0A1EE9191F6C");
    public Guid Id { get; set; }

    public Guid? AccountId { get; set; }

    public string? Name { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? Rg { get; set; }

    public string? Cpf { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? Telephone3 { get; set; }

    public string? Mobilephone1 { get; set; }

    public string? Mobilephone2 { get; set; }

    public string? Mobilephone3 { get; set; }

    public string? EmailAddress1 { get; set; }

    public string? EmailAddress2 { get; set; }

    public string? SkypeUser { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string? ModifiedByName { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public bool? IsDeleted { get; set; }

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

    public Guid? UserId { get; set; }

    public Guid? ProfessionalTypeStringMapId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<DoctorsRepresentative> DoctorsRepresentativeManagers { get; } = new List<DoctorsRepresentative>();

    public virtual ICollection<DoctorsRepresentative> DoctorsRepresentativeRepresentatives { get; } = new List<DoctorsRepresentative>();

    public virtual ICollection<Incident> Incidents { get; } = new List<Incident>();

    public virtual ICollection<RegionalManager> RegionalManagerRepresentativeSupervisors { get; } = new List<RegionalManager>();

    public virtual ICollection<RegionalManager> RegionalManagerRepresentatives { get; } = new List<RegionalManager>();

    public virtual ICollection<RepresentativeRegion> RepresentativeRegions { get; } = new List<RepresentativeRegion>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<TreatmentCustomData> TreatmentCustomData { get; } = new List<TreatmentCustomData>();

    public virtual User? User { get; set; }

    public virtual ICollection<Voucher> VoucherManagers { get; } = new List<Voucher>();

    public virtual ICollection<Voucher> VoucherRepresentatives { get; } = new List<Voucher>();

    public virtual ICollection<RepresentativeDoctorByProgram>? RepresentativeDoctorByPrograms { get; } = new List<RepresentativeDoctorByProgram>();
}
