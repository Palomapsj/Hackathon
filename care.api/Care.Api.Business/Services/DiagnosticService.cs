using AutoMapper;
using Care.Api.Business.Helper;
using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.Json;
using static Care.Api.Business.Models.ExamResultModel;

namespace Care.Api.Business.Services
{
    public class DiagnosticService : IDiagnosticService
    {
        protected readonly IPatientRepository _patientRepository;
        protected readonly IDiagnosticRepository _diagnosticRepository;
        protected readonly ICryptographyService _cryptographyService;
        protected readonly IHealthProgramRepository _healthProgramRepository;
        protected readonly IUserRepository _userRepository;
        protected readonly IDoctorByProgramRepository _doctorByProgRepository;
        protected readonly IExamRepository _examRepository;
        protected readonly IStringMapRepository _stringMapRepository;
        protected readonly IExamDefinitionSettingsByProgramRepository _examDefinitionSettingsByProgRepository;
        protected readonly IVoucherConfigurationRepository _voucherConfigurationRepository;
        protected readonly IVoucherService _voucherService;
        protected readonly ISchedulingHistoryRepository _schedulingHistoryRepository;
        protected readonly ILogisticsScheduleRepository _logisticsScheduleRepository;
        protected readonly IAnnotationRepository _annotationRepository;
        protected readonly ICustomerAddressRepository _customerAddressRepository;
        protected readonly IEmailService _emailService;
        protected readonly IAccountSettingsByProgramRepository _accountSettingsByProgRepository;
        protected readonly IPatientRepository patientRepository;
        protected readonly IDiagnosticRepository diagnosticRepository;
        protected readonly IHealthProgramRepository healthProgramRepository;
        protected readonly IUserRepository userRepository;
        protected readonly IDoctorByProgramRepository doctorByProgRepository;
        protected readonly IExamRepository examRepository;
        protected readonly IStringMapRepository stringMapRepository;
        protected readonly IExamDefinitionSettingsByProgramRepository examDefinitionSettingsByProgRepository;
        protected readonly IVoucherConfigurationRepository voucherConfigurationRepository;
        protected readonly IVoucherService voucherService;
        protected readonly ISchedulingHistoryRepository schedulingHistoryRepository;
        protected readonly ILogisticsScheduleRepository logisticsScheduleRepository;
        protected readonly IAnnotationRepository annotationRepository;
        protected readonly ICustomerAddressRepository customerAddressRepository;
        protected readonly IAccountSettingsByProgramRepository accountSettingsByProgRepository;
        protected readonly IEmailService emailService;
        protected readonly IUserService userService;
        protected readonly IUserService _userService;
        protected readonly ISmsService _smsService;
        protected readonly ITemplateRepository _templateRepository;
        protected readonly ITokenService _tokenService;
        protected readonly IStringMapService _stringMapService;
        protected readonly IHttpContextAccessor _httpContext;
        protected readonly IAccountRepository _accountRepository;
        protected readonly IVisitRepository _visitRepository;
        protected readonly IHealthProgramService _healthProgramService;
        protected readonly IEmailRepository _emailRepository;
        protected readonly ITreatmentRepository _treatmentRepository;
        protected readonly ITreatmentAndDiagnosticActionService _treatmentAndDiagnosticActionService;
        protected readonly IVoucherRepository _voucherRepository;
        protected readonly IAccessProfileRepository _accessProfileRepository;

        public DiagnosticService(
            IPatientRepository patientRepository,
            IServiceProvider serviceProvider,
            IDiagnosticRepository diagnosticRepository,
            IHealthProgramRepository healthProgramRepository,
            IUserRepository userRepository,
            ICryptographyService cryptographyService,
            IDoctorByProgramRepository doctorByProgRepository,
            IExamRepository examRepository,
            IStringMapRepository stringMapRepository,
            IExamDefinitionSettingsByProgramRepository examDefinitionSettingsByProgRepository,
            IVoucherConfigurationRepository voucherConfigurationRepository,
            IVoucherService voucherService,
            ISchedulingHistoryRepository schedulingHistoryRepository,
            ILogisticsScheduleRepository logisticsScheduleRepository,
            IAnnotationRepository annotationRepository,
            ICustomerAddressRepository customerAddressRepository,
            IAccountSettingsByProgramRepository accountSettingsByProgRepository,
            IEmailService emailService,
            ILanguageAttributeRepository languageAttributeRepository,
            IUserService userService,
            ISmsService smsService,
            ITemplateRepository templateRepository,
            ITokenService tokenService,
            IStringMapService stringMapService,
            IHttpContextAccessor httpContext,
            IAccountRepository accountRepository,
            IVisitRepository visitRepository,
            IHealthProgramService healthProgramService,
            IEmailRepository emailRepository,
            ITreatmentRepository treatmentRepository,
            ITreatmentAndDiagnosticActionService treatmentAndDiagnosticActionService,
            IVoucherRepository voucherRepository,
            IAccessProfileRepository accessProfileRepository)
        {
            _patientRepository = patientRepository;
            _diagnosticRepository = diagnosticRepository;
            _cryptographyService = cryptographyService;
            _healthProgramRepository = healthProgramRepository;
            _userRepository = userRepository;
            _doctorByProgRepository = doctorByProgRepository;
            _examRepository = examRepository;
            _stringMapRepository = stringMapRepository;
            _examDefinitionSettingsByProgRepository = examDefinitionSettingsByProgRepository;
            _voucherConfigurationRepository = voucherConfigurationRepository;
            _voucherService = voucherService;
            _schedulingHistoryRepository = schedulingHistoryRepository;
            _logisticsScheduleRepository = logisticsScheduleRepository;
            _annotationRepository = annotationRepository;
            _customerAddressRepository = customerAddressRepository;
            _accountSettingsByProgRepository = accountSettingsByProgRepository;
            _emailService = emailService;
            _userService = userService;
            _smsService = smsService;
            _templateRepository = templateRepository;
            _tokenService = tokenService;
            _stringMapService = stringMapService;
            _httpContext = httpContext;
            _accountRepository = accountRepository;
            _visitRepository = visitRepository;
            _healthProgramService = healthProgramService;
            _emailRepository = emailRepository;
            _treatmentRepository = treatmentRepository;
            _treatmentAndDiagnosticActionService = treatmentAndDiagnosticActionService;
            _voucherRepository = voucherRepository;
            _accessProfileRepository = accessProfileRepository;
        }

