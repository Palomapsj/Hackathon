using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class LogisticsScheduleModel : CommonModel
    {
        public int? Amount { get; set; }
        public Guid? TreatmentId { get; set; }
        public Guid? DiseaseId { get; set; }
        public Guid? KitTypeId { get; set; }
        public Guid? LocalTypeId { get; set; }
        public Guid? LocalId { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressReference { get; set; }
        public string? RequestByName { get; set; }
        public string? RequestByPhoneNumber { get; set; }
        public string? Orientation { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? ScheduleDate2 { get; set; }
        public DateTime? ScheduleDate3 { get; set; }
        public string? ProgramCode { get; set; }
        public string? WithdrawalTime { get; set; }
        public string? WithdrawalTime2 { get; set; }
        public string? WithdrawalTime3 { get; set; }
        public bool? NeedSupportFromNurse { get; set; }
        public Guid? ExamDefinitionId { get; set; }
        public string? InstitutionName { get; set; }
        public string? InstitutionTelephone { get; set; }
        public string? InstitutionEmail { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCpf { get; set; }
        public DateTime? PatientBirthdate { get; set; }
        public Guid? PatientGenderId { get; set; }
        public bool? SameWithdrawalAddress { get; set; }
        public string? SampleReturnAddressPostalCode { get; set; }
        public string? SampleReturnAddressName { get; set; }
        public string? SampleReturnAddressCity { get; set; }
        public string? SampleReturnAddressState { get; set; }
        public string? SampleReturnAddressNumber { get; set; }
        public string? SampleReturnAddressDistrict { get; set; }
        public string? SampleReturnAddressComplement { get; set; }
        public string? NameCaregiver { get; set; }
        public string? CPFCaregiver { get; set; }
        public DateTime BirthdateCaregiver { get; set; }
        public Guid? PartnerId { get; set; }
        public string? NurseName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseState { get; set; }
        public Guid? DoctorId { get; set; }
    }

    public class LogisticsReccolectionModel
    {
        public Guid Id { get; set; }
        public Guid? LocalTypeId { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressReference { get; set; }
        public string? RequestByName { get; set; }
        public string? RequestByPhoneNumber { get; set; }
        public string? Orientation { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string? ProgramCode { get; set; }
        public string? WithdrawalTime { get; set; }
        public bool? NeedSupportFromNurse { get; set; }
        public string? NumberProtocol { get; set; }
        public Guid? DiagnosticId { get; set; }
        public string? ResponsibleForCollecting { get; set; }
        public DateTime? SampleScheduledDate { get; set; }
        public DateTime? SampleDeliveryDate { get; set; }
        public string? Description { get; set; }
        public string? ResponsibleForReceiving { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public Guid? DeliveryLaboratoryId { get; set; }
        public string? NurseName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseState { get; set; }
        public bool? SameDoctor { get; set; }
        public Guid? PartnerId { get; set; }
    }

    public class LogisticsAnalysisModel
    {
        public Guid? Id { get; set; }
        public string? Reasonpending { get; set; }
        public Guid? Result { get; set; }
        public Guid? LevelOfOwnership { get; set; }
        public Guid? PositiveSuggestion { get; set; }
        public DateTime? Date { get; set; }
        public string? ProgramCode { get; set; }
        public AttachmentModel? SampleReportAttach { get; set; }

    }

    public class LogisticsWithdrawalModel
    {
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressComplement { get; set; }
        public string? RequestByName { get; set; }
        public string? Orientation { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string? ProgramCode { get; set; }
        public string? WithdrawalTime { get; set; }
        public string? NumberProtocol { get; }
        public string? NurseName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseState { get; set; }
    }
}
