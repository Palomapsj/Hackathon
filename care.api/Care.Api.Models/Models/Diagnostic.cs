using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models;

/// <summary>
/// Tabela de diagnósticos 
/// </summary>
public partial class Diagnostic : BaseEntity
{
    [NotMapped]
    public static int EntityTypeCode => 400;

    [NotMapped]
    public static string EntityName => "Diagnostic";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("E178B28D-641A-4AA2-8295-D70BF3BC209D");

    /// <summary>
    /// Primeiro nome do paciente
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Ultimo nome do paciente
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Nome completo do paciente
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Endereço de email 1 do paciente
    /// </summary>
    public string? EmailAddress1 { get; set; }

    /// <summary>
    /// Telefone 1 do paciente
    /// </summary>
    public string? Telephone1 { get; set; }

    /// <summary>
    /// Telefone móvel 1 do paciente
    /// </summary>
    public string? Mobilephone1 { get; set; }

    /// <summary>
    /// Data de aniversário do paciente
    /// </summary>
    public DateTime? Birthdate { get; set; }

    /// <summary>
    /// Idade do paciente
    /// </summary>
    public int? Age { get; set; }

    /// <summary>
    /// CPF do paciente
    /// </summary>
    public string? Cpf { get; set; }

    public DateTime? ReturnDateContact { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela string map para o tipo de endereço
    /// </summary>
    public Guid? AddressTypeStringMapId { get; set; }

    /// <summary>
    /// CEP do paciente
    /// </summary>
    public string? AddressPostalCode { get; set; }

    /// <summary>
    /// Logradouro do paciente
    /// </summary>
    public string? AddressName { get; set; }

    /// <summary>
    /// Número da residência do paciente
    /// </summary>
    public string? AddressNumber { get; set; }

    /// <summary>
    /// Informações complementares do endereço do paciente
    /// </summary>
    public string? AddressComplement { get; set; }

    /// <summary>
    /// Bairro do paciente
    /// </summary>
    public string? AddressDistrict { get; set; }

    /// <summary>
    /// Cidade do paciente
    /// </summary>
    public string? AddressCity { get; set; }

    /// <summary>
    /// UF da localidade do paciente
    /// </summary>
    public string? AddressState { get; set; }

    /// <summary>
    /// País do paciente
    /// </summary>
    public string? AddressCountry { get; set; }

    /// <summary>
    /// Primeiro nome do cuidador do paciente
    /// </summary>
    public string? FirstNameCaregiver { get; set; }

    /// <summary>
    /// Ultimo nome do cuidador do paciente
    /// </summary>
    public string? LastNameCaregiver { get; set; }

    /// <summary>
    /// Nome completo do cuidador do paciente
    /// </summary>
    public string? FullNameCaregiver { get; set; }

    /// <summary>
    /// Endereço de email 1 do cuidador do paciente
    /// </summary>
    public string? EmailAddress1Caregiver { get; set; }

    /// <summary>
    /// Telefone 1 do cuidador do paciente
    /// </summary>
    public string? Telephone1Caregiver { get; set; }

    /// <summary>
    /// Telefone móvel 1 do cuidador do paciente
    /// </summary>
    public string? Mobilephone1Caregiver { get; set; }

    /// <summary>
    /// Aniversário do cuidador do paciente
    /// </summary>
    public DateTime? BirthdateCaregiver { get; set; }

    /// <summary>
    /// CPF do cuidador
    /// </summary>
    public string? CpfCaregiver { get; set; }

    public string? FromSystem { get; set; }

    public string? FromSystemId { get; set; }

    /// <summary>
    /// chave estrangeira da tabela HealthProgram, que indica a qual programa o paciente participa
    /// </summary>
    public Guid? HealthProgramId { get; set; }

    /// <summary>
    /// chave estrangeira da tabela Disease, que indica qual é a doença diagnosticada do paciente
    /// </summary>
    public Guid? DiseaseId { get; set; }

    /// <summary>
    /// chave estrangeira da tabela Doctor, que indica qual médico diagnosticou este paciente
    /// </summary>
    public Guid? DoctorId { get; set; }

    /// <summary>
    /// chave estrangeira da tabela Patient, que indica qual paciente está vinculado a este diagnóstido
    /// </summary>
    public Guid? PatientId { get; set; }

    /// <summary>
    /// Chave estrangeira da stringmap onde indica se o contato cadastrado é o contato principal
    /// </summary>
    public Guid? MainContactStringMapId { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela Caregiver, que indica qual é o cuidador do paciente
    /// </summary>
    public Guid? CaregiverId { get; set; }

    /// <summary>
    /// Codigo alfanumérico de identificação do diagnóstico no sistema
    /// </summary>
    public string? FriendlyCode { get; set; }

    public bool? IsQualified { get; set; }

    /// <summary>
    /// Campo que indica qual programa o paciente participa
    /// </summary>
    public string? Name { get; set; }



    /// <summary>
    /// Chave estrangeira da tabela User, indica qual usuário que alterou o registro no sistema
    /// </summary>
    public Guid? ModifiedBy { get; set; }

    /// <summary>
    /// Nome do usuário que alterou o registro no sistema.
    /// </summary>
    public string? ModifiedByName { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela User, indica qual usuário deletou o registro no sistema
    /// </summary>
    public Guid? DeletedBy { get; set; }

    /// <summary>
    /// Nome do usuário que deletou o registro no sistema.
    /// </summary>
    public string? DeletedByName { get; set; }

    /// <summary>
    /// Campo que indica se o diagnóstico está deletado
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela User, indica qual usuário é o dono do registro
    /// </summary>
    public Guid? OwnerId { get; set; }

    /// <summary>
    /// Nome do usuário que é o dono do registro.
    /// </summary>
    public string? OwnerIdName { get; set; }

    /// <summary>
    /// Campo para detalhar quais os motivos da inativação do diagnóstico.
    /// </summary>
    public string? ReasonStateCode { get; set; }

    /// <summary>
    /// Campo para detalhar quais os motivos da exclusão do diagnóstico.
    /// </summary>
    public string? ReasonDeleted { get; set; }

    /// <summary>
    /// Codigo alfanumérico de identificação do diagnóstico no sistema, também utilizado para códigos provenientes de importação de dados
    /// </summary>
    public string? ImportCode { get; set; }

    /// <summary>
    /// campo para informações internas.
    /// </summary>
    public string? InternalControl { get; set; }

    public string? EntityOriginalValues { get; set; }

    public bool? ReportReceived { get; set; }

    public bool? PatientDiagnosed { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela StringMap, indica qual o gênero do paciente.
    /// </summary>
    public Guid? GenderStringMapId { get; set; }

    /// <summary>
    /// chave estrangeira da tabela StringMap, indica qual meio de contato da operação e o paciente para tratar de assuntos do programa
    /// </summary>
    public Guid? PatientSourceStringMapId { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela StringMap, indica qual status de andamento do diagnóstico
    /// </summary>
    public Guid? DiagnosticStatusStringMapId { get; set; }

    /// <summary>
    /// Campo que atesta o consentimento do paciente a participar do programa
    /// </summary>
    public bool? ProgramParticipationConsent { get; set; }

    public Guid? MondayStringMapId { get; set; }

    public string? SpecificTimeMonday { get; set; }

    public Guid? TuesdayStringMapId { get; set; }

    public string? SpecificTimeTuesday { get; set; }

    public Guid? WednesdayStringMapId { get; set; }

    public string? SpecificTimeWednesday { get; set; }

    public Guid? ThursdayStringMapId { get; set; }

    public string? SpecificTimeThursday { get; set; }

    public Guid? FridayStringMapId { get; set; }

    public string? SpecificTimeFriday { get; set; }

    public Guid? SaturdayStringMapId { get; set; }

    public string? SpecificTimeSaturday { get; set; }

    public Guid? HealthProfessionalId { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela Account onde indica qual é o local de tratamento
    /// </summary>
    public Guid? AccountId { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela StringMap, indica qual o SubStatus do tratamento
    /// </summary>
    public Guid? DiagnosticStatusDetailStringMapId { get; set; }

    /// <summary>
    /// Telefone 2 do paciente
    /// </summary>
    public string? Telephone2 { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela MedicamentCompetitor onde indica qual medicamento é utilizado para o tratamento.
    /// </summary>
    public Guid? MedicamentCompetitorId { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela StringMap onde indica a preferência do paciente para realizar o tratamento.
    /// </summary>
    public Guid? PreferredTimeStringMapId { get; set; }

    /// <summary>
    /// Campo onde é informado a altura do paciente
    /// </summary>
    public decimal? Stature { get; set; }

    /// <summary>
    /// Campo onde é informado o peso do paciente
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// Telefone de observação 1 do paciente
    /// </summary>
    public string? Telephone1Observation { get; set; }

    /// <summary>
    /// Telefone de observação 2 do paciente
    /// </summary>
    public string? Telephone2Observation { get; set; }

    /// <summary>
    /// Telefone 3 do paciente
    /// </summary>
    public string? Telephone3 { get; set; }

    /// <summary>
    /// Telefone de observação 3 do paciente
    /// </summary>
    public string? Telephone3Observation { get; set; }

    /// <summary>
    /// Telefone móvel de observação 1 do paciente
    /// </summary>
    public string? Mobilephone1Observation { get; set; }

    /// <summary>
    /// Telefone móvel 2 do paciente
    /// </summary>
    public string? Mobilephone2 { get; set; }

    /// <summary>
    /// Telefone móvel de observação 2 do paciente
    /// </summary>
    public string? Mobilephone2Observation { get; set; }

    /// <summary>
    /// Telefone móvel 3  do paciente
    /// </summary>
    public string? Mobilephone3 { get; set; }

    /// <summary>
    /// Telefone móvel de observação 4 do paciente
    /// </summary>
    public string? Mobilephone3Observation { get; set; }

    /// <summary>
    /// Endereço de email 2 do paciente
    /// </summary>
    public string? EmailAddress2 { get; set; }

    /// <summary>
    /// Campo para inserir o Registro Nacional Unico, para pacientes de origem estrangeira.
    /// </summary>
    public string? Rne { get; set; }

    /// <summary>
    /// Chave estrangeira da tabela StringMap, indica qual o grau de parentesco entre o cuidador e o paciente.
    /// </summary>
    public Guid? KinshipStringMapId { get; set; }

    public string? DoctorsEmailforExamResult { get; set; }

    public string? DeclarationInformation { get; set; }

    public Guid? MedicalSpecialtyId { get; set; }

    public Guid? CategoryOfExamsStringMapId { get; set; }

    public bool? HasProgramMaterial { get; set; }

    public bool? HaveMedicalRequesTofHlab27orMagneticResonance { get; set; }

    public bool? PatientUsedAnotherMedication { get; set; }

    public Guid? PreviousMedicamentCompetitorId { get; set; }

    public Guid? TreatmentLineStringMapId { get; set; }

    public bool? ConsentToReceivePhonecalls { get; set; }

    public bool? ConsentToReceiveSms { get; set; }

    public bool? ConsentToReceiveEmail { get; set; }

    public bool? ConsentToSendDataToDoctor { get; set; }

    public string? Description { get; set; }

    public DateTime? PatientDiagnosedDate { get; set; }

    public Guid? TreatmentLine2StringMapId { get; set; }

    public bool? HasOps { get; set; }

    public int? PreviousTreatmentAmount { get; set; }

    public Guid? VoucherId { get; set; }

    public string? MultipleExamsType { get; set; }

    public string? OtherTypeExams { get; set; }

    public bool? HasKit { get; set; }

    public Guid? ExamDefinitionId { get; set; }

    public string? MultipleMedicamentCompetitor { get; set; }

    public bool? ConsentFormCompleted { get; set; }

    public bool? ConsentAccreditedLaboratory { get; set; }

    public string? ProtocolNumber { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? DateLogisticalCollection { get; set; }

    public DateTime? TransitDateToLaboratory { get; set; }

    public DateTime? ReportReleaseDate { get; set; }

    public DateTime? BlockReturnDate { get; set; }

    public bool? PrescriptionReceived { get; set; }

    public DateTime? PrescriptionReceivedDate { get; set; }

    public bool? PrescriptionIsValid { get; set; }

    public Guid? PrescriptionStatusStringMapId { get; set; }

    public DateTime? PrescriptionValidationDate { get; set; }

    public string? PrescriptionValidatedByName { get; set; }

    public DateTime? PrescriptionDueDate { get; set; }

    public bool? PrescriptionHasDivergentInterval { get; set; }

    public bool? PrescriptionHasLackOfInterval { get; set; }

    public bool? PrescriptionHasDateMissing { get; set; }

    public bool? PrescriptionHasStampSignatureMissing { get; set; }

    public bool? WillDoctorMakeNewPrescription { get; set; }

    public Guid? DoctorPrescriberId { get; set; }

    public Guid? AccountSettingsByProgramId { get; set; }

    public string? SkypeUserCaregiver { get; set; }

    public bool? ConsentToReceiveLogistics { get; set; }

    public bool? ConsentLgpd { get; set; }

    public DateTime? ConsentLgpddate { get; set; }

    public Guid? SourceConsentStringMapId { get; set; }

    public bool? InTreatment { get; set; }

    public Guid? TypeOfAnalysisStringMapId { get; set; }

    public Guid? StageOfDiseaseStringMapId { get; set; }

    public Guid? EthnicityStringMapId { get; set; }

    public Guid? HealthCareProviderId { get; set; }

    public Guid? UserId { get; set; }

    public string? AddressCityPatient { get; set; }

    public string? AddressStatePatient { get; set; }

    public bool? CustomBoolean1 { get; set; }
    public bool? CustomBoolean2 { get; set; }
    public bool? CustomBoolean3 { get; set; }
    public bool? CustomBoolean4 { get; set; }
    public bool? CustomBoolean5 { get; set; }
    public bool? CustomBoolean6 { get; set; }
    public bool? CustomBoolean7 { get; set; }
    public DateTime? CustomDateTime1 { get; set; }
    public DateTime? CustomDateTime2 { get; set; }
    public DateTime? CustomDateTime3 { get; set; }
    public DateTime? CustomDateTime4 { get; set; }
    public DateTime? CustomDateTime5 { get; set; }
    public DateTime? CustomDateTime6 { get; set; }
    public DateTime? CustomDateTime7 { get; set; }
    public string? CustomString1 { get; set; }
    public string? CustomString2 { get; set; }
    public string? CustomString3 { get; set; }
    public string? CustomString4 { get; set; }
    public string? CustomString5 { get; set; }
    public string? CustomString6 { get; set; }
    public string? CustomString7 { get; set; }

    public Guid? Custom1StringMapId { get; set; }

    public Guid? Custom2StringMapId { get; set; }

    public Guid? Custom3StringMapId { get; set; }

    public Guid? Custom4StringMapId { get; set; }

    public Guid? Custom5StringMapId { get; set; }

    public Guid? Custom6StringMapId { get; set; }

    public Guid? Custom7StringMapId { get; set; }

    public StringMap? Custom1StringMap { get; set; }

    public StringMap? Custom2StringMap { get; set; }

    public StringMap? Custom3StringMap { get; set; }

    public StringMap? Custom4StringMap { get; set; }

    public StringMap? Custom5StringMap { get; set; }

    public StringMap? Custom6StringMap { get; set; }

    public StringMap? Custom7StringMap { get; set; }

    public virtual Account? Account { get; set; }

    public virtual AccountSettingsByProgram? AccountSettingsByProgram { get; set; }

    public virtual StringMap? AddressTypeStringMap { get; set; }

    public virtual ICollection<AttemptCallLog> AttemptCallLogs { get; } = new List<AttemptCallLog>();

    public virtual ICollection<Benefit> Benefits { get; } = new List<Benefit>();

    public virtual Caregiver? Caregiver { get; set; }

    public virtual StringMap? CategoryOfExamsStringMap { get; set; }

    public virtual StringMap? DiagnosticStatusDetailStringMap { get; set; }

    public virtual StringMap? DiagnosticStatusStringMap { get; set; }

    public virtual Disease? Disease { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Doctor? DoctorPrescriber { get; set; }

    public virtual StringMap? EthnicityStringMap { get; set; }

    public virtual ExamDefinition? ExamDefinition { get; set; }

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual StringMap? FridayStringMap { get; set; }

    public virtual StringMap? GenderStringMap { get; set; }

    public virtual Account? HealthCareProvider { get; set; }

    public virtual HealthProfessional? HealthProfessional { get; set; }

    public virtual HealthProgram? HealthProgram { get; set; }

    public virtual StringMap? KinshipStringMap { get; set; }

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual StringMap? MainContactStringMap { get; set; }

    public virtual MedicalSpecialty? MedicalSpecialty { get; set; }

    public virtual MedicamentCompetitor? MedicamentCompetitor { get; set; }

    public virtual StringMap? MondayStringMap { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual StringMap? PatientSourceStringMap { get; set; }

    public virtual StringMap? PreferredTimeStringMap { get; set; }

    public virtual StringMap? PrescriptionStatusStringMap { get; set; }

    public virtual MedicamentCompetitor? PreviousMedicamentCompetitor { get; set; }

    public virtual StringMap? SaturdayStringMap { get; set; }

    public virtual StringMap? SourceConsentStringMap { get; set; }

    public virtual StringMap? StageOfDiseaseStringMap { get; set; }

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual StringMap? ThursdayStringMap { get; set; }

    public virtual ICollection<TreatmentAndDiagnosticAction> TreatmentAndDiagnosticActions { get; } = new List<TreatmentAndDiagnosticAction>();

    public virtual StringMap? TreatmentLine2StringMap { get; set; }

    public virtual StringMap? TreatmentLineStringMap { get; set; }

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();

    public virtual StringMap? TuesdayStringMap { get; set; }

    public virtual StringMap? TypeOfAnalysisStringMap { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();

    public virtual Voucher? Voucher { get; set; }

    public virtual ICollection<Voucher> Vouchers { get; } = new List<Voucher>();

    public virtual StringMap? WednesdayStringMap { get; set; }
}