        public virtual async Task<PaginationResult<List<DiagnosticExamModel>>> List(DiagnosticFilterModel model, Guid userId, string programcode)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<PaginationResult<List<DiagnosticExamModel>>> ListAdmin(DiagnosticFilterModel model, Guid userId, string programcode)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<PaginationResult<List<DiagnosticExamModel>>> ListExamByDiagnosticPatient(DiagnosticFilterModel model, string programcode, Guid userId)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<ReturnMessage<string>> RequestExam(ExamRequestModel model, Guid? userId)
        {
            throw new NotImplementedException();
        }
        public async Task<List<SourceConsentModel>> GetSourceConsent(string programcode)
        {
            List<SourceConsentModel> result = new List<SourceConsentModel>();

            var stringMaps = _stringMapRepository.GetStringMapByEntityAndAttributeNameAndProgram("Diagnostic", "SourceConsentStringMap", programcode);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<StringMap, SourceConsentModel>()
                .ForMember(o => o.Name, opt => opt.MapFrom(s => s.OptionName))
                .ForMember(o => o.Id, opt => opt.MapFrom(s => s.StringMapId));
            });
            var mapper = mapperConfig.CreateMapper();

            result = mapper.Map<List<SourceConsentModel>>(stringMaps);

            return result;
        }

        public virtual Task<ReturnMessage<string>> Update(ExamCreateModel model, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PaginationResult<List<DiagnosticExamResultModel>>> ListExamByDiagnosticbyId(ExamFilterModel model, string programcode, Guid userId, Guid diagnosticId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> Add(ExamCreateModel model, Guid? userId)
        {
            ReturnMessage<string> result = new ReturnMessage<string>();

            var resultDiagnostic = CreateDiagnosticEntity(model, userId.Value);
            var diagnostic = resultDiagnostic.Value;

            if (!resultDiagnostic.IsValidData)
            {
                result.AdditionalMessage = resultDiagnostic.AdditionalMessage;
                return result;
            }

            if (diagnostic != null)
            {
                var resultExam = CreateExam(model, diagnostic);

                SendEmail(diagnostic, resultExam.Value);

                if (resultExam != null)
                {
                    result.Value = resultExam.Value is null ? "" : resultExam.Value.VoucherName;
                    result.IsValidData = true;
                }
                else
                {
                    result.Value = "Erro no cadastro do exame.";
                    result.IsValidData = false;
                }
            }
            return result;
        }

        public ReturnMessage<Diagnostic> CreateDiagnosticEntity(ExamCreateModel model, Guid userId)
        {
            ReturnMessage<Diagnostic> result = new ReturnMessage<Diagnostic>();

            var healthProgram = _healthProgramRepository.GetValue(_ => _.Code == model.ProgramCode);

            var examIsValid = CheckExam(model, healthProgram.Id);
            if (examIsValid.IsValidData == false)
            {
                result.IsValidData = false;
                result.AdditionalMessage = examIsValid.Value;
                return result;
            }

            var diagnostic = GetDiagnostic(model, healthProgram.Id);
            if (diagnostic is not null)
            {
                result.Value = diagnostic;
                result.IsValidData = true;
                return result;
            }

            var user = _userRepository.GetUserById(userId, model.ProgramCode);
            var profile = user.AccessProfiles.FirstOrDefault()!.Name;

            DoctorByProgram? doctor = null;

            if (profile == "DOCTOR")
            {
                doctor = GetDoctor(userId, healthProgram.Id);
                if (doctor == null)
                {
                    result.IsValidData = false;
                    result.AdditionalMessage = "Médico não localizado.";
                    return result;
                }
            }
            else
            {
                doctor = new DoctorByProgram();
                doctor.DoctorId = model.DoctorId;
            }

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<ExamCreateModel, Diagnostic>()
                .ForMember(o => o.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
                .ForMember(o => o.HealthProgramId, opt => opt.MapFrom(s => healthProgram.Id))
                .ForMember(o => o.DiseaseId, opt => opt.MapFrom(s => s.Disease))

                .ForMember(o => o.DoctorId, opt => opt.MapFrom(s => doctor.DoctorId))
                .ForMember(o => o.ExamDefinition, opt => opt.Ignore())
                .ForMember(o => o.ExamDefinitionId, opt => opt.MapFrom(s => s.ExamDefinition))
                .ForMember(o => o.FullName, opt => opt.MapFrom(s => s.Name))
                .ForMember(o => o.Mobilephone1, opt => opt.MapFrom(s => s.Mobilephone))
                .ForMember(o => o.Telephone1, opt => opt.MapFrom(s => s.Telephone))
                .ForMember(o => o.EmailAddress1, opt => opt.MapFrom(s => s.Email))
                //.ForMember(o => o.SourceConsentStringMapId, opt => opt.MapFrom(s => s.SourceConsent))

                .ForMember(o => o.FullNameCaregiver, opt => opt.MapFrom(s => s.NameCaregiver))
                .ForMember(o => o.BirthdateCaregiver, opt => opt.MapFrom(s => s.BirthdateCaregiver))
                .ForMember(o => o.CpfCaregiver, opt => opt.MapFrom(s => s.CPFCaregiver))
                .ForMember(o => o.HasOps, opt => opt.MapFrom(s => s.HasOPS))
                .ForMember(o => o.ProgramParticipationConsent, opt => opt.MapFrom(s => s.TermConsentAttach == null ? (bool?)null : true))
                .ForMember(o => o.ConsentToReceiveEmail, opt => opt.MapFrom(s => s.TermConsentAttach == null ? (bool?)null : true))
                .ForMember(o => o.ConsentToSendDataToDoctor, opt => opt.MapFrom(s => s.TermConsentAttach == null ? (bool?)null : true))
                .ForMember(o => o.ConsentToReceiveSms, opt => opt.MapFrom(s => s.TermConsentAttach == null ? (bool?)null : true))
                .ForMember(o => o.ConsentToReceivePhonecalls, opt => opt.MapFrom(s => s.TermConsentAttach == null ? (bool?)null : true))
                .ForMember(o => o.CustomBoolean1, opt => opt.MapFrom(s => s.TermConsentAttach == null ? (bool?)null : true))

                .ForPath(o => o.Patient.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
                .ForPath(o => o.Patient.FullName, opt => opt.MapFrom(s => s.Name))
                .ForPath(o => o.Patient.HealthProgramId, opt => opt.MapFrom(s => healthProgram.Id))

                .ForMember(o => o.AddressCity, opt => opt.Ignore())
                .ForMember(o => o.AddressComplement, opt => opt.Ignore())
                .ForMember(o => o.AddressDistrict, opt => opt.Ignore())
                .ForMember(o => o.AddressName, opt => opt.Ignore())
                .ForMember(o => o.AddressNumber, opt => opt.Ignore())
                .ForMember(o => o.AddressPostalCode, opt => opt.Ignore())
                .ForMember(o => o.AddressState, opt => opt.Ignore())
                .ForMember(o => o.Disease, opt => opt.Ignore());
            });
            var mapper = mapperConfig.CreateMapper();

            var newDiagnostic = mapper.Map<Diagnostic>(model);

            if (model.Name.IndexOf(" ") > 0)
            {
                newDiagnostic.FirstName = model.Name.Substring(0, model.Name.IndexOf(" ")).Trim();
                newDiagnostic.LastName = model.Name.Substring(model.Name.IndexOf(" "), model.Name.Length - model.Name.IndexOf(" ")).Trim();
            }

            if (!string.IsNullOrEmpty(model.NameCaregiver) && model.NameCaregiver.IndexOf(" ") > 0)
            {
                newDiagnostic.FirstNameCaregiver = model.NameCaregiver.Substring(0, model.NameCaregiver.IndexOf(" ")).Trim();
                newDiagnostic.LastNameCaregiver = model.NameCaregiver.Substring(model.NameCaregiver.IndexOf(" "), model.NameCaregiver.Length - model.NameCaregiver.IndexOf(" ")).Trim();
            }

            newDiagnostic.SourceConsentStringMapId = null;
            newDiagnostic.CurrentUserId = userId;

            _diagnosticRepository.Insert(newDiagnostic);

            result.Value = newDiagnostic;
            result.AdditionalMessage = "Diagnostico criado com sucesso.";
            result.IsValidData = true;

            return result;
        }

        private DoctorByProgram GetDoctor(Guid userId, Guid healthProgramId)
        {
            return _doctorByProgRepository.GetValue(_ => _.HealthProgramId == healthProgramId
                                                      && _.SystemUserId == userId
                                                      && _.IsDeleted == false);
        }

        private Diagnostic? GetDiagnostic(ExamCreateModel model, Guid healthProgramId)
        {
            var diagnostic = _diagnosticRepository.Find(_ => _.Cpf.Replace(".", "").Replace("-", "") == model.CPF.Replace(".", "").Replace("-", "")
                                                          && _.IsDeleted == false
                                                          && _.HealthProgramId == healthProgramId
                                                          && _.StateCode.Value).FirstOrDefault();

            if (diagnostic != null)
                return diagnostic;

            return null;
        }

        private ReturnMessage<string> CheckExam(ExamCreateModel model, Guid healthProgramId)
        {
            ReturnMessage<string> result = new ReturnMessage<string>();
            var diagnostic = GetDiagnostic(model, healthProgramId);

            if (diagnostic is null)
            {
                result.IsValidData = true;
                return result;
            }
            else
            {
                result.IsValidData = true;
                var examStatusCanceledStringMapId = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntityAndProgram("EXAM_CANCELED", Exam.EntityName, "ExamStatusStringMap", healthProgramId).StringMapId;
                var resultPositiveStringMapId = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity("#RESULTPOSITIVE", Exam.EntityName, "ResultStringMap").StringMapId;
                var resultNegativeStringMapId = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity("#RESULTNEGATIVE", Exam.EntityName, "ResultStringMap").StringMapId;

                var exams = _examRepository.Find(_ => _.DiagnosticId == diagnostic.Id
                                                   && _.IsDeleted == false
                                                   && _.ExamStatusStringMapId.Value != examStatusCanceledStringMapId).ToList();

                if (exams.Where(_ => _.ResultStringMapId == resultNegativeStringMapId).Count() >= 2)
                {
                    result.Value = "Paciente execedeu as solicitações permitidas por CPF.";
                    result.IsValidData = false;
                }
                if (exams.Where(_ => _.ResultStringMapId.HasValue).Count() == 2)
                {
                    result.Value = "Paciente execedeu as solicitações permitidas por CPF.";
                    result.IsValidData = false;
                }
                else if (exams.Any(_ => _.ResultStringMapId.Equals(resultPositiveStringMapId)))
                {
                    result.Value = "Paciente execedeu as solicitações permitidas por CPF.";
                    result.IsValidData = false;
                }
                return result;
            }
        }

        private ReturnMessage<Exam> CreateExam(ExamCreateModel model, Diagnostic diagnostic)
        {
            ReturnMessage<Exam> result = new ReturnMessage<Exam>();

            var examDefinition = _examDefinitionSettingsByProgRepository.Find(_ => _.ExamDefinitionId == model.ExamDefinition && _.HealthProgramId == diagnostic.HealthProgramId).FirstOrDefault();
            var local = _accountSettingsByProgRepository.GetValue(_ => _.AccountId == model.LaboratoryAnalysis && _.HealthProgramId == diagnostic.HealthProgramId);

            var voucherConfigurationId = _voucherConfigurationRepository.Find(_ => _.HealthProgramId == diagnostic.HealthProgramId).FirstOrDefault();
            var voucherStatusStringMap = _stringMapRepository.GetStringMapByAttributeOptionValue("Voucher", "VoucherStatusStringMap", 2);
            var voucherSourceStringMap = _stringMapRepository.GetStringMapByAttributeOptionValue("Voucher", "SourceStringMap", 1);

            var newvoucher = _voucherService.Add(new VoucherModel
            {
                VoucherConfigurationId = voucherConfigurationId.Id,
                DiagnosticId = diagnostic.Id,
                HealthProgramId = diagnostic.HealthProgramId,
                SourceStringMapId = voucherSourceStringMap.StringMapId,
                StatusStringMapId = voucherStatusStringMap.StringMapId,
                TreatmentId = null
            });

            var examStatusStringMap = _stringMapRepository.GetStringMapByAttributeOptionValueAndProgram("Exam", "ExamStatusStringMap", 2, diagnostic.HealthProgramId.Value);

            var exam = new Exam()
            {
                Id = Guid.NewGuid(),
                ExamDefinitionId = model.ExamDefinition,
                Name = diagnostic.FullName.ToUpper() + " => " + examDefinition.Name.ToUpper(),
                ScheduleDate = model.ScheduledDate,
                DiagnosticId = diagnostic.Id,
                HealthProgramId = diagnostic.HealthProgramId,
                VoucherId = newvoucher.Value.Id,
                DoctorId = diagnostic.DoctorId,
                LocalId = model.LaboratoryAnalysis,
                LocalEmailAddress = local.EmailAddress,
                ExamStatusStringMapId = examStatusStringMap.StringMapId,
                PatientId = diagnostic.PatientId.Value,
                FriendlyCode = GenerateProtocol("999999-9", diagnostic.HealthProgramId.Value),
                CurrentUserId = diagnostic.CurrentUserId
            };

            var validationExam = _examRepository.Insert(exam);

            if (validationExam.IsValid)
            {
                result.IsValidData = validationExam.IsValid;
                var resultSchedHistory = AddSchedullingHistory(exam);
                var resultLogsSched = CreateLogisticsScheduled(model, exam);

                if (model.TermConsentAttach != null)
                {
                    model.TermConsentAttach.Name = "Termo de Consentimento";

                    var annotationStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntityAndProgram("#TERM_CONSENT", "Annotation", "AnnotationTypeStringMap", exam.HealthProgramId.Value);

                    model.TermConsentAttach.AnnotationTypeStringMapId = annotationStringMap.StringMapId;

                    var resultAddAttachment = AddAttachment(exam, model.TermConsentAttach);
                }

                if (model.MedicalRequestAttach != null)
                {
                    model.MedicalRequestAttach.Name = "Pedido do Médico";

                    var annotationStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntityAndProgram("#MEDICAL_REQUEST", "Annotation", "AnnotationTypeStringMap", exam.HealthProgramId.Value);

                    model.MedicalRequestAttach.AnnotationTypeStringMapId = annotationStringMap.StringMapId;

                    var resultAddAttachment = AddAttachment(exam, model.MedicalRequestAttach);
                }

                if (model.ReportAnatomoAttach != null)
                {
                    model.ReportAnatomoAttach.Name = "Laudo Anatomopatológico";

                    var annotationStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntityAndProgram("#REPORT_ANATOMO", "Annotation", "AnnotationTypeStringMap", exam.HealthProgramId.Value);

                    model.ReportAnatomoAttach.AnnotationTypeStringMapId = annotationStringMap.StringMapId;

                    var resultAddAttachment = AddAttachment(exam, model.ReportAnatomoAttach);
                }

                var voucher = newvoucher.Value;

                voucher.DoctorId = exam.DoctorId;
                voucher.UseDate = DateTime.Now;

                _voucherService.Update(voucher);

                exam.VoucherName = voucher.Number;
            }
            result.Value = exam;
            return result;
        }

        protected ReturnMessage<string> AddSchedullingHistory(Exam exam, string description = null)
        {
            ReturnMessage<string> result = new ReturnMessage<string>();
            result.IsValidData = true;

            var examStatusStringMap = _stringMapRepository.GetValue(_ => _.StringMapId == exam.ExamStatusStringMapId.Value);

            var schedulingHistoryBefore = _schedulingHistoryRepository.Find(_ => _.ExamId == exam.Id && _.IsDeleted == false).OrderByDescending(_ => _.CreatedOn).FirstOrDefault();

            var schedulingHistory = new SchedulingHistory()
            {
                Id = Guid.NewGuid(),
                Description = description,
                ExamId = exam.Id,
                HealthProgramId = exam.HealthProgramId,
                StatusAfter = examStatusStringMap.OptionName.ToUpper(),
                StatusBefore = schedulingHistoryBefore == null ? null : schedulingHistoryBefore.StatusAfter,
                CurrentUserId = exam.CurrentUserId
            };

            var validationResult = _schedulingHistoryRepository.Insert(schedulingHistory);

            if (validationResult.IsValid)
            {
                result.IsValidData = true;
            }
            else
            {
                result.IsValidData = false;
                result.AdditionalMessage = "O Histórico Logistico não foi criado.";
            }

            return result;
        }

        protected ReturnMessage<string> CreateLogisticsScheduled(ExamCreateModel model, Exam exam)
        {
            ReturnMessage<string> result = new ReturnMessage<string>();

            var logTypeStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity("#WTHOFSM", "LogisticsSchedule", "LogisticsScheduleTypeStringMap");
            var scheduleStatusStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity("#SKD", "LogisticsSchedule", "ScheduleStatusStringMap");

            LogisticsSchedule logsSched = new LogisticsSchedule()
            {
                Id = Guid.NewGuid(),
                LogisticsScheduleTypeStringMapId = logTypeStringMap.StringMapId,
                ScheduleStatusStringMapId = scheduleStatusStringMap.StringMapId,
                DiagnosticId = exam.DiagnosticId,
                HealthProgramId = exam.HealthProgramId,
                ExamId = exam.Id,
                VoucherId = exam.VoucherId,
                AddressCity = model.AddressCity,
                AddressComplement = model.AddressComplement,
                AddressDistrict = model.AddressDistrict,
                AddressName = model.AddressName,
                AddressNumber = model.AddressNumber,
                AddressPostalCode = model.AddressPostalCode,
                AddressState = model.AddressState,
                MainContact = model.ResponsibleName,
                ResponsibleTelephoneWithdrawal = model.Contact,
                Section = model.Sector,
                CurrentUserId = exam.CurrentUserId
            };

            var validationResult = _logisticsScheduleRepository.Insert(logsSched);

            if (model.SaveAddress.Value)
            {
                CreateAddress(model, exam);
            }

            if (validationResult.IsValid)
            {
                result.Value = logsSched.Id.ToString();
                result.IsValidData = true;
            }
            else
            {
                result.IsValidData = false;
                result.AdditionalMessage = "O registro Logistico não foi criado.";
            }

            return result;
        }

        private ReturnMessage<string> CreateAddress(ExamCreateModel model, Exam exam)
        {
            ReturnMessage<string> result = new ReturnMessage<string>();

            CustomerAddress customerAddress = new CustomerAddress()
            {
                Id = Guid.NewGuid(),
                AddressCity = model.AddressCity,
                AddressComplement = model.AddressComplement,
                AddressDistrict = model.AddressDistrict,
                AddressName = model.AddressName,
                AddressNumber = model.AddressNumber,
                AddressPostalCode = model.AddressPostalCode,
                AddressState = model.AddressState,
                PatientId = exam.PatientId,
                CurrentUserId = exam.CurrentUserId
            };

            var validationResult = _customerAddressRepository.Insert(customerAddress);

            if (validationResult.IsValid)
            {
                result.IsValidData = true;
            }

            return result;
        }

        protected ReturnMessage<string> AddAttachment(Exam exam, AttachmentModel model)
        {
            ReturnMessage<string> result = new ReturnMessage<string>();

            Annotation annotation = new Annotation();
            annotation.Id = Guid.NewGuid();
            annotation.Name = model.Name;
            annotation.Subject = model.Name;
            annotation.AnnotationTypeStringMapId = model.AnnotationTypeStringMapId;
            annotation.CurrentUserId = exam.CurrentUserId;

            var regardingEntity = new RegardingEntity()
            {
                //DE
                Name = Diagnostic.EntityName,
                Id = Guid.NewGuid(),
                RegardingObjectIdTarget = exam.DiagnosticId,
                RegardingEntityTypeCodeTarget = Diagnostic.EntityTypeCode,
                RegardingEntityNameTarget = Diagnostic.EntityName,
                RegardingObjectIdNameTarget = Diagnostic.EntityName,
                //PARA
                RegardingObjectIdSource = annotation.Id,
                RegardingEntityTypeCodeSource = Annotation.EntityTypeCode,
                RegardingEntityNameSource = Annotation.EntityName,
                RegardingObjectIdNameSource = Annotation.EntityName,
                InternalControl = exam.FriendlyCode,
                CurrentUserId = exam.CurrentUserId
            };

            annotation.RegardingEntity = regardingEntity;
            annotation.HasAttachment = true;

            Attachment attachment = new Attachment();
            attachment.FileName = model.FileName;
            attachment.Id = Guid.NewGuid();
            attachment.MimeType = model.ContentType;
            attachment.FileSize = model.FileSize;
            attachment.DocumentBody = model.DocumentBody.Substring(model.DocumentBody.IndexOf(',') + 1);
            attachment.AnnotationId = annotation.Id;
            attachment.CurrentUserId = exam.CurrentUserId;

            var list = new List<Attachment>();

            annotation.Attachments.Add(attachment);

            var validationAnnotation = _annotationRepository.Insert(annotation);

            if (validationAnnotation.IsValid)
            {
                result.IsValidData = validationAnnotation.IsValid;
                result.Value = regardingEntity.Id.ToString();
                return result;
            }

            return result;
        }

        protected string GenerateProtocol(string pattern, Guid healthProgramId)
        {
            string protocol = string.Empty;

            var continueGenerate = true;
            if (pattern is not null)
            {
                while (continueGenerate)
                {
                    protocol = GenerateRandomCode(pattern);

                    continueGenerate = _examRepository.Find(_ => _.FriendlyCode == protocol && _.IsDeleted == false && _.HealthProgramId == healthProgramId).Any();
                }
            }

            return protocol;
        }

        public static string GenerateRandomCode(string fullCodePattern)
        {
            string randomCode = String.Empty;
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            foreach (char c in fullCodePattern)
            {
                switch (c)
                {
                    case '9':
                        char newNumber = GenerateNumericCharacter(crypto);
                        randomCode += newNumber.ToString();
                        break;

                    default:
                        randomCode += c.ToString();
                        break;
                }
            }

            return randomCode;
        }

        public static char GenerateNumericCharacter(RNGCryptoServiceProvider crypto)
        {
            char[] chars = new char[10];
            string a;
            a = "1234567890";
            chars = a.ToCharArray();

            byte[] data = new byte[1];

            crypto.GetNonZeroBytes(data);

            return (char)(chars[data[0] % (chars.Length)]);
        }

        protected void SendEmail(Diagnostic diagnostic, Exam exam)
        {
            var doctor = _doctorByProgRepository.GetValue(_ => _.DoctorId == diagnostic.DoctorId && _.HealthProgramId == diagnostic.HealthProgramId);

            var emailAddress = doctor.EmailAddress1;

            if (exam.LocalEmailAddress is not null)
            {
                emailAddress += $";{exam.LocalEmailAddress}";
            }

            List<Tuple<string, string>> replaceStrings = new List<Tuple<string, string>>();

            var site = "http://10.96.10.61:8026"; // HOMOLOG

            replaceStrings.Add(new Tuple<string, string>("[NOME_MEDICO]", doctor.FullName));
            replaceStrings.Add(new Tuple<string, string>("[NUMERO_PROTOCOLO]", exam.FriendlyCode));
            replaceStrings.Add(new Tuple<string, string>("[SITE]", $"<a href='{site}'>Diagnóstico Correto</a>"));

            var email = CreateEmail(diagnostic, "#NEW_REQUEST", emailAddress, replaceStrings);
            email.Subject = email.Subject.Replace("[NUMERO_PROTOCOLO]", exam.FriendlyCode);

            _emailService.Save(email);
        }

        private Email CreateEmail(Diagnostic diagnostic, string templateName, string emailAddress, List<Tuple<string, string>> replaceStrings, DateTime? sendScheduledDate = null)
        {
            var email = _emailService.MergeTemplateMail<Diagnostic>(Diagnostic.EntityName, Diagnostic.EntityTypeCode, templateName, diagnostic.Id, diagnostic.HealthProgramId.Value, false, emailAddress);

            if (email != null)
            {
                foreach (var item in replaceStrings)
                {
                    email.Body = email.Body.Replace(item.Item1, item.Item2);
                }
            }

            return email;
        }

        private void CreateEmailAndSave(Diagnostic diagnostic, string templateName, string emailAddress, List<Tuple<string, string>> replaceStrings, DateTime? sendScheduledDate = null)
        {
            var email = _emailService.MergeTemplateMail<Diagnostic>(Diagnostic.EntityName, Diagnostic.EntityTypeCode, templateName, diagnostic.Id, diagnostic.HealthProgramId.Value, false, emailAddress);

            if (email != null)
            {
                foreach (var item in replaceStrings)
                {
                    email.Body = email.Body.Replace(item.Item1, item.Item2);
                }
            }

            _emailService.Save(email);
        }

        public async Task<ReturnMessage<bool>> InformExamResult(ExamResultModel model, Guid userId)
        {
            var exam = _examRepository.GetValue(_ => _.Id == model.Id);

            switch (exam.HealthProgram.Code)
            {
                default:
                    return await InformExamResultGeneric(model, exam, userId);
                    break;
            }
        }

        public async Task<ReturnMessage<bool>> InformExamResultGeneric(ExamResultModel model, Exam exam, Guid userId)
        {
            ReturnMessage<bool> result = new ReturnMessage<bool>();

            var diagnostic = _diagnosticRepository.GetValue(_ => _.Id == exam.DiagnosticId);
            var doctor = _doctorByProgRepository.GetValue(_ => _.DoctorId == exam.DoctorId && _.HealthProgramId == exam.HealthProgramId && _.IsDeleted == false);

            if (exam is not null)
            {
                var examStatusConcludedStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntityAndProgram("EXAM_CONCLUDED", "Exam", "ExamStatusStringMap", exam.HealthProgramId.Value);

                exam.CurrentUserId = userId;
                exam.ExamStatusStringMapId = examStatusConcludedStringMap.StringMapId;
                exam.ResultStringMapId = model.ResultId;

                var examResult = _examRepository.Update(exam);

                if (examResult is not null)
                {
                    var logsSched = _logisticsScheduleRepository.GetValue(_ => _.ExamId == exam.Id && _.IsDeleted == false);

                    if (logsSched is not null)
                    {
                        var scheduleStatusStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntityAndProgram("#AVR", "LogisticsSchedule", "ScheduleStatusStringMap", new Guid("6FF88F55-C993-412A-A8E8-2CBBE9B9CFB5"));

                        logsSched.ResultDate = model.DateAnalisys;
                        logsSched.ScheduleStatusStringMapId = scheduleStatusStringMap.StringMapId;

                        _logisticsScheduleRepository.Update(logsSched);
                    }

                    AddSchedullingHistory(exam);

                    var annotationStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntityAndProgram("#APPRAISAL", "Annotation", "AnnotationTypeStringMap", exam.HealthProgramId.Value);
                    model.FileExamResultAttach.AnnotationTypeStringMapId = annotationStringMap.StringMapId;
                    model.FileExamResultAttach.Name = annotationStringMap.OptionName;

                    var resultAttach = AddAttachment(exam, model.FileExamResultAttach);

                    result.IsValidData = resultAttach.IsValidData;

                    List<Tuple<string, string>> replaceStrings = new List<Tuple<string, string>>();

                    var site = "https://localhost:7120";  // LOCAL
                                                          //var site = "http://10.96.10.61:8026"; // HOMOLOG

                    replaceStrings.Add(new Tuple<string, string>("[NUMERO_PROTOCOLO]", exam.FriendlyCode));
                    replaceStrings.Add(new Tuple<string, string>("[SITE]", $"<a href='{site}/Exam/[EMAIL_ID]'>Diagnóstico Correto</a>"));
                    replaceStrings.Add(new Tuple<string, string>("[NOME_MEDICO]", doctor.FullName));

                    var email = CreateEmail(diagnostic, "#RESULT_EXAM_DOCTOR", doctor.EmailAddress1, replaceStrings);
                    email.Body = email.Body.Replace("[EMAIL_ID]", email.Id.ToString());
                    email.OriginRegardingEntityId = new Guid(resultAttach.Value);
                    email.RegardingEntity.InternalControl = "[NOT_CLICKED]";

                    _emailService.Save(email);

                    return result;
                }
            }
            else
            {
                result.AdditionalMessage = "Exame não encontrado.";
                return result;
            }

            return result;
        }

        public string GetRandomKey(int len)
        {
            byte[] data = new byte[1];
            int maxSize = len;
            string ltrs = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chars = ltrs.ToCharArray();
            var result = string.Empty;

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(data);
                data = new byte[maxSize];
                rng.GetNonZeroBytes(data);
            }

            var resultBytes = data.Select(w => chars[w % (chars.Length)]).ToList();

            foreach (var item in resultBytes)
            {
                result += item.ToString();
            }

            return result;
        }

        public async Task<ReturnMessage<bool>> InformPendencyAnalisys(InformPendencyExamModel model, Guid userId)
        {
            var exam = _examRepository.GetExamComplete(model.Id);

            switch (exam.HealthProgram.Code)
            {
                default:
                    return await InformPendencyAnalisysGeneric(model, exam, userId);
                    break;
            }
        }

        public async Task<ReturnMessage<bool>> InformPendencyAnalisysGeneric(InformPendencyExamModel model, Exam exam, Guid userId)
        {
            ReturnMessage<bool> result = new ReturnMessage<bool>();

            var local = _accountSettingsByProgRepository.GetValue(_ => _.AccountId == exam.LocalId && _.HealthProgramId == exam.HealthProgramId);
            var docByProgram = _doctorByProgRepository.GetValue(_ => _.DoctorId == exam.DoctorId && _.IsDeleted == false && _.HealthProgramId == exam.HealthProgramId);

            if (exam is not null)
            {
                var examStatusStringMap = new StringMap();
                var examPendingDetailStringMap = new StringMap();
                var examStatusPendingStringMapList = _stringMapRepository.GetStringMapByEntityAndAttributeNameAndProgram("Exam", "ExamStatusStringMap", exam.HealthProgramId.Value);

                var scheduleStatusStringMapList = _stringMapRepository.GetStringMapByEntityAndAttributeNameAndProgram("LogisticsSchedule", "ScheduleStatusStringMap", new Guid("6FF88F55-C993-412A-A8E8-2CBBE9B9CFB5"));
                var scheduleStatusStringMap = new StringMap();

                if (model.PendencyId != Guid.Empty && model.PendencyDetailId != Guid.Empty)
                {
                    examStatusStringMap = examStatusPendingStringMapList.Where(_ => _.Flag == "EXAM_CANCELED").FirstOrDefault();
                    examPendingDetailStringMap = _stringMapRepository.GetValue(_ => _.StringMapId == model.PendencyDetailId);

                    scheduleStatusStringMap = scheduleStatusStringMapList.Where(_ => _.Flag == "#CAN").FirstOrDefault();
                }
                else
                {
                    examStatusStringMap = examStatusPendingStringMapList.Where(_ => _.Flag == "EXAM_PENDING").FirstOrDefault();
                    scheduleStatusStringMap = scheduleStatusStringMapList.Where(_ => _.Flag == "#ANALISYS_PENDENCY").FirstOrDefault();
                }

                var reasonStatusPendencyStringMap = _stringMapRepository.GetValue(_ => _.StringMapId == model.PendencyId);

                exam.CurrentUserId = userId;
                exam.ExamStatusStringMapId = examStatusStringMap.StringMapId;
                exam.ReschedulingReasonStringMapId = reasonStatusPendencyStringMap.StringMapId;

                var validationExam = _examRepository.Update(exam);

                if (validationExam is not null)
                {
                    var logsSched = _logisticsScheduleRepository.Find(_ => _.ExamId == exam.Id && _.IsDeleted == false).FirstOrDefault();

                    if (logsSched != null)
                    {
                        if (model.PendencyId != Guid.Empty && model.PendencyDetailId != Guid.Empty)
                            logsSched.CancelDate = DateTime.Now;
                        else
                            logsSched.PendingAnalysisDate = DateTime.Now;

                        logsSched.ScheduleStatusStringMapId = scheduleStatusStringMap.StringMapId;
                        logsSched.CurrentUserId = userId;

                        _logisticsScheduleRepository.Update(logsSched);
                    }

                    AddSchedullingHistory(exam, examPendingDetailStringMap.OptionName);

                    List<Tuple<string, string>> replaceStrings = new List<Tuple<string, string>>();

                    var site = "http://10.96.10.61:8026"; // HOMOLOG
                                                          //var site = "http://10.96.10.61:8026"; // HOMOLOG

                    replaceStrings.Add(new Tuple<string, string>("[NUMERO_PROTOCOLO]", exam.FriendlyCode));
                    replaceStrings.Add(new Tuple<string, string>("[SITE]", $"<a href='{site}'>Diagnóstico Correto</a>"));

                    if (model.PendencyDetailId != Guid.Empty)
                    {
                        replaceStrings.Add(new Tuple<string, string>("[NOME_MEDICO]", docByProgram.FullName));
                        replaceStrings.Add(new Tuple<string, string>("[MOTIVO_CANCELAMENTO]", examPendingDetailStringMap.OptionName));

                        CreateEmailAndSave(exam.Diagnostic, "#EXAM_CANCELED", $"{docByProgram.EmailAddress1};{local.EmailAddress}", replaceStrings);
                    }
                    else
                        CreateEmailAndSave(exam.Diagnostic, "#ANALISYS_PENDENCY", $"{docByProgram.EmailAddress1};{local.EmailAddress}", replaceStrings);

                    result.AdditionalMessage = "Exame atualizado com sucesso.";
                    result.Value = true;

                    return result;
                }
            }
            else
            {
                result.AdditionalMessage = "Erro ao atualizar exame.";
                result.Value = false;
            }

            return result;
        }

        public async Task<ReturnMessage<string>> Delete(Guid Id, string programCode)
        {
            ReturnMessage<string> result = new ReturnMessage<string>();

            var diagnostic = _diagnosticRepository.GetValue(d => d.Id == Id);
            var patient = _patientRepository.GetValue(p => p.Id == diagnostic.PatientId);
            var user = _userRepository.GetValue(u => u.Id == patient.SystemUserId);

            var statusCodeStringMapId = _stringMapService.GetStringMapByEntityAndAttributeAndFlag("Diagnostic", "StatusCodeStringMap", "#IACTV").Result.StringMapId;
            diagnostic.IsDeleted = true;
            diagnostic.StateCode = false;
            diagnostic.StatusCodeStringMapId = statusCodeStringMapId;

            _diagnosticRepository.Update(diagnostic);

            statusCodeStringMapId = _stringMapService.GetStringMapByEntityAndAttributeAndFlag("Patient", "StatusCodeStringMap", "#IACTV").Result.StringMapId;
            patient.IsDeleted = true;
            patient.StateCode = false;
            patient.StatusCodeStringMapId = statusCodeStringMapId;

            _patientRepository.Update(patient);

            statusCodeStringMapId = _stringMapService.GetStringMapByEntityAndAttributeAndFlag("User", "StatusCodeStringMap", "#IACTV").Result.StringMapId;
            user.IsDeleted = true;
            user.StateCode = false;
            user.StatusCodeStringMapId = statusCodeStringMapId;

            _userRepository.Update(user);

            result.Value = "Cadastro excluído com sucesso.";
            result.IsValidData = true;
            result.AdditionalMessage = "200";

            return result;
        }

        public async Task<PatientResultModel> GetDiagnosticByCPF(string cpf)
        {

            var diagnostic = await GetByCPF(cpf);

            PatientResultModel patient = new PatientResultModel();

            try
            {
                if (diagnostic != null)
                {
                    patient.FullName = diagnostic.FullName.IfNotEmptyReturnValue();
                    patient.Birthdate = diagnostic.Birthdate;
                    patient.GenderStringMapId = diagnostic.GenderStringMapId;
                    patient.Telephone1 = diagnostic.Telephone1.IfNotEmptyReturnValue(); ;
                    patient.Mobilephone1 = diagnostic.Mobilephone1.IfNotEmptyReturnValue();
                    patient.EmailAddress1 = diagnostic.EmailAddress1.IfNotEmptyReturnValue();
                    patient.AddressPostalCode = diagnostic.AddressPostalCode.IfNotEmptyReturnValue();
                    patient.AddressName = diagnostic.AddressName.IfNotEmptyReturnValue();
                    patient.AddressNumber = diagnostic.AddressNumber.IfNotEmptyReturnValue();
                    patient.AddressDistrict = diagnostic.AddressDistrict.IfNotEmptyReturnValue();
                    patient.AddressCity = diagnostic.AddressCity.IfNotEmptyReturnValue();
                    patient.AddressState = diagnostic.AddressState.IfNotEmptyReturnValue();
                    patient.AddressComplement = diagnostic.AddressComplement.IfNotEmptyReturnValue();

                }

            }
            catch (Exception ex)
            {

            }

            return patient;
        }
        public async Task<Diagnostic> GetByCPF(string cpf)
        {
            Diagnostic diagnostic = new Diagnostic();

            Diagnostic? diagnosticCpf = await _diagnosticRepository.GetByCPF(cpf);

            ReturnMessage<string> result = new ReturnMessage<string>();

            try
            {
                if (diagnosticCpf is not null)
                {
                    diagnostic.FullName = diagnosticCpf.FullName;
                    diagnostic.Birthdate = diagnosticCpf.Birthdate;
                    diagnostic.GenderStringMapId = diagnosticCpf.GenderStringMapId;
                    diagnostic.Telephone1 = diagnosticCpf.Telephone1;
                    diagnostic.Mobilephone1 = diagnosticCpf.Mobilephone1;
                    diagnostic.EmailAddress1 = diagnosticCpf.EmailAddress1;
                    diagnostic.AddressPostalCode = diagnosticCpf.AddressPostalCode;
                    diagnostic.AddressName = diagnosticCpf.AddressName;
                    diagnostic.AddressNumber = diagnosticCpf.AddressNumber;
                    diagnostic.AddressDistrict = diagnosticCpf.AddressDistrict;
                    diagnostic.AddressCity = diagnosticCpf.AddressCity;
                    diagnostic.AddressState = diagnosticCpf.AddressState;
                    diagnostic.AddressComplement = diagnosticCpf.AddressComplement;
                }

            }
            catch (Exception ex)
            {

            }

            return diagnostic;
        }

        public virtual Task<ReturnMessage<string>> AddUserPatient(ExamCreateModel model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PaginationResult<List<DiagnosticExamResultModel>>> ListExamByDiagnostic(ExamFilterModel model, string programcode, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<DiagnosticExamModel> Get(Guid Id, string programCode)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> Inactivate(Guid Id, string programCode)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Account>> ListNearbyAccounts(Guid userId, string addressPostalCode, int? page = 1, int? pageSize = 5)
        {
            var accountlist = new List<Account>();
            var returnList = new List<Account>();
            var user = _userRepository.GetValue(u => u.Id == userId);
            var patient = _patientRepository.GetValue(p => p.SystemUserId == userId);
            if (patient == null) return new List<Account>();

            var diagnostic = _diagnosticRepository.GetValue(d => d.PatientId == patient.Id);
            var accessProfileEcp = _accessProfileRepository.GetValue(x => x.HealthProgramId == patient.HealthProgramId && x.Name == "Partner ECP VisionCare");
            var accountSettingsByProgramList = await _accountSettingsByProgRepository
                                                    .Queryable()
                                                    .Include(x => x.SystemUser)
                                                        .ThenInclude(x => x.AccessProfiles)
                                                    .Where(x => x.HealthProgramId == patient.HealthProgramId
                                                            && !x.IsDeleted
                                                            && x.StateCode == true
                                                            && x.SystemUser.AccessProfiles.Any(x => x.Id == accessProfileEcp.Id))
                                                    .ToListAsync();

            double latitudePatient = 0.0;
            double longitudePatient = 0.0;

            if (addressPostalCode == diagnostic.AddressPostalCode)
            {
                var address = $"{diagnostic.AddressState}, {diagnostic.AddressCity}, {diagnostic.AddressName}, {diagnostic.AddressNumber}, {diagnostic.AddressDistrict}, {diagnostic.AddressPostalCode.Replace("-", "")}";
                var coordenadasRetorno = Helper.Helper.GetLatitudeLongitude(address);

                if (coordenadasRetorno.IsValidData)
                {
                    var coordenadas = JsonSerializer.Deserialize<JsonElement>(coordenadasRetorno.Value);
                    double.TryParse(coordenadas.GetProperty("latitude").ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out latitudePatient);
                    double.TryParse(coordenadas.GetProperty("longitude").ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out longitudePatient);
                }
            }
            else
            {
                var coordenadasRetorno = Helper.Helper.GetLatitudeLongitude(addressPostalCode);

                if (coordenadasRetorno.IsValidData)
                {
                    var coordenadas = JsonSerializer.Deserialize<JsonElement>(coordenadasRetorno.Value);
                    double.TryParse(coordenadas.GetProperty("latitude").ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out latitudePatient);
                    double.TryParse(coordenadas.GetProperty("longitude").ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out longitudePatient);
                }
            }

            foreach (var asp in accountSettingsByProgramList)
            {
                var account = _accountRepository.GetValue(a => a.IsDeleted == false && a.StateCode == true && a.Id == asp.AccountId);

                if (account.Latitude == null || account.Longitude == null || account.AddressState != "SP")
                {
                    account.InternalControl = "200";
                    accountlist.Add(account);
                }
                else
                {
                    double.TryParse(account.Latitude, NumberStyles.Float, CultureInfo.InvariantCulture, out double latitudeDouble);
                    double.TryParse(account.Longitude, NumberStyles.Float, CultureInfo.InvariantCulture, out double longitudeDouble);

                    var distancia = Helper.Helper.CalculateDistance(latitudeDouble, longitudeDouble, latitudePatient, longitudePatient);
                    account.InternalControl = distancia.ToString();
                    accountlist.Add(account);
                }
            }
            var accountorderedlist = accountlist
                                    .OrderBy(a => double.Parse(a.InternalControl.Replace(',', '.'), CultureInfo.InvariantCulture))
                                    .Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value)
                                    .ToList();

            return accountorderedlist;
        }

        public virtual Task<ReturnMessage<string>> ScheduleVisitToClinic(VisitCreateModel model, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnMessage<string>> EditVisitToClinic(VisitEditModel model, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnMessage<string>> ConfirmVisitAttendance(VisitAttendanceModel model, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnMessage<string>> CancelVisitAttendance(VisitAttendanceModel model, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnMessage<string>> PatientNotAttended(VisitAttendanceModel model, Guid userId)
        {
            throw new NotImplementedException();
        }
        public Task<List<VisitAttendanceResponse>> ListVisitAttendance(Guid userId,
                                                               string programCode,
                                                               bool? isVisitConfirmed = false,
                                                               bool? isAttendanceConfirmed = false,
                                                               bool? isAttendanceCanceled = false,
                                                               bool? isAttendancePreCanceled = false,
                                                               int page = 1,
                                                               int pageSize = 5)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnMessage<string>> ConfirmVisitToClinic(Guid visitId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnMessage<string>> CancelVisitToClinic(Guid visitId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VisitListModel>> ListVisitsToClinic(Guid userId, string programCode, bool? isPreScheduling = false, bool? isConfirmed = false, bool? isCanceled = null, string? month = null, int page = 1, int pageSize = 5)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitDetailsModel> ListVisitDetails(Guid visitId, string programCode)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ReturnMessage<string>> ScheduleVisit(VisitCreateModel model, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PaginationResult<List<DiagnosticServiceTypeResultModel>>> ListDiagnosticsByServiceType(DiagnosticFilterModel model, string programcode, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<DiagnosticExamModel> GetPatientInformationIndependencia(Guid userId, string programcode)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> RequestDiagnosticExamList(RequestDiagnosticExamModel model, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PaginationResult<List<DiagnosticExamModel>>> ListNurse(DiagnosticFilterModel model, Guid userId, string programcode)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PaginationResult<List<DiagnosticExamResultModel>>> ListExamByDiagnosticNurse(ExamFilterModel model, string programcode, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> SendSmsDiagnostic(Guid diagnosticId, string mobilephone, string voucher, string templatename)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> SendEmailDiagnostic(Guid diagnosticId, string emailaddress, string voucher, string templatename)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> SendSmsDiagnosticPatient(string mobilephone, string voucher, string templatename, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> SendEmailDiagnosticPatient(string emailaddress, string voucher, string templatename, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}