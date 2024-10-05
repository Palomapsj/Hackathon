using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class TreatmentAndExamModel
    {
        public Guid? Id { get; set; }
        public Guid? DoctorId { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? CPF { get; set; }
        public string? Mobilephone { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? AddressPostalCode { get; set; }
        public string? AddressName { get; set; }
        public string? AddressNumber { get; set; }
        public string? AddressComplement { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressCountry { get; set; }
        public Guid? GenderId { get; set; }
        public bool? isGroup { get; set; }
        public string? InstitutionName { get; set; }
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
        public string? Observation { get; set; }
        public string? ProgramCode { get; set; }
        public DateTime? WithdrawalDate { get; set; }
        public Guid? PreferredTimeId { get; set; }
        public string? VoucherConfigurationCode { get; set; }
        public string? VoucherName { get; set; }
        public string? ExamName { get; set; }
        public Guid? ExamNameId { get; set; }
        public List<string>? Pendencys { get; set; }
        public Guid? TransportDeclarationId { get;set; }
        public Guid? ConsentFormId { get; set; }
        public Guid? MedicalReportId { get; set; }
        public AttachmentModel? TransportDeclarationAttach { get; set; }
        public AttachmentModel? ConsentTermAttach { get; set;}
        public AttachmentModel? MedicalRequestAttach { get; set; }
    }
}
