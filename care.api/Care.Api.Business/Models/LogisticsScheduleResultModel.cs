using Newtonsoft.Json;

namespace Care.Api.Business.Models;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class LogisticsScheduleResultModel
{
    public Guid? Id { get; set; }
    public string? RequestType { get; set; }
    public string? Protocol { get; set; }
    public string? DiseaseName { get; set; }
    public string? Amount { get; set; }
    public string? StatusName { get; set; }
    public Guid? StatusId { get; set; }
    public Guid? RequestTypeId { get; set; }

    public DateTime? RequestDate { get; set; }
    public DateTime? ExpectedDeliveryDate { get; set; }
    public DateTime? DeliveryConfirmationDate { get; set; }
    public DateTime? EstimatedWithdrawalDate { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public DateTime? ConfirmWithdrawalDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public string? PatientCpf { get; set; }
    public string? PatientName { get; set; }
    public string? DoctorName { get; set; }
    public bool? NeedSupportFromNurse { get; set; }
    public string? ReasonPending { get; set; }
    public List<Guid>? KitTypeList { get; set; }
    public Guid? DoctorId { get; set; }
}

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class LogisticScheduleResultModel
{
    public string? Protocol { get; set; }
    public string? StatusName { get; set; }
    public string? RequestType { get; set; }
    public string? VoucherName { get; set; }
    public DateTime? RequestDate { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? ScheduledDate2 { get; set; }
    public DateTime? ScheduledDate3 { get; set; }
    public DateTime? ExpectedDeliveryDate { get; set; }
    public string? AddressPostalCode { get; set; }
    public string? AddressName { get; set; }
    public string? AddressCity { get; set; }
    public string? AddressState { get; set; }
    public string? AddressNumber { get; set; }
    public string? AddressDistrict { get; set; }
    public string? AddressComplement { get; set; }
    public string? AddressReference { get; set; }
    public string? AddressPostalCodeLab { get; set; }
    public string? AddressNameLab { get; set; }
    public string? AddressCityLab { get; set; }
    public string? AddressStateLab { get; set; }
    public string? AddressNumberLab { get; set; }
    public string? AddressDistrictLab { get; set; }
    public string? AddressComplementLab { get; set; }
    public string? AddressReferenceLab { get; set; }
    public string? Amount { get; set; }
    public string? DiseaseName { get; set; }
    public string? KitTypeName { get; set; }
    public string? DoctorName { get; set; }
    public string? DoctorCpf { get; set; }
    public string? DoctorLicense { get; set; }
    public string? DoctorEmail { get; set; }
    public string? RequestByName { get; set; }
    public string? RequestByPhoneNumber { get; set; }
    public string? Observation { get; set; }
    public string? LocalTypeName { get; set; }
    public string? WithdrawalTime { get; set; }
    public string? WithdrawalTime2 { get; set; }
    public string? WithdrawalTime3 { get; set; }
    public bool? NeedSupportFromNurse { get; set; }
    public bool? RequestByDoctor { get; set; }
    public string? PatientName { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public string? PatientCpf { get; set; }
    public string? PatientBirthdateGender { get; set; }
    public string? SampleReturnAddressPostalCode { get; set; }
    public string? SampleReturnAddressName { get; set; }
    public string? SampleReturnAddressCity { get; set; }
    public string? SampleReturnAddressState { get; set; }
    public string? SampleReturnAddressNumber { get; set; }
    public string? SampleReturnAddressDistrict { get; set; }
    public string? SampleReturnAddressComplement { get; set; }
    public string? ExamName { get; set; }
    public string? InstitutionName { get; set; }
    public string? Base64Attach { get; set; }
    public string? FileName { get; set; }
    public string? PatientAddressPostalCode { get; set; }
    public string? PatientAddressName { get; set; }
    public string? PatientAddressCity { get; set; }
    public string? PatientPhone { get; set; }
    public string? Temperature { get; set; }
    public string? ResponsibleForReceiving { get; set; }
    public string? ResponsibleForCollecting { get; set; }
    public string? ResponsibleTelephoneWithdrawal { get; set; }
    public string? LocalName { get; set; }
    public string? ClinicName { get; set; }
    public string? LaboratoryName { get; set; }
    public string? ClinicTelephone { get; set; }
    public string? LaboratoryTelephone { get; set; }
    public string? ClinicSector { get; set; }
    public string? LaboratorySector { get; set; }
    public string? ClinicTimePeriod { get; set; }
    public string? LaboratoryPeriod { get; set; }

    public List<SchedulingHistoryResultModel>? SchedulingHistories { get; set; }

}