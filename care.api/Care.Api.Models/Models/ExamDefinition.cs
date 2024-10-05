using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ExamDefinition
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public Guid? ExamTypeStringMapId { get; set; }

    public string? Description { get; set; }

    public bool? HasLogisticsSchedule { get; set; }

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

    public string? Actions { get; set; }

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByPrograms { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<DiagnosticExam> DiagnosticExams { get; } = new List<DiagnosticExam>();

    public virtual ICollection<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

    public virtual ICollection<ExamDefinitionSettingsByProgram> ExamDefinitionSettingsByPrograms { get; } = new List<ExamDefinitionSettingsByProgram>();

    public virtual StringMap? ExamTypeStringMap { get; set; }

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual ICollection<HealthProgramDiseaseExam> HealthProgramDiseaseExams { get; } = new List<HealthProgramDiseaseExam>();

    public virtual ICollection<HealthProgramExamByEntity> HealthProgramExamByEntities { get; } = new List<HealthProgramExamByEntity>();

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<Voucher> Vouchers { get; } = new List<Voucher>();

    public virtual ICollection<AccountExamTypeByProgram> AccountExamTypeByPrograms { get; } = new List<AccountExamTypeByProgram>();

    public virtual ICollection<Exam> ExamsNavigation { get; } = new List<Exam>();

    public virtual ICollection<HealthProgram> HealthPrograms { get; } = new List<HealthProgram>();

    public virtual ICollection<VoucherConfiguration> VoucherConfigurations { get; } = new List<VoucherConfiguration>();

    public virtual ICollection<Medicament> Medicaments { get; } = new List<Medicament>();
}
