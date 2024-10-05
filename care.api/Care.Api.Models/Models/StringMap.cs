using Care.Api.Models.Models;

namespace Care.Api.Models;
public partial class StringMap
{
    public Guid StringMapId { get; set; }

    public Guid EntityMetadataId { get; set; }

    public string? EntityMetadataIdName { get; set; }

    public Guid AttributeMetadataId { get; set; }

    public string? AttributeMetadataIdName { get; set; }

    public int? OptionValue { get; set; }

    public string? OptionName { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsDisabled { get; set; }

    public string? OptionNameLangEn { get; set; }

    public Guid? ProgramId { get; set; }

    public bool? IsSystemOption { get; set; }

    public string? Flag { get; set; }

    public virtual ICollection<AccessHistoryAttendance> AccessHistoryAttendanceDetailDifficultyWithAccessStringMaps { get; } = new List<AccessHistoryAttendance>();

    public virtual ICollection<AccessHistoryAttendance> AccessHistoryAttendanceDetailDifficultyWithDocumentsStringMaps { get; } = new List<AccessHistoryAttendance>();

    public virtual ICollection<AccessHistoryAttendance> AccessHistoryAttendanceDetailNoDifficultyWithAccessStringMaps { get; } = new List<AccessHistoryAttendance>();

    public virtual ICollection<AccessHistoryAttendance> AccessHistoryAttendanceStatusCodeStringMaps { get; } = new List<AccessHistoryAttendance>();

    public virtual ICollection<AccessHistoryAttendance> AccessHistoryAttendanceWaiverDetailStringMaps { get; } = new List<AccessHistoryAttendance>();

    public virtual ICollection<AccessMannerByProgram> AccessMannerByPrograms { get; } = new List<AccessMannerByProgram>();

    public virtual ICollection<AccessManner> AccessManners { get; } = new List<AccessManner>();

    public virtual ICollection<AccessOrderByProgram> AccessOrderByPrograms { get; } = new List<AccessOrderByProgram>();

    public virtual ICollection<AccessProcedureByProgram> AccessProcedureByPrograms { get; } = new List<AccessProcedureByProgram>();

    public virtual ICollection<AccessProfile> AccessProfileAccessProfileTypeStringMaps { get; } = new List<AccessProfile>();

    public virtual ICollection<AccessProfile> AccessProfileStatusCodeStringMaps { get; } = new List<AccessProfile>();

    public virtual ICollection<AccessRightEntity> AccessRightEntities { get; } = new List<AccessRightEntity>();

    public virtual ICollection<AccessWay> AccessWays { get; } = new List<AccessWay>();

    public virtual ICollection<Account> AccountAccessCoverageAreaStringMaps { get; } = new List<Account>();

    public virtual ICollection<Account> AccountAccountTypeStringMaps { get; } = new List<Account>();

    public virtual ICollection<Account> AccountClinicPublicOrPrivateStringMaps { get; } = new List<Account>();

    public virtual ICollection<Account> AccountClinicTypeStringMaps { get; } = new List<Account>();

    public virtual ICollection<Account> AccountCustom1StringMaps { get; } = new List<Account>();


    public virtual ICollection<Account> AccountCustom2StringMaps { get; } = new List<Account>();


    public virtual ICollection<Account> AccountCustom3StringMaps { get; } = new List<Account>();


    public virtual ICollection<Account> AccountCustom4StringMaps { get; } = new List<Account>();


    public virtual ICollection<Account> AccountCustom5StringMaps { get; } = new List<Account>();


    public virtual ICollection<Account> AccountCustom6StringMaps { get; } = new List<Account>();


    public virtual ICollection<Account> AccountCustom7StringMaps { get; } = new List<Account>();

    public virtual ICollection<AccountCoverageArea> AccountCoverageAreas { get; } = new List<AccountCoverageArea>();

    public virtual ICollection<AccountExamTypeByProgram> AccountExamTypeByPrograms { get; } = new List<AccountExamTypeByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramAccountStatusStringMaps { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramExamTypeStringMaps { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramPatientTypeStringMaps { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramStatusCodeStringMaps { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramCustom1StringMaps { get; } = new List<AccountSettingsByProgram>();


    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramCustom2StringMaps { get; } = new List<AccountSettingsByProgram>();


    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramCustom3StringMaps { get; } = new List<AccountSettingsByProgram>();


    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramCustom4StringMaps { get; } = new List<AccountSettingsByProgram>();


    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramCustom5StringMaps { get; } = new List<AccountSettingsByProgram>();


    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramCustom6StringMaps { get; } = new List<AccountSettingsByProgram>();


    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByProgramCustom7StringMaps { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<Account> AccountStatusCodeStringMaps { get; } = new List<Account>();

    public virtual ICollection<ActionCategory> ActionCategories { get; } = new List<ActionCategory>();

    public virtual ICollection<ActionConfiguration> ActionConfigurationActionOwnerStringMaps { get; } = new List<ActionConfiguration>();

    public virtual ICollection<ActionConfiguration> ActionConfigurationStatusCodeStringMaps { get; } = new List<ActionConfiguration>();

    public virtual ICollection<ActionRule> ActionRules { get; } = new List<ActionRule>();

    public virtual ICollection<AdhesionAttendance> AdhesionAttendanceDetailDifficultyWithAccessStringMaps { get; } = new List<AdhesionAttendance>();

    public virtual ICollection<AdhesionAttendance> AdhesionAttendanceFrequencyStringMaps { get; } = new List<AdhesionAttendance>();

    public virtual ICollection<AdhesionAttendance> AdhesionAttendanceOriginStringMaps { get; } = new List<AdhesionAttendance>();

    public virtual ICollection<AdhesionAttendance> AdhesionAttendanceStatusCodeStringMaps { get; } = new List<AdhesionAttendance>();

    public virtual ICollection<AdhesionAttendance> AdhesionAttendanceTreatmentIntervalStringMaps { get; } = new List<AdhesionAttendance>();

    public virtual ICollection<Annotation> AnnotationAnnotationTypeStringMaps { get; } = new List<Annotation>();

    public virtual ICollection<Annotation> AnnotationStatusCodeStringMaps { get; } = new List<Annotation>();

    public virtual ICollection<Attachment> Attachments { get; } = new List<Attachment>();

    public virtual ICollection<AttemptCallLog> AttemptCallLogs { get; } = new List<AttemptCallLog>();

    public virtual AttributeMetadata? AttributeMetadata { get; set; }

    public virtual ICollection<Bank> Banks { get; } = new List<Bank>();

    public virtual ICollection<Benefit> BenefitBenefitStatusStringMaps { get; } = new List<Benefit>();

    public virtual ICollection<Benefit> BenefitBenefitTypeStringMaps { get; } = new List<Benefit>();

    public virtual ICollection<Benefit> BenefitCustom1StringMaps { get; } = new List<Benefit>();

    public virtual ICollection<Benefit> BenefitCustom2StringMaps { get; } = new List<Benefit>();

    public virtual ICollection<Benefit> BenefitSourceStringMaps { get; } = new List<Benefit>();

    public virtual ICollection<Benefit> BenefitStatusCodeStringMaps { get; } = new List<Benefit>();

    public virtual ICollection<CalendarScheduled> CalendarScheduledScheduleTypeStringMapStringMaps { get; } = new List<CalendarScheduled>();

    public virtual ICollection<CalendarScheduled> CalendarScheduledStatusCodeStringMaps { get; } = new List<CalendarScheduled>();

    public virtual ICollection<Campaign> CampaignStatusCodeStringMaps { get; } = new List<Campaign>();

    public virtual ICollection<Campaign> CampaignStatusStringMaps { get; } = new List<Campaign>();

    public virtual ICollection<Caregiver> CaregiverCivilStatusStringMaps { get; } = new List<Caregiver>();

    public virtual ICollection<Caregiver> CaregiverEducationStringMaps { get; } = new List<Caregiver>();

    public virtual ICollection<Caregiver> CaregiverGenderStringMaps { get; } = new List<Caregiver>();

    public virtual ICollection<Caregiver> CaregiverKinshipStringMaps { get; } = new List<Caregiver>();

    public virtual ICollection<Caregiver> CaregiverStatusCodeStringMaps { get; } = new List<Caregiver>();

    public virtual ICollection<Chat> ChatChatTypeStringMaps { get; } = new List<Chat>();

    public virtual ICollection<ChatDialog> ChatDialogs { get; } = new List<ChatDialog>();

    public virtual ICollection<Chat> ChatStatusCodeStringMaps { get; } = new List<Chat>();

    public virtual ICollection<CommunicationTypeByProgram> CommunicationTypeByPrograms { get; } = new List<CommunicationTypeByProgram>();

    public virtual ICollection<Communication> Communications { get; } = new List<Communication>();

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();

    public virtual ICollection<CoverageArea> CoverageAreas { get; } = new List<CoverageArea>();

    public virtual ICollection<CustomerAddress> CustomerAddressAddressTypeStringMaps { get; } = new List<CustomerAddress>();

    public virtual ICollection<CustomerAddress> CustomerAddressStatusCodeStringMaps { get; } = new List<CustomerAddress>();

    public virtual ICollection<Diagnostic> DiagnosticAddressTypeStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticCategoryOfExamsStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticDiagnosticStatusDetailStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticDiagnosticStatusStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticEthnicityStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<DiagnosticExam> DiagnosticExamDiagnosticStatusStringMaps { get; } = new List<DiagnosticExam>();

    public virtual ICollection<DiagnosticExam> DiagnosticExamExamTypeStringMaps { get; } = new List<DiagnosticExam>();

    public virtual ICollection<DiagnosticExam> DiagnosticExamStatusCodeStringMaps { get; } = new List<DiagnosticExam>();

    public virtual ICollection<Diagnostic> DiagnosticFridayStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticGenderStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticKinshipStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticMainContactStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticMondayStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticPatientSourceStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticPreferredTimeStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticPrescriptionStatusStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticSaturdayStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticSourceConsentStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticStageOfDiseaseStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticStatusCodeStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticThursdayStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticTreatmentLine2StringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticTreatmentLineStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticTuesdayStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticTypeOfAnalysisStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticWednesdayStringMaps { get; } = new List<Diagnostic>();

    public virtual ICollection<Diagnostic> DiagnosticCustom1StringMaps { get; } = new List<Diagnostic>();


    public virtual ICollection<Diagnostic> DiagnosticCustom2StringMaps { get; } = new List<Diagnostic>();


    public virtual ICollection<Diagnostic> DiagnosticCustom3StringMaps { get; } = new List<Diagnostic>();


    public virtual ICollection<Diagnostic> DiagnosticCustom4StringMaps { get; } = new List<Diagnostic>();


    public virtual ICollection<Diagnostic> DiagnosticCustom5StringMaps { get; } = new List<Diagnostic>();


    public virtual ICollection<Diagnostic> DiagnosticCustom6StringMaps { get; } = new List<Diagnostic>();


    public virtual ICollection<Diagnostic> DiagnosticCustom7StringMaps { get; } = new List<Diagnostic>();


    public virtual ICollection<Disease> Diseases { get; } = new List<Disease>();

    public virtual ICollection<DoctorByProgram> DoctorByProgramAuthorizeSmsstringMaps { get; } = new List<DoctorByProgram>();

    public virtual ICollection<DoctorByProgram> DoctorByProgramAuthorizeVisitStringMaps { get; } = new List<DoctorByProgram>();

    public virtual ICollection<DoctorByProgram> DoctorByProgramAuthorizesTitrationofDosageStringMaps { get; } = new List<DoctorByProgram>();

    public virtual ICollection<DoctorByProgram> DoctorByProgramSourceConsentStringMaps { get; } = new List<DoctorByProgram>();

    public virtual ICollection<DoctorByProgram> DoctorByProgramStatusCodeStringMaps { get; } = new List<DoctorByProgram>();

    public virtual ICollection<Doctor> DoctorGenderStringMaps { get; } = new List<Doctor>();

    public virtual ICollection<Doctor> DoctorLicenseStatusStringMaps { get; } = new List<Doctor>();

    public virtual ICollection<Doctor> DoctorLicenseTypeStringMaps { get; } = new List<Doctor>();

    public virtual ICollection<Doctor> DoctorStatusCodeStringMaps { get; } = new List<Doctor>();

    public virtual ICollection<DoctorsRepresentative> DoctorsRepresentatives { get; } = new List<DoctorsRepresentative>();

    public virtual ICollection<EmailBoxSetting> EmailBoxSettings { get; } = new List<EmailBoxSetting>();

    public virtual ICollection<Email> Emails { get; } = new List<Email>();

    public virtual ICollection<ExamDefinition> ExamDefinitionExamTypeStringMaps { get; } = new List<ExamDefinition>();

    public virtual ICollection<ExamDefinitionSettingsByProgram> ExamDefinitionSettingsByPrograms { get; } = new List<ExamDefinitionSettingsByProgram>();

    public virtual ICollection<ExamDefinition> ExamDefinitionStatusCodeStringMaps { get; } = new List<ExamDefinition>();

    public virtual ICollection<Exam> ExamExamStatusStringMaps { get; } = new List<Exam>();

    public virtual ICollection<Exam> ExamOwnershipLevelStringMaps { get; } = new List<Exam>();

    public virtual ICollection<Exam> ExamReschedulingReasonStringMaps { get; } = new List<Exam>();

    public virtual ICollection<Exam> ExamResultStringMaps { get; } = new List<Exam>();

    public virtual ICollection<Exam> ExamScheduleSourceStringMaps { get; } = new List<Exam>();

    public virtual ICollection<Exam> ExamStatusCodeStringMaps { get; } = new List<Exam>();

    public virtual ICollection<Exam> ExamWithdrawalPreferenceStringMaps { get; } = new List<Exam>();

    public virtual ICollection<HealthProfessional> HealthProfessionalBankAccountTypeStringMaps { get; } = new List<HealthProfessional>();

    public virtual ICollection<HealthProfessionalByProgram> HealthProfessionalByProgramNurceStatusStringMaps { get; } = new List<HealthProfessionalByProgram>();

    public virtual ICollection<HealthProfessionalByProgram> HealthProfessionalByProgramStatusCodeStringMaps { get; } = new List<HealthProfessionalByProgram>();

    public virtual ICollection<HealthProfessional> HealthProfessionalGenderStringMaps { get; } = new List<HealthProfessional>();

    public virtual ICollection<HealthProfessional> HealthProfessionalHiringTypeStringMaps { get; } = new List<HealthProfessional>();

    public virtual ICollection<HealthProfessional> HealthProfessionalNurseProfessionalTypeStringMaps { get; } = new List<HealthProfessional>();

    public virtual ICollection<HealthProfessional> HealthProfessionalProfessionalLicenseTypeStringMaps { get; } = new List<HealthProfessional>();

    public virtual ICollection<HealthProfessional> HealthProfessionalStatusCodeStringMaps { get; } = new List<HealthProfessional>();

    public virtual ICollection<HealthProgramDiseaseExam> HealthProgramDiseaseExamExamTypeStringMaps { get; } = new List<HealthProgramDiseaseExam>();

    public virtual ICollection<HealthProgramDiseaseExam> HealthProgramDiseaseExamStatusCodeStringMaps { get; } = new List<HealthProgramDiseaseExam>();

    public virtual ICollection<HealthProgramDisease> HealthProgramDiseases { get; } = new List<HealthProgramDisease>();

    public virtual ICollection<HealthProgramExamByEntity> HealthProgramExamByEntities { get; } = new List<HealthProgramExamByEntity>();

    public virtual ICollection<HealthProgram> HealthProgramLogisticsTypeStringMaps { get; } = new List<HealthProgram>();

    public virtual ICollection<HealthProgram> HealthProgramStatusCodeStringMaps { get; } = new List<HealthProgram>();

    public virtual ICollection<HealthProgramTemplateSetting> HealthProgramTemplateSettingStatusCodeStringMaps { get; } = new List<HealthProgramTemplateSetting>();

    public virtual ICollection<HealthProgramTemplateSetting> HealthProgramTemplateSettingTemplateTypeStringMapStringMaps { get; } = new List<HealthProgramTemplateSetting>();

    public virtual ICollection<Incident> IncidentAccountTypeStringMaps { get; } = new List<Incident>();

    public virtual ICollection<Incident> IncidentContactTypeStringMaps { get; } = new List<Incident>();

    public virtual ICollection<Incident> IncidentCustom1StringMaps { get; } = new List<Incident>();

    public virtual ICollection<Incident> IncidentCustom2StringMaps { get; } = new List<Incident>();

    public virtual ICollection<Incident> IncidentCustomerTypeStringMaps { get; } = new List<Incident>();

    public virtual ICollection<IncidentItem> IncidentItemGenderStringMaps { get; } = new List<IncidentItem>();

    public virtual ICollection<IncidentItem> IncidentItemStatusCodeStringMaps { get; } = new List<IncidentItem>();

    public virtual ICollection<Incident> IncidentOriginStringMaps { get; } = new List<Incident>();

    public virtual ICollection<Incident> IncidentPrescriptionStatusStringMaps { get; } = new List<Incident>();

    public virtual ICollection<IncidentProduct> IncidentProducts { get; } = new List<IncidentProduct>();

    public virtual ICollection<Incident> IncidentRequestStatusStringMaps { get; } = new List<Incident>();

    public virtual ICollection<Incident> IncidentStatusCodeStringMaps { get; } = new List<Incident>();

    public virtual ICollection<Incident> IncidentStatusStringMaps { get; } = new List<Incident>();

    public virtual ICollection<IncidentSubject> IncidentSubjects { get; } = new List<IncidentSubject>();

    public virtual ICollection<Incident> IncidentTreatmentLineStringMaps { get; } = new List<Incident>();

    public virtual ICollection<IncidentTypeDetailProgram> IncidentTypeDetailPrograms { get; } = new List<IncidentTypeDetailProgram>();

    public virtual ICollection<IncidentTypeDetail> IncidentTypeDetails { get; } = new List<IncidentTypeDetail>();

    public virtual ICollection<IncidentType> IncidentTypes { get; } = new List<IncidentType>();

    public virtual ICollection<InformationCollect> InformationCollectCollectionDiagnosisStringMaps { get; } = new List<InformationCollect>();

    public virtual ICollection<InformationCollect> InformationCollectPlaceOfCollectionStringMaps { get; } = new List<InformationCollect>();

    public virtual ICollection<InformationCollect> InformationCollectStatusCodeStringMaps { get; } = new List<InformationCollect>();

    public virtual ICollection<InformationVisit> InformationVisitAbsenceJustificationStringMaps { get; } = new List<InformationVisit>();

    public virtual ICollection<InformationVisit> InformationVisitStatusCodeStringMaps { get; } = new List<InformationVisit>();

    public virtual ICollection<InformationVisit> InformationVisitVisitStatusStringMaps { get; } = new List<InformationVisit>();

    public virtual ICollection<Infusion> InfusionApplicationTypeStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionInfusionDispatchNumberStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionInfusionPlaceTypeStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionInfusionStatusStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionInfusionTypeStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionInfusionWeekStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionReasonInfusionNotDoneStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionStatusCodeStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<Infusion> InfusionSupportFieldStringMaps { get; } = new List<Infusion>();

    public virtual ICollection<JsRulesByEntity> JsRulesByEntities { get; } = new List<JsRulesByEntity>();

    public virtual ICollection<Logistics> LogisticCustom1StringMaps { get; } = new List<Logistics>();

    public virtual ICollection<Logistics> LogisticCustom2StringMaps { get; } = new List<Logistics>();

    public virtual ICollection<Logistics> LogisticIncidentStatusStringMaps { get; } = new List<Logistics>();

    public virtual ICollection<Logistics> LogisticIntegrationStatusStringMaps { get; } = new List<Logistics>();

    public virtual ICollection<Logistics> LogisticLogisticsTypeStringMaps { get; } = new List<Logistics>();

    public virtual ICollection<Logistics> LogisticSendStatusStringMaps { get; } = new List<Logistics>();

    public virtual ICollection<Logistics> LogisticSendSubStatusStringMaps { get; } = new List<Logistics>();

    public virtual ICollection<Logistics> LogisticStatusCodeStringMaps { get; } = new List<Logistics>();

    public virtual ICollection<Logistics> LogisticUcbKitSentReasonStringMaps { get; } = new List<Logistics>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleChosenExamTypeStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleIntegrationStatusStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsScheduleItem> LogisticsScheduleItems { get; } = new List<LogisticsScheduleItem>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleKitTypeStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleLocalDeliveryWithdrawStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleLocalTypeStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleLogisticsScheduleTypeStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsSchedulePreferredTimeStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleScheduleStatusStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleStatusCodeStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleStorageTubeTypeStringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsSchedule> LogisticsScheduleCustom1StringMaps { get; } = new List<LogisticsSchedule>();


    public virtual ICollection<LogisticsSchedule> LogisticsScheduleCustom2StringMaps { get; } = new List<LogisticsSchedule>();


    public virtual ICollection<LogisticsSchedule> LogisticsScheduleCustom3StringMaps { get; } = new List<LogisticsSchedule>();


    public virtual ICollection<LogisticsSchedule> LogisticsScheduleCustom4StringMaps { get; } = new List<LogisticsSchedule>();


    public virtual ICollection<LogisticsSchedule> LogisticsScheduleCustom5StringMaps { get; } = new List<LogisticsSchedule>();


    public virtual ICollection<LogisticsSchedule> LogisticsScheduleCustom6StringMaps { get; } = new List<LogisticsSchedule>();


    public virtual ICollection<LogisticsSchedule> LogisticsScheduleCustom7StringMaps { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<LogisticsStuff> LogisticsStuffLogisticsStuffTypeStringMaps { get; } = new List<LogisticsStuff>();

    public virtual ICollection<LogisticsStuff> LogisticsStuffStatusCodeStringMaps { get; } = new List<LogisticsStuff>();

    public virtual ICollection<LogisticsStuff> LogisticsStuffStuffStatusStringMaps { get; } = new List<LogisticsStuff>();

    public virtual ICollection<MedicalSpecialty> MedicalSpecialties { get; } = new List<MedicalSpecialty>();

    public virtual ICollection<MedicamentAccess> MedicamentAccessAccessStatusStringMaps { get; } = new List<MedicamentAccess>();

    public virtual ICollection<MedicamentAccess> MedicamentAccessAccessSubStatusStringMaps { get; } = new List<MedicamentAccess>();

    public virtual ICollection<MedicamentAccess> MedicamentAccessAccessTypeStringMaps { get; } = new List<MedicamentAccess>();

    public virtual ICollection<MedicamentAccess> MedicamentAccessDetailDifficultyWithAccessStringMaps { get; } = new List<MedicamentAccess>();

    public virtual ICollection<MedicamentAccess> MedicamentAccessDetailDifficultyWithDocumentsStringMaps { get; } = new List<MedicamentAccess>();

    public virtual ICollection<MedicamentAccess> MedicamentAccessDetailNoDifficultyWithAccessStringMaps { get; } = new List<MedicamentAccess>();

    public virtual ICollection<MedicamentAccess> MedicamentAccessStatusCodeStringMaps { get; } = new List<MedicamentAccess>();

    public virtual ICollection<MedicamentCompetitor> MedicamentCompetitors { get; } = new List<MedicamentCompetitor>();

    public virtual ICollection<MedicamentConcomitant> MedicamentConcomitants { get; } = new List<MedicamentConcomitant>();

    public virtual ICollection<Medicament> Medicaments { get; } = new List<Medicament>();

    public virtual ICollection<MedicationNonadherenceReason> MedicationNonadherenceReasons { get; } = new List<MedicationNonadherenceReason>();

    public virtual ICollection<Occupation> Occupations { get; } = new List<Occupation>();

    public virtual ICollection<Patient> PatientCivilStatusStringMaps { get; } = new List<Patient>();

    public virtual ICollection<Patient> PatientEducationStringMaps { get; } = new List<Patient>();

    public virtual ICollection<Patient> PatientGenderStringMaps { get; } = new List<Patient>();

    public virtual ICollection<Patient> PatientPatientTypeStringMaps { get; } = new List<Patient>();

    public virtual ICollection<PatientSalesOrder> PatientSalesOrderPatientSourceStringMaps { get; } = new List<PatientSalesOrder>();

    public virtual ICollection<PatientSalesOrder> PatientSalesOrderSolicitorStringMaps { get; } = new List<PatientSalesOrder>();

    public virtual ICollection<PatientSalesOrder> PatientSalesOrderStatusCodeStringMaps { get; } = new List<PatientSalesOrder>();

    public virtual ICollection<Patient> PatientStatusCodeStringMaps { get; } = new List<Patient>();

    public virtual ICollection<Pharmacovigilance> Pharmacovigilances { get; } = new List<Pharmacovigilance>();

    public virtual ICollection<Phase> Phases { get; } = new List<Phase>();

    public virtual ICollection<PhoneCall> PhoneCallPhoneCallStatusStringMaps { get; } = new List<PhoneCall>();

    public virtual ICollection<PhoneCall> PhoneCallPhoneCallTypeStringMaps { get; } = new List<PhoneCall>();

    public virtual ICollection<PhoneCall> PhoneCallStatusCodeStringMaps { get; } = new List<PhoneCall>();

    public virtual ICollection<PhoneCall> PhoneCallUnSuccessfulReasonStringMaps { get; } = new List<PhoneCall>();

    public virtual ICollection<Posologe> Posologes { get; } = new List<Posologe>();

    public virtual ICollection<PostalCode> PostalCodeAddressTypeStringMaps { get; } = new List<PostalCode>();

    public virtual ICollection<PostalCodeCity> PostalCodeCities { get; } = new List<PostalCodeCity>();

    public virtual ICollection<PostalCodeState> PostalCodeStates { get; } = new List<PostalCodeState>();

    public virtual ICollection<PostalCode> PostalCodeStatusCodeStringMaps { get; } = new List<PostalCode>();

    public virtual ICollection<Purchase> PurchaseFrequencyStringMaps { get; } = new List<Purchase>();

    public virtual ICollection<Purchase> PurchasePrescriptionTypeStringMaps { get; } = new List<Purchase>();

    public virtual ICollection<Purchase> PurchaseStatusCodeStringMaps { get; } = new List<Purchase>();

    public virtual ICollection<QuestionOption> QuestionOptions { get; } = new List<QuestionOption>();

    public virtual ICollection<Question> Questions { get; } = new List<Question>();

    public virtual ICollection<RegardingEntity> RegardingEntities { get; } = new List<RegardingEntity>();

    public virtual ICollection<RegionalManager> RegionalManagers { get; } = new List<RegionalManager>();

    public virtual ICollection<Representative> Representatives { get; } = new List<Representative>();

    public virtual ICollection<ResourceWorkSetting> ResourceWorkSettingCalendarTypeStringMapStringMaps { get; } = new List<ResourceWorkSetting>();

    public virtual ICollection<ResourceWorkSetting> ResourceWorkSettingStatusCodeStringMaps { get; } = new List<ResourceWorkSetting>();

    public virtual ICollection<SchedulingHistory> SchedulingHistoryReschedulingReasonStringMaps { get; } = new List<SchedulingHistory>();

    public virtual ICollection<SchedulingHistory> SchedulingHistoryStatusCodeStringMaps { get; } = new List<SchedulingHistory>();

    public virtual ICollection<ServiceType> ServiceTypes { get; } = new List<ServiceType>();

    public virtual ICollection<Sms> SmSmsStatusStringMaps { get; } = new List<Sms>();

    public virtual ICollection<Sms> SmSmsTypeStringMaps { get; } = new List<Sms>();

    public virtual ICollection<Sms> SmStatusCodeStringMaps { get; } = new List<Sms>();

    public virtual ICollection<Sms> SmSubjectTypeStringMaps { get; } = new List<Sms>();

    public virtual ICollection<StrengthMedicament> StrengthMedicaments { get; } = new List<StrengthMedicament>();

    public virtual ICollection<Subject> Subjects { get; } = new List<Subject>();

    public virtual ICollection<SurveyQuestionList> SurveyQuestionLists { get; } = new List<SurveyQuestionList>();

    public virtual ICollection<SurveyResponseLine> SurveyResponseLines { get; } = new List<SurveyResponseLine>();

    public virtual ICollection<SurveyResponse> SurveyResponses { get; } = new List<SurveyResponse>();

    public virtual ICollection<Survey> SurveyStatusCodeStringMaps { get; } = new List<Survey>();

    public virtual ICollection<Survey> SurveySurveyTypeStringMaps { get; } = new List<Survey>();

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();

    public virtual ICollection<Template> TemplateSmsTypeStringMaps { get; } = new List<Template>();

    public virtual ICollection<Template> TemplateStatusCodeStringMaps { get; } = new List<Template>();

    public virtual ICollection<Template> TemplateTemplateTypeStringMaps { get; } = new List<Template>();

    public virtual ICollection<TherapeuticHistory> TherapeuticHistoryDosageUnitStringMaps { get; } = new List<TherapeuticHistory>();

    public virtual ICollection<TherapeuticHistory> TherapeuticHistoryStatusCodeStringMaps { get; } = new List<TherapeuticHistory>();

    public virtual ICollection<TherapeuticHistory> TherapeuticHistorySupplyMethodStringMaps { get; } = new List<TherapeuticHistory>();

    public virtual ICollection<TherapeuticType> TherapeuticTypes { get; } = new List<TherapeuticType>();

    public virtual ICollection<TrainingRecord> TrainingRecordStatusCodeStringMaps { get; } = new List<TrainingRecord>();

    public virtual ICollection<TrainingRecord> TrainingRecordTrainingRecordTypeStringMaps { get; } = new List<TrainingRecord>();

    public virtual ICollection<Treatment> TreatmentAccessTypeStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<TreatmentAddress> TreatmentAddressAddressTypeStringMaps { get; } = new List<TreatmentAddress>();

    public virtual ICollection<TreatmentAddress> TreatmentAddressStatusCodeStringMaps { get; } = new List<TreatmentAddress>();

    public virtual ICollection<TreatmentAndDiagnosticAction> TreatmentAndDiagnosticActions { get; } = new List<TreatmentAndDiagnosticAction>();

    public virtual ICollection<TreatmentAttendance> TreatmentAttendances { get; } = new List<TreatmentAttendance>();

    public virtual ICollection<Treatment> TreatmentCivilStatusStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentContractTypeStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentCustom1StringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentCustom2StringMaps { get; } = new List<Treatment>();
    public virtual ICollection<Treatment> TreatmentCustom3StringMaps { get; } = new List<Treatment>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataAccessDetailStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataApplicatorTypeStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataContractHasCoparticipationStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataContractTypeStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataCustom1StringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataCustom2StringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataDoctorAuthorizesDosageTitrationStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataFormofAccessStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataHemophiliaDegreeStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataIfxitstatusStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataIfxotstatusStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataInfusionTypeStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataIsWorkingStringMapStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataJanssenitstatusStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataJanssenotstatusStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataMedicalIndicationStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataMedicalInstructionAccessWayStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataOptimizationTypeStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataPatientTypeStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataPlanCoverageStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataReasonForNotAcceptingSmsstringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataRiskRatingStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataStageOfDiseaseStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataStatusCodeStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataStorageLocationStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataSupplyMethodStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataTreatmentCyclesStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataTreatmentIntervalStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataTreatmentTypeStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<TreatmentCustomData> TreatmentCustomDataVisitRefusalReasonStringMaps { get; } = new List<TreatmentCustomData>();

    public virtual ICollection<Treatment> TreatmentDosageUnitStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentEducationStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentGenderStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<TreatmentHistory> TreatmentHistoryHistoryModalityStringMaps { get; } = new List<TreatmentHistory>();

    public virtual ICollection<TreatmentHistory> TreatmentHistoryHistoryPhaseStringMaps { get; } = new List<TreatmentHistory>();

    public virtual ICollection<TreatmentHistory> TreatmentHistoryHistoryStatusDetailStringMaps { get; } = new List<TreatmentHistory>();

    public virtual ICollection<TreatmentHistory> TreatmentHistoryHistoryStatusStringMaps { get; } = new List<TreatmentHistory>();

    public virtual ICollection<TreatmentHistory> TreatmentHistoryStatusCodeStringMaps { get; } = new List<TreatmentHistory>();

    public virtual ICollection<Treatment> TreatmentKinshipStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentMainContactStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentModalityStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentPatientSourceStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<TreatmentPayment> TreatmentPaymentStatusCodeStringMaps { get; } = new List<TreatmentPayment>();

    public virtual ICollection<TreatmentPayment> TreatmentPaymentTreatmentPaymentStatusStringMaps { get; } = new List<TreatmentPayment>();

    public virtual ICollection<Treatment> TreatmentPhaseStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentPreferredTimeStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentPrescriptionStatusStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentReasonInactivationStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<TreatmentSetting> TreatmentSettings { get; } = new List<TreatmentSetting>();

    public virtual ICollection<TreatmentSituation> TreatmentSituations { get; } = new List<TreatmentSituation>();

    public virtual ICollection<Treatment> TreatmentSourceConsentStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentStageOfDiseaseStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentStatusCodeStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<TreatmentStatusDetail> TreatmentStatusDetails { get; } = new List<TreatmentStatusDetail>();

    public virtual ICollection<TreatmentStatus> TreatmentStatuses { get; } = new List<TreatmentStatus>();

    public virtual ICollection<Treatment> TreatmentTreatmentStatusDetailStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentTreatmentStatusStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentVisitRefusalReasonStringMaps { get; } = new List<Treatment>();

    public virtual ICollection<User> Users { get; } = new List<User>();

    public virtual ICollection<Visit> VisitCustom1StringMaps { get; } = new List<Visit>();

    public virtual ICollection<Visit> VisitCustom2StringMaps { get; } = new List<Visit>();

    public virtual ICollection<Visit> VisitPreSchedulingStatusStringMaps { get; } = new List<Visit>();

    public virtual ICollection<Visit> VisitStatusCodeStringMaps { get; } = new List<Visit>();

    public virtual ICollection<Visit> VisitStatusStringMaps { get; } = new List<Visit>();

    public virtual ICollection<VoucherConfiguration> VoucherConfigurationStatusCodeStringMaps { get; } = new List<VoucherConfiguration>();

    public virtual ICollection<VoucherConfiguration> VoucherConfigurationVoucherConfigTypeStringMaps { get; } = new List<VoucherConfiguration>();

    public virtual ICollection<Voucher> VoucherSourceStringMaps { get; } = new List<Voucher>();

    public virtual ICollection<Voucher> VoucherStatusCodeStringMaps { get; } = new List<Voucher>();

    public virtual ICollection<Voucher> VoucherVoucherStatusStringMaps { get; } = new List<Voucher>();

    public virtual ICollection<Voucher> VoucherCustom1StringMaps { get; } = new List<Voucher>();


    public virtual ICollection<Voucher> VoucherCustom2StringMaps { get; } = new List<Voucher>();


    public virtual ICollection<Voucher> VoucherCustom3StringMaps { get; } = new List<Voucher>();


    public virtual ICollection<Voucher> VoucherCustom4StringMaps { get; } = new List<Voucher>();


    public virtual ICollection<Voucher> VoucherCustom5StringMaps { get; } = new List<Voucher>();


    public virtual ICollection<Voucher> VoucherCustom6StringMaps { get; } = new List<Voucher>();


    public virtual ICollection<Voucher> VoucherCustom7StringMaps { get; } = new List<Voucher>();

    public virtual ICollection<UrlShortener> UrlShorteners { get; set; }

    public virtual ICollection<ClickTracking> ClickTrackings { get; set; }

    public virtual ICollection<TemplateConfiguration> TemplateConfigurations { get; set; }

}
