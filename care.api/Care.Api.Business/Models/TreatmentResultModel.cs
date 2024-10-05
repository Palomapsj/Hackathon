using System.Reflection.Metadata;

namespace Care.Api.Business.Models;

public class TreatmentResultModel
{
    public DateTime? CreatedOn { get; set; }
    public string? PatientName { get; set; }
    public string? PatientCpf { get; set; }
    public string? TreatmentStatusName { get; set; }
    public Guid? TreatmentPhaseId { get; set; }
    public string? TreatmentPhaseName { get; set; }
    public string? DiseaseName { get; set; }
    public string? ExameName { get; set; }
    public string? Voucher { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? RealizationDate { get; set; }
    public Guid? PatientStatusId { get; set; }
    public string? ExamStatusName { get; set; }
    public Guid? TreatmentId { get; set; }
    public Guid? ExamStatusId { get; set; }
    public Guid? TreatmentSituationId { get; set; }
    public List<AddressModel> PatientAddresses { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? CityState { get; set; }
    public string? AddressState { get; set; }
    public string? LicenseNumber { get; set; }
    public string? LicenseState { get; set; }
    public string? DoctorName { get; set; }
    public Guid? MedicamentId { get; set; }
    public string? MedicamentName { get; set; }
    public Guid? DoctorId { get; set; }
    public DateTime? SystemAccessStartDate { get; set; }
    public string? Account { get; internal set; }
    public DateTime? DateReceiptMedicine { get; set; }
    public DateTime? InfusionDate { get; set; }
    public string? InfusionStatus { get; set; }
    public DateTime? CustomDateTime1 { get; set; }
    public DateTime? TreatmentStopDate { get; set; }
    public string? Gender { get; set; }
    public Guid? ReasonPendencyId { get; set; }
    public List<string>? ReasonPendencyName { get; set; }
    public Guid? ExamId { get; set; }
    public Guid? ReportLab { get; set; }
    public string? CustomString3 { get; set; }
}

public class TreatmentServiceTypeResultModel
{
    public string? ServiceTypeName { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? RealizationDate { get; set; }
    public DateTime? RequestDate { get; set; }
    public string? StatusHistoryName { get; set; }
    public string? ReasonNotDone { get; set; }
    public string? ProcedureTypeName { get; set; }
    public string? ClinicName { get; set; }
    public string? InfusionPlaceName { get; set; }
    public string? PatientName { get; set; }
    public string? Voucher { get; set; }
    public string? DiseaseName { get; set; }
    public DateTime? CreatedOn { get; set; }
    public Guid? ServiceTypeId { get; set; }
    public Guid? TreatmentId { get; set; }
    public Guid? ExamId { get; set; }
    public Guid? InfusionId { get; set; }
    public Guid? LogisticId { get; set; }
    public string? ServiceTypeOptionName { get; set; }
    public string? Location { get; set; }
    public Guid? VisitCode { get; set; }
    public string CancellationReason { get; set; }
    public string VoucherCode { get; set; }
    public int? ExamCount { get; set; }
    public string? ExamDefinitionName { get; set; }
    public Guid? VisitId { get; set; }
    public bool? VisitType { get; set; }
    public string HealthProfessionalName { get; internal set; }
    public Guid? TypeProfessional { get; set; }
}

public class TreatmentProcedureResultModel
{
    public DateTime? CreatedOn { get; set; }
    public string? PatientName { get; set; }
    public string? PatientCpf { get; set; }
    public string? TreatmentStatusName { get; set; }
    public string? VisitStatusName { get; set; }
    public string? TreatmentPhaseName { get; set; }
    public string? VisitPhaseName { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? RealizationDate { get; set; }
    public string? ProcedureName { get; internal set; }
    public string? Voucher { get; internal set; }
    public string? DoctorName { get; internal set; }
    public string? LicenseName { get; internal set; }
    public string? ProcedureStatusName { get; internal set; }
    public string? ReasonNotDone { get; set; }
    public string? ServiceTypeName { get; set; }
    public string? ClinicName { get; set; }
    public string CrmUf { get; internal set; }
    public string? PatientStatus { get; set; }
    public string? Medicament { get; set; }
    public Guid? InfusionId { get; set; }
    public Guid? ExamId { get; set; }
    public Guid? DiseaseId { get; set; }
    public Guid? TreatmentId { get; set; }
    public string? DiseaseName { get; set; }
    public Guid? VisitId { get; set; }
    public string? PatientPhaseName { get; set; }
    public string? InfusionStatus { get; set; }
    public string? InfusionPhase { get; set; }
    public string? VisitType { get; set; }
    public string? HealthProfessionalName { get; internal set; }
    public Guid? TypeProfessional { get; set; }
}

public class ServiceByPatient
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public Guid? TreatmentId { get; set; }
    public string? ServiceName { get; set; }
    public int? Amount { get; set; }
}

public class PatientsDuplixent
{
    public Guid TreatmentId { get; set; }
    public string? Local { get; set; }
    public DateTime? ApplicationDate { get; set; }
    public string? Dose { get; set; }

}

public class PatientsEmSintonia
{
    public Guid TreatmentId { get; set; }
    public string? Local { get; set; }
    public DateTime? ExamDate { get; set; }
    public bool? Status { get; set; }
    public string? StatusDetail { get; set; }

}

public class InfusionsEmSintonia
{
    public Guid TreatmentId { get; set; }
    public string? Local { get; set; }
    public DateTime? InfusionDate { get; set; }
    public bool? Ciclo { get; set; }
    public string? StatusDetail { get; set; }

}

public class InfusionsDupixent
{
    public string? StatusApplication { get; set; }
    public string? Local { get; set; }
    public DateTime? ScheduleDate { get; set; }
    public DateTime? ApplicationDate { get; set; }
    public string? Voucher { get; set; }

}

public class ListPatientsSanofi
{
    public Guid PatientId { get; set; }
    public string? PatientName { get; set; }

    public string? DiseaseName { get; set; }
}

public class TreatmentAddressModel
{
    public Guid TreatmentAddressId { get; set; }
    public string? AddressCity { get; set; }
    public string? AddressState { get; set; }
}
public class TreatmentDocumentModel
{
    public string? DoctorName { get; set; }
    public string? License { get; set; }
    public string? PatientName { get;set; }
    public string? PatientCpf { get; set; }
    public DateTime? BirthDate{ get; set; }
    public string? Gender { get; set; }
    public string? ExamName { get; set; }
    public string? InstitutionName { get; set; }
    public string? AddressWithdrawal { get; set; }
    public Guid? TransportDeclarationId { get; set; }
    public Guid? ConsentFormId { get; set;}
    public Guid? MedicalReportId { get;set; }
    public string? ReasonPendencyName { get; set; }
    public string? PatientTelephone { get; set; }
    public string? PatientMobilePhone { get; set; }
    public string? PatientCEP { get; set; }
    public string? PatientAddressName{ get;set; }
    public string? PatientAddressNumber { get; set; }
    public string? PatientDistrict { get; set; }
    public string? PatientCity { get; set; }
    public string? PatientAddressState { get; set; }
    public string? PatientComplement { get; set; }
    public bool? isGroup { get; set; }
    public string? Observation { get; set; }
    public string? Voucher { get; set;}
    public string? ResponsibleName { get; set; }
    public string? ResponsibleTelephone { get; set; }
    public string? CEP { get; set; }
    public string? AddressNameSample { get; set; }
    public string? AddressNumberSample { get; set; }
    public string? AddressComplementSample { get; set; }
    public string? AddressDistrictSample { get; set; }
    public string? AddressCitySample { get; set; }
    public string? AddressStateSample { get; set; }
    public string? AddressCountrySample { get; set; }
    public DateTime? WithdrawalDate { get; set; }
    public Guid? PreferredTimeId { get; set; }
}
public record TreatmentSimpleInfo(Guid TreatmentId, string EmailAddress1);
