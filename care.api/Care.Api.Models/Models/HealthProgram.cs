using Care.Api.Models.Models;
using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class HealthProgram : BaseEntity
{

    public string? Name { get; set; }

    public string? Code { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Guid? AccountId { get; set; }

    public string? DashBoardPageName { get; set; }

    public bool? HasPurchase { get; set; }

    public bool? HasIncident { get; set; }

    public bool? HasPharmacovigilance { get; set; }

    public bool? HasDiagnosis { get; set; }

    public bool? HasDiagnosisExams { get; set; }

    public bool? DiagnosisByLogisticSchedule { get; set; }

    public bool? HasVisit { get; set; }

    public bool? HasVisitSurvey { get; set; }

    public bool? HasVisitSla { get; set; }

    public decimal? NurseDefaultValue { get; set; }

    public bool? HasVoucher { get; set; }

    public bool? HasLogistics { get; set; }

    public Guid? LogisticsTypeStringMapId { get; set; }

    public Guid? LogisticPartnerId { get; set; }

    public bool? HasExam { get; set; }

    public bool? NeedBudgetToExams { get; set; }

    public bool? HasInfusion { get; set; }

    public bool? HasInfusionExpiration { get; set; }

    public int? InfusionDaysToExpire { get; set; }

    public bool? HasPreRegistration { get; set; }

    public bool? HasRegister { get; set; }

    public bool? HasAccess { get; set; }

    public bool? HasAdhesion { get; set; }

    public int? EligibilityMinimumAge { get; set; }

    public int? EligibilitymaximumAge { get; set; }

    public bool? EligibilityRequiresPrescription { get; set; }

    public bool? EligibilityRequiresAttachmentPrescription { get; set; }

    public Guid? AkkaActorsId { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public string? ScriptNamespace { get; set; }

    public bool? HasTreatmentCustomData { get; set; }

    public bool? HasTherapeuticHistory { get; set; }

    public bool? HasPeriodSubject { get; set; }

    public int? MorningInitialHour { get; set; }

    public int? MorningFinalHour { get; set; }

    public int? AfternoonInitialHour { get; set; }

    public int? AfternoonFinalHour { get; set; }

    public bool? HasTreatment { get; set; }

    public virtual ICollection<AccessHistoryAttendance> AccessHistoryAttendances { get; } = new List<AccessHistoryAttendance>();

    public virtual ICollection<AccessMannerByProgram> AccessMannerByPrograms { get; } = new List<AccessMannerByProgram>();

    public virtual ICollection<AccessOrderByProgram> AccessOrderByPrograms { get; } = new List<AccessOrderByProgram>();

    public virtual ICollection<AccessProcedureByProgram> AccessProcedureByPrograms { get; } = new List<AccessProcedureByProgram>();

    public virtual ICollection<AccessProfile> AccessProfiles { get; } = new List<AccessProfile>();

    public virtual Account? Account { get; set; }

    public virtual ICollection<AccountExamTypeByProgram> AccountExamTypeByPrograms { get; } = new List<AccountExamTypeByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByPrograms { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<ActionCategory> ActionCategories { get; } = new List<ActionCategory>();

    public virtual ICollection<ActionConfiguration> ActionConfigurations { get; } = new List<ActionConfiguration>();

    public virtual AkkaActor? AkkaActors { get; set; }

    public virtual ICollection<Benefit> Benefits { get; } = new List<Benefit>();

    public virtual ICollection<Campaign> Campaigns { get; } = new List<Campaign>();

    public virtual ICollection<Caregiver> Caregivers { get; } = new List<Caregiver>();

    public virtual ICollection<ChatDialog> ChatDialogs { get; } = new List<ChatDialog>();

    public virtual ICollection<Chat> Chats { get; } = new List<Chat>();

    public virtual ICollection<Communication> Communications { get; } = new List<Communication>();

    public virtual ICollection<CoverageArea> CoverageAreas { get; } = new List<CoverageArea>();

    public virtual ICollection<DiagnosticExam> DiagnosticExams { get; } = new List<DiagnosticExam>();

    public virtual ICollection<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

    public virtual ICollection<DoctorByProgram> DoctorByPrograms { get; } = new List<DoctorByProgram>();

    public virtual ICollection<DoctorsRepresentative> DoctorsRepresentatives { get; } = new List<DoctorsRepresentative>();

    public virtual ICollection<Email> Emails { get; } = new List<Email>();

    public virtual ICollection<ExamDefinitionSettingsByProgram> ExamDefinitionSettingsByPrograms { get; } = new List<ExamDefinitionSettingsByProgram>();

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual ICollection<HealthProgramDisease> HealthProgramDiseases { get; } = new List<HealthProgramDisease>();

    public virtual ICollection<HealthProgramExamByEntity> HealthProgramExamByEntities { get; } = new List<HealthProgramExamByEntity>();

    public virtual ICollection<HealthProgramTemplateSetting> HealthProgramTemplateSettings { get; } = new List<HealthProgramTemplateSetting>();

    public virtual ICollection<IncidentItem> IncidentItems { get; } = new List<IncidentItem>();

    public virtual ICollection<IncidentProduct> IncidentProducts { get; } = new List<IncidentProduct>();

    public virtual ICollection<IncidentSubject> IncidentSubjects { get; } = new List<IncidentSubject>();

    public virtual ICollection<IncidentTypeDetailProgram> IncidentTypeDetailPrograms { get; } = new List<IncidentTypeDetailProgram>();

    public virtual ICollection<Incident> Incidents { get; } = new List<Incident>();

    public virtual ICollection<InformationCollect> InformationCollects { get; } = new List<InformationCollect>();

    public virtual ICollection<Infusion> Infusions { get; } = new List<Infusion>();

    public virtual ICollection<JsRulesByEntity> JsRulesByEntities { get; } = new List<JsRulesByEntity>();

    public virtual Account? LogisticPartner { get; set; }

    public virtual ICollection<Logistics> Logistics { get; } = new List<Logistics>();

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsStuff> LogisticsStuffs { get; } = new List<LogisticsStuff>();

    public virtual StringMap? LogisticsTypeStringMap { get; set; }

    public virtual ICollection<MedicamentAccess> MedicamentAccesses { get; } = new List<MedicamentAccess>();

    public virtual ICollection<PatientSalesOrder> PatientSalesOrders { get; } = new List<PatientSalesOrder>();

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();

    public virtual ICollection<PhoneCall> PhoneCalls { get; } = new List<PhoneCall>();

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();

    public virtual ICollection<RegionalManager> RegionalManagers { get; } = new List<RegionalManager>();

    public virtual ICollection<SchedulingHistory> SchedulingHistories { get; } = new List<SchedulingHistory>();

    public virtual ICollection<Sms> Sms { get; } = new List<Sms>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<Survey> Surveys { get; } = new List<Survey>();

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();

    public virtual ICollection<Template> Templates { get; } = new List<Template>();

    public virtual ICollection<TherapeuticHistory> TherapeuticHistories { get; } = new List<TherapeuticHistory>();

    public virtual ICollection<TrainingRecord> TrainingRecords { get; } = new List<TrainingRecord>();

    public virtual ICollection<TreatmentPayment> TreatmentPayments { get; } = new List<TreatmentPayment>();

    public virtual ICollection<TreatmentSetting> TreatmentSettings { get; } = new List<TreatmentSetting>();

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();

    public virtual ICollection<UserSystemLog> UserSystemLogs { get; } = new List<UserSystemLog>();

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual ICollection<VoucherConfiguration> VoucherConfigurations { get; } = new List<VoucherConfiguration>();

    public virtual ICollection<Voucher> Vouchers { get; } = new List<Voucher>();

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual ICollection<CommunicationTypeByProgram> CommunicationTypeByPrograms { get; } = new List<CommunicationTypeByProgram>();

    public virtual ICollection<ExamDefinition> ExamDefinitions { get; } = new List<ExamDefinition>();

    public virtual ICollection<HealthProfessional> HealthProfessionals { get; } = new List<HealthProfessional>();

    public virtual ICollection<MedicamentCompetitor> MedicamentCompetitors { get; } = new List<MedicamentCompetitor>();

    public virtual ICollection<Medicament> Medicaments { get; } = new List<Medicament>();

    public virtual ICollection<MedicationNonadherenceReason> MedicationNonadherenceReasons { get; } = new List<MedicationNonadherenceReason>();

    public virtual ICollection<ServiceType> ServiceTypes { get; } = new List<ServiceType>();

    public virtual ICollection<TreatmentStatusDetail> TreatmentStatusDetails { get; } = new List<TreatmentStatusDetail>();

    public virtual ICollection<UserPasswordHistory> UserPasswordHistorys { get; } = new List<UserPasswordHistory>();

    public virtual ICollection<Unsubscribe> Unsubscribes { get; } = new List<Unsubscribe>();

    public virtual ICollection<UrlShortener> UrlShorteners { get; set; }

    public virtual ICollection<ClickTracking> ClickTrackings { get; set; }

    public virtual ICollection<TemplateConfiguration> TemplateConfigurations { get; set; }    
}
