using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models;

public class DiagnosticResultModel
{
    public Guid? Id { get; set; }
    public Guid? DoctorId { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? NumberProtocol { get; set; }
    public string? NamePatient { get; set; }
    public string? CPF { get; set; }
    public Guid? PatientStatus { get; set; }
    public Guid? ExamDefinition { get; set; }
    public string? Voucher { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public Guid? ExamStatus { get; set; }
    public string? ReasonPendingCanceled { get; set; }
    public string? FileReport { get; set; }
    public Guid? Result { get; set; }
    public string? DoctorName { get; set; }
    public string? CRMUF { get; set; }
    public string? PatientStatusName { get; set; }
    public string? Exame { get; set; }
    public string? ExamStatusName { get; set; }
    public string? LaboratoryResult { get; set; }
    public string? VoucherStatus { get; set; }
    public bool? HasAttachment { get; set; }
}
