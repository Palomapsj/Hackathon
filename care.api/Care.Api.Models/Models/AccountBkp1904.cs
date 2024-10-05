using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AccountBkp1904
{
    public Guid Id { get; set; }

    public Guid? AccountTypeStringMapId { get; set; }

    public string Name { get; set; }

    public string Telephone1 { get; set; }

    public string Telephone2 { get; set; }

    public string TelephoneFax { get; set; }

    public string MobilePhone { get; set; }

    public string EmailAddress { get; set; }

    public string Site { get; set; }

    public string AddressPostalCode { get; set; }

    public string AddressName { get; set; }

    public string AddressNumber { get; set; }

    public string AddressComplement { get; set; }

    public string AddressDistrict { get; set; }

    public string AddressCity { get; set; }

    public string AddressState { get; set; }

    public string AddressCountry { get; set; }

    public string AddressReference { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }

    public string Cnpj { get; set; }

    public string StateRegistration { get; set; }

    public string CompanyName { get; set; }

    public Guid? RegardingEntityId { get; set; }

    public Guid? AccessWayId { get; set; }

    public Guid? AccessMannerId { get; set; }

    public Guid? AccessCoverageAreaStringMapId { get; set; }

    public bool? AccessMakesStatement { get; set; }

    public bool? AccessMakesInformation { get; set; }

    public string AccessObservation { get; set; }

    public Guid? ClinicTypeStringMapId { get; set; }

    public Guid? ClinicPublicOrPrivateStringMapId { get; set; }

    public Guid? DoctorResponsableId { get; set; }

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

    public Guid? StatusCodeStringMapId { get; set; }

    public string ReasonStateCode { get; set; }

    public string ReasonDeleted { get; set; }

    public string FriendlyCode { get; set; }

    public string ImportCode { get; set; }

    public string InternalControl { get; set; }

    public string EntityOriginalValues { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    public string MainContact { get; set; }

    public string OfficeHours { get; set; }

    public string Ansnumber { get; set; }
}
