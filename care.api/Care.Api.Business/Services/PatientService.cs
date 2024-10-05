using AutoMapper;
using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.Models.Message.Request;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Care.Api.Models.Exceptions;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Business.Services;

public class PatientService : IPatientService
{
    protected readonly IPatientRepository _patientRepository;
    protected readonly IUserRepository _userRepository;
    protected readonly IHealthProgramRepository _healthProgramRepository;
    protected readonly IDiagnosticRepository _diagnosticRepository;
    protected readonly IDoctorByProgramRepository _doctorByProgramRepository;
    protected readonly IExamRepository _examRepository;
    protected readonly IVoucherRepository _voucherRepository;
    protected readonly IExamDefinitionRepository _examDefinitionRepository;
    protected readonly IStringMapRepository _stringMapRepository;
    protected readonly ITreatmentRepository _treatmentRepository;
    protected readonly IAnnotationRepository _annotationRepository;

    public PatientService(IPatientRepository patientRepository, IUserRepository userRepository, IHealthProgramRepository healthProgramRepository, IDiagnosticRepository diagnosticRepository, IDoctorByProgramRepository doctorByProgramRepository, IExamRepository examRepository, IVoucherRepository voucherRepository, IExamDefinitionRepository examDefinitionRepository, IStringMapRepository stringMapRepository, ITreatmentRepository treatmentRepository, IAnnotationRepository annotationRepository)
    {
        _patientRepository = patientRepository;
        _userRepository = userRepository;
        _healthProgramRepository = healthProgramRepository;
        _diagnosticRepository = diagnosticRepository;
        _doctorByProgramRepository = doctorByProgramRepository;
        _examRepository = examRepository;
        _voucherRepository = voucherRepository;
        _examDefinitionRepository = examDefinitionRepository;
        _stringMapRepository = stringMapRepository;
        _treatmentRepository = treatmentRepository;
        _annotationRepository = annotationRepository;
    }

    public async Task<ReturnMessage<PatientModel>> GetPatientByCpfProgram(string cpf, Guid healthProgramId, string registerType)
    {
        if (registerType == "Diagnostic")
        {
            var patientDiagResult = GetPatientByCpfProgramDiagnostic(cpf, healthProgramId);
            var result = new ReturnMessage<PatientModel>();

            result.Value = patientDiagResult;
            result.IsValidData = true;

            return result;
        }
        else
        {
            var patientTreatResult = GetPatientByCpfProgramTreatment(cpf, healthProgramId);

            var result = new ReturnMessage<PatientModel>();

            result.Value = patientTreatResult;
            result.IsValidData = true;

            return result;

        }



    }

    private PatientModel GetPatientByCpfProgramDiagnostic(string cpf, Guid healthProgramId)
    {
        var patientDiagResult = _diagnosticRepository.GetDiagnosticByCpfProgram(cpf, healthProgramId);

        var patient = patientDiagResult.Result;

        PatientModel patientModel = new PatientModel();

        if (patient is not null)
        {
            patientModel.Id = patient.Id;
            patientModel.Name = patient.Name is null ? "" : patient.Name;

            patientModel.FullName = patient.FullName is null ? "" : patient.FullName;

            //Telefone 
            patientModel.Phones = new List<PhoneModel>();

            if (patient.Telephone1 is not null)
            {

                patientModel.HealthProgramId = patient.HealthProgramId;

                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Telephone1.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }
            if (patient.Telephone2 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Telephone2.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }
            if (patient.Telephone3 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Telephone3.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }

            //Celular
            if (patient.Mobilephone1 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Mobilephone1.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }
            if (patient.Mobilephone2 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Mobilephone2.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }
            if (patient.Mobilephone3 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Mobilephone3.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }


            //Emails
            patientModel.Emails = new List<EmailModel>();

            if (patient.EmailAddress1 is not null)
            {
                EmailModel emailModel = new EmailModel();
                emailModel.Address = patient.EmailAddress1;
                patientModel.Emails.Add(emailModel);
            }
            if (patient.EmailAddress2 is not null)
            {
                EmailModel emailModel = new EmailModel();
                emailModel.Address = patient.EmailAddress2;
                patientModel.Emails.Add(emailModel);
            }

        }


        return patientModel;
    }

    private PatientModel GetPatientByCpfProgramTreatment(string cpf, Guid healthProgramId)
    {
        var patientTreatResult = _treatmentRepository.GetTreatmentByCpfProgram(cpf, healthProgramId);

        var patient = patientTreatResult.Result;

        PatientModel patientModel = new PatientModel();

        if (patient is not null)
        {
            patientModel.Id = patient.Id;
            patientModel.Name = patient.Name is null ? "" : patient.Name;

            patientModel.FullName = patient.FullName is null ? "" : patient.FullName;

            //Telefone 
            patientModel.Phones = new List<PhoneModel>();

            if (patient.Telephone1 is not null)
            {

                patientModel.HealthProgramId = patient.HealthProgramId;

                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Telephone1.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }
            if (patient.Telephone2 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Telephone2.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }
            if (patient.Telephone3 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Telephone3.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }

            //Celular
            if (patient.Mobilephone1 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Mobilephone1.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }
            if (patient.Mobilephone2 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Mobilephone2.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }
            if (patient.Mobilephone3 is not null)
            {
                PhoneModel phoneModel = new PhoneModel();
                string phone = patient.Mobilephone3.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                phoneModel.Ddd = phone.Substring(0, 2);
                phoneModel.Number = phone.Substring(2);
                patientModel.Phones.Add(phoneModel);
            }


            //Emails
            patientModel.Emails = new List<EmailModel>();

            if (patient.EmailAddress1 is not null)
            {
                EmailModel emailModel = new EmailModel();
                emailModel.Address = patient.EmailAddress1;
                patientModel.Emails.Add(emailModel);
            }
            if (patient.EmailAddress2 is not null)
            {
                EmailModel emailModel = new EmailModel();
                emailModel.Address = patient.EmailAddress2;
                patientModel.Emails.Add(emailModel);
            }

        }

        return patientModel;
    }

    public Task<ReturnMessage<Diagnostic>> AddPatient(DiagnosticExamCreateModel model, Guid userId, string programcode)
    {
        var result = new ReturnMessage<Diagnostic>();
        var healthProgram = _healthProgramRepository.GetValue(_ => _.Code == programcode);

        var diagnostic = _diagnosticRepository.Find(_ => _.Cpf.Replace(".", "").Replace("-", "") == model.CPF.Replace(".", "").Replace("-", "")
                                              && _.IsDeleted == false
                                              && _.HealthProgramId == healthProgram.Id
                                              && _.StateCode.Value).FirstOrDefault();

        if (diagnostic is not null)
        {
            result.Value = diagnostic;
            result.IsValidData = true;
            return System.Threading.Tasks.Task.FromResult(result);
        }

        var doctor = _doctorByProgramRepository.GetValue(_ => _.HealthProgramId == healthProgram.Id
                                                      //&& _.SystemUserId == userId
                                                      && _.LicenseNumber == model.LicenseNumber
                                                      && _.LicenseState == model.LicenseState
                                                      && _.IsDeleted == false);
        if (doctor is null)
        {
            result.IsValidData = false;
            result.AdditionalMessage = "Médico não localizado.";
            return System.Threading.Tasks.Task.FromResult(result);
        }

        var examDefinition = _examDefinitionRepository.GetValue(_ => _.Name == model.ExamName);

        if (examDefinition is null)
        {
            result.IsValidData = false;
            result.AdditionalMessage = "Exame não localizado.";
            return System.Threading.Tasks.Task.FromResult(result);
        }

        Diagnostic newDiagnostic = new Diagnostic();
        newDiagnostic.Id = Guid.NewGuid();

        if (model.PatientName.IndexOf(" ") > 0)
        {
            newDiagnostic.FirstName = model.PatientName.Substring(0, model.PatientName.IndexOf(" ")).Trim();
            newDiagnostic.LastName = model.PatientName.Substring(model.PatientName.IndexOf(" "), model.PatientName.Length - model.PatientName.IndexOf(" ")).Trim();
        }

        if (!string.IsNullOrEmpty(model.NameCaregiver) && model.NameCaregiver.IndexOf(" ") > 0)
        {
            newDiagnostic.FirstNameCaregiver = model.NameCaregiver.Substring(0, model.NameCaregiver.IndexOf(" ")).Trim();
            newDiagnostic.LastNameCaregiver = model.NameCaregiver.Substring(model.NameCaregiver.IndexOf(" "), model.NameCaregiver.Length - model.NameCaregiver.IndexOf(" ")).Trim();
        }

        newDiagnostic.HealthProgramId = healthProgram.Id;
        newDiagnostic.DoctorId = doctor.Id;
        newDiagnostic.ExamDefinitionId = examDefinition.Id;
        newDiagnostic.FullName = model.PatientName;



        _diagnosticRepository.Insert(newDiagnostic);

        result.Value = newDiagnostic;
        result.IsValidData = true;

        return System.Threading.Tasks.Task.FromResult(result);
    }

    public PatientModel UpdatePatient(PatientModel patientModel)
    {
        Patient patientFound = _patientRepository.GetValue(p => p.Id == patientModel.Id);

        if (patientFound is not null)
        {
            IMapper _mapper;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientModel, Patient>();
            });

            _mapper = config.CreateMapper();
            _mapper.Map(patientModel, patientFound);
            var patient = _patientRepository.Update(patientFound);
        }

        return patientModel;
    }

    public async Task<PaginationResult<List<DiagnosticResultModel>>> GetPatients(DiagnosticFilterModel model, Guid userId, string programcode)
    {
        PaginationResult<List<DiagnosticResultModel>> result = new PaginationResult<List<DiagnosticResultModel>>();

        var healthprogram = _healthProgramRepository.GetValue(_ => _.Code == programcode);

        var user = _userRepository.GetUserById(userId, programcode);
        var profile = user.AccessProfiles.FirstOrDefault()!.Name;

        switch (profile)
        {
            case ("DOCTOR"):
                //    result = GetPatientsByDoctor(model, user, healthprogram.Id);
                break;
            //case ("LABORATORY"):
            //    result = GetPatientsByLaboratory(model, user, healthprogram.Id);
            //    break;
            case ("OPERATION"):
                switch (programcode)
                {
                    default:
                        result = await GetPatientsByOperationGeneric(model, user, healthprogram.Id);
                        break;
                }
                break;
            default:
                break;
        }

        return result;
    }

    private bool VerifyHasFilterDoctor(DiagnosticFilterModel model)
    {
        //if (model.Doctor != Guid.Empty)
        //    return true;

        if (model.EndDate.HasValue)
            return true;
        else if (model.ExamStatus != Guid.Empty)
            return true;
        else if (!string.IsNullOrEmpty(model.NumberProtocol))
            return true;
        else if (!string.IsNullOrEmpty(model.PatientCPF))
            return true;
        else if (!string.IsNullOrEmpty(model.PatientName))
            return true;
        else if (model.PatientStatus != Guid.Empty)
            return true;
        else if (model.ResultStatus != Guid.Empty)
            return true;
        else if (model.StartDate.HasValue)
            return true;
        else if (!string.IsNullOrEmpty(model.TypeDate))
            return true;

        return false;
    }

    private async Task<PaginationResult<List<DiagnosticResultModel>>> GetPatientsByOperationGeneric(DiagnosticFilterModel model, User user, Guid healthProgramId)
    {
        List<DiagnosticResultModel> listDiagExam = new List<DiagnosticResultModel>();


        //var diagnostics = _diagnosticRepository.GetValues(p => p.HealthProgramId == healthProgramId);
        var diagnostics = await _diagnosticRepository.GetDiagnosticsByProgram(healthProgramId);

        if (diagnostics is null)
        {
            return new PaginationResult<List<DiagnosticResultModel>>();
        }

        if (diagnostics.Count() == 0)
        {
            return new PaginationResult<List<DiagnosticResultModel>>();
        }

        foreach (var diag in diagnostics)
        {
            var diagExam = new DiagnosticResultModel()
            {
                DoctorId = diag.DoctorId,
                CPF = diag.Cpf,
                CreatedOn = diag.Exams.FirstOrDefault()!.CreatedOn.HasValue ? diag.Exams.FirstOrDefault()!.CreatedOn!.Value : DateTime.MinValue,
                ExamDefinition = diag.Exams.FirstOrDefault()!.ExamDefinitionId.HasValue ? diag.Exams.FirstOrDefault()!.ExamDefinitionId!.Value : Guid.Empty,
                ExamStatus = diag.Exams.FirstOrDefault()!.ExamStatusStringMapId.HasValue ? diag.Exams.FirstOrDefault()!.ExamStatusStringMapId!.Value : Guid.Empty,
                FileReport = string.Empty,
                NamePatient = diag.FullName,
                NumberProtocol = diag.Exams.FirstOrDefault()!.FriendlyCode,
                PatientStatus = diag.StatusCodeStringMap is null ? Guid.Empty : diag.StatusCodeStringMap!.StringMapId,
                ScheduledDate = diag.Exams.FirstOrDefault()!.ScheduleDate.HasValue ? diag.Exams.FirstOrDefault()!.ScheduleDate!.Value : DateTime.MinValue,
                //ReasonPendingCanceled = ReasonPendencyOrCanceled(exam),
                ReasonPendingCanceled = diag.Exams.FirstOrDefault()!.ReschedulingReasonStringMap is null ? "" : diag.Exams.FirstOrDefault()!.ReschedulingReasonStringMap!.OptionName,
                Result = diag.Exams.FirstOrDefault()!.ResultStringMap is null ? Guid.Empty : diag.Exams.FirstOrDefault()!.ResultStringMap!.StringMapId,
                //Voucher = exam.Voucher.Number
                Voucher = diag.Exams.FirstOrDefault()!.Voucher!.Number,
                DoctorName = diag.Doctor!.DoctorByPrograms.FirstOrDefault()!.FullName,
                CRMUF = $"{diag.Doctor!.DoctorByPrograms.FirstOrDefault()!.LicenseNumber}/{diag.Doctor!.DoctorByPrograms.FirstOrDefault()!.LicenseState}",
                Exame = diag.Exams.FirstOrDefault()!.ExamDefinition is null ? "" : diag.Exams.FirstOrDefault()!.ExamDefinition!.Name,
                ExamStatusName = diag.Exams.FirstOrDefault()!.ExamStatusStringMap is null ? "" : diag.Exams.FirstOrDefault()!.ExamStatusStringMap!.OptionName,
                LaboratoryResult = diag.Exams.FirstOrDefault()!.ResultStringMap is null ? "" : diag.Exams.FirstOrDefault()!.ResultStringMap!.OptionName,
                PatientStatusName = diag.StatusCodeStringMap is null ? "" : diag.StatusCodeStringMap!.OptionName,
            };

            listDiagExam.Add(diagExam);

            //var doctor = _doctorByProgramRepository.GetValue(_ => _.DoctorId == diag.DoctorId);
            //var exams = _examRepository.GetValues(_ => _.DiagnosticId == diag.Id && _.HealthProgramId == healthProgramId && _.DoctorId == doctor.DoctorId);

            //foreach (var exam in exams)
            //{
            //    var voucher = _voucherRepository.GetValue(_ => _.Id == exam.VoucherId);
            //    var examDefinition = _examDefinitionRepository.GetValue(_ => _.Id == exam.ExamDefinitionId);
            //    var examStatus = _stringMapRepository.GetValue(_ => _.StringMapId == exam.ExamStatusStringMapId && _.ProgramId == healthProgramId);
            //    var reschedulingReason = _stringMapRepository.GetValue(_ => _.StringMapId == exam.ReschedulingReasonStringMapId && _.ProgramId == healthProgramId);
            //    var laboratoryResult = _stringMapRepository.GetValue(_ => _.StringMapId == exam.ResultStringMapId && _.ProgramId == healthProgramId);
            //    var attachmentBase64 = string.Empty;

            //    //if (exam.ResultStringMapId != null)
            //    //{
            //    //    var annotation = null; //coreDapper.GetAnnotationsAttachment<Annotation>(diag.Id, "#APPRAISAL");

            //    //    if (annotation != null)
            //    //    {
            //    //        var attachment = null; //coreDapper.GetAttachment<Attachment>(annotation.Id);
            //    //        attachmentBase64 = attachment.DocumentBody;
            //    //    }
            //    //}

            //    var diagExam = new DiagnosticResultModel()
            //    {
            //        DoctorId = doctor.DoctorId,
            //        CPF = diag.Cpf,
            //        CreatedOn = exam.CreatedOn.HasValue ? exam.CreatedOn.Value : DateTime.MinValue,
            //        ExamDefinition = exam.ExamDefinitionId.HasValue ? exam.ExamDefinitionId.Value : Guid.Empty,
            //        ExamStatus = exam.ExamStatusStringMapId.HasValue ? exam.ExamStatusStringMapId.Value : Guid.Empty,
            //        FileReport = attachmentBase64,
            //        NamePatient = diag.FullName,
            //        NumberProtocol = exam.FriendlyCode,
            //        PatientStatus = diag.StatusCodeStringMapId.HasValue ? diag.StatusCodeStringMapId.Value : Guid.Empty,
            //        ScheduledDate = exam.ScheduleDate.HasValue ? exam.ScheduleDate.Value : DateTime.MinValue,
            //        //ReasonPendingCanceled = ReasonPendencyOrCanceled(exam),
            //        ReasonPendingCanceled = reschedulingReason is null ? "" : reschedulingReason.OptionName,
            //        Result = exam.ResultStringMapId.HasValue ? exam.ResultStringMapId.Value : Guid.Empty,
            //        //Voucher = exam.Voucher.Number
            //        Voucher = voucher.Number,
            //        DoctorName = doctor.FullName,
            //        CRMUF = $"{doctor.LicenseNumber}/{doctor.LicenseState}",
            //        Exame = examDefinition.Name,
            //        ExamStatusName = examStatus.OptionName,
            //        LaboratoryResult = laboratoryResult is null ? "" : laboratoryResult.OptionName
            //    };

            //    listDiagExam.Add(diagExam);
            //}
        }

        var examsFiltered = FilterExams(model, listDiagExam);

        return new PaginationResult<List<DiagnosticResultModel>>
        {
            TotalSize = VerifyHasFilterDoctor(model) ? examsFiltered.Count : listDiagExam.Count,
            Data = examsFiltered
        };
    }

    public List<DiagnosticResultModel> FilterExams(DiagnosticFilterModel model, List<DiagnosticResultModel> exams)
    {

        var skip = (model.Page - 1) * model.PageSize;

        if (!string.IsNullOrEmpty(model.NumberProtocol))
        {
            exams = exams.Where(_ => !string.IsNullOrEmpty(_.NumberProtocol) && _.NumberProtocol.Contains(model.NumberProtocol)).ToList();
        }
        if (!string.IsNullOrEmpty(model.PatientName))
        {
            exams = exams.Where(_ => _.NamePatient.Contains(model.PatientName)).ToList();
        }
        if (!string.IsNullOrEmpty(model.PatientCPF))
        {
            var cpfSearched = model.PatientCPF.Replace(".", "").Replace("-", "");
            exams = exams.Where(_ => _.CPF.Replace(".", "").Replace("-", "").Contains(cpfSearched)).ToList();
        }
        //if (model.PatientStatus != Guid.Empty)
        //{
        //    exams = exams.Where(_ => _.PatientStatus.Equals(model.PatientStatus)).ToList();
        //}
        //if (model.ExamStatus != Guid.Empty)
        //{
        //    exams = exams.Where(_ => _.ExamStatus.Equals(model.ExamStatus)).ToList();
        //}
        //if (model.ResultStatus != Guid.Empty)
        //{
        //    exams = exams.Where(_ => _.Result.Equals(model.ResultStatus)).ToList();
        //}
        //// LAB
        //if (model.Doctor != Guid.Empty)
        //{
        //    exams = exams.Where(_ => _.DoctorId.Equals(model.Doctor)).ToList();
        //}

        if (!string.IsNullOrEmpty(model.TypeDate))
        {
            if (model.TypeDate.Equals("DATE_REQUESTED"))
            {
                if (model.StartDate.HasValue)
                    exams = exams.Where(_ => _.CreatedOn.Value.Date >= model.StartDate.Value.Date).ToList();
                if (model.EndDate.HasValue)
                    exams = exams.Where(_ => _.CreatedOn.Value.Date <= model.EndDate.Value.Date).ToList();
            }
            else
            {
                if (model.StartDate.HasValue)
                    exams = exams.Where(_ => _.ScheduledDate.Value.Date >= model.StartDate.Value.Date).ToList();
                if (model.EndDate.HasValue)
                    exams = exams.Where(_ => _.ScheduledDate.Value.Date <= model.EndDate.Value.Date).ToList();
            }
        }

        exams = exams.OrderByDescending(_ => _.CreatedOn).Skip(skip).Take(model.PageSize).ToList();

        return exams;
    }

    public bool AddPatientExam(PatientRequest model, string registerType)
    {
        if (registerType == "Treatment")
        {
            return AddPatientTreatmentExam(model);
        }
        else
        {
            return AddPatientDiagnosticExam(model);
        }
    }

    private bool AddPatientTreatmentExam(PatientRequest model)
    {
        try
        {

            var doctorByProgram = _doctorByProgramRepository.GetDoctorByUser(model.Doctor.UserId);

            if (doctorByProgram is not null)
            {
                Treatment newTreatment = new Treatment();
                newTreatment.Id = Guid.NewGuid();
                newTreatment.Cpf = model.Cpf;

                if (model.Name.IndexOf(" ") > 0)
                {
                    newTreatment.FirstName = model.Name.Substring(0, model.Name.IndexOf(" ")).Trim();
                    newTreatment.LastName = model.Name.Substring(model.Name.IndexOf(" "), model.Name.Length - model.Name.IndexOf(" ")).Trim();
                }


                newTreatment.HealthProgramId = model.HealthProgram.Id;
                newTreatment.DoctorId = doctorByProgram.DoctorId;
                newTreatment.FullName = model.Name;
                newTreatment.Name = model.Name;
                newTreatment.ConsentToReceivePhonecalls = true;
                newTreatment.ProgramParticipationConsent = true;
                newTreatment.ConsentLgpd = true;
                newTreatment.TreatmentStatusStringMapId = Guid.Parse("D24E33EA-D2D6-46F4-AAEA-EB96AFB361B8");


                for (int i = 0; i < model.Phones.Count; i++)
                {
                    if (model.Phones[i].Number.Substring(0, 1) == "9")
                    {
                        if (String.IsNullOrEmpty(newTreatment.Mobilephone1))
                        {
                            newTreatment.Mobilephone1 = model.Phones[i].Ddd + model.Phones[i].Number;
                        }
                        else if (String.IsNullOrEmpty(newTreatment.Mobilephone2))
                        {
                            newTreatment.Mobilephone2 = model.Phones[i].Ddd + model.Phones[i].Number;
                        }
                        else
                        {
                            newTreatment.Mobilephone3 = model.Phones[i].Ddd + model.Phones[i].Number;
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(newTreatment.Telephone1))
                        {
                            newTreatment.Telephone1 = model.Phones[i].Ddd + model.Phones[i].Number;
                        }
                        else if (String.IsNullOrEmpty(newTreatment.Telephone2))
                        {
                            newTreatment.Telephone2 = model.Phones[i].Ddd + model.Phones[i].Number;
                        }
                        else
                        {
                            newTreatment.Telephone3 = model.Phones[i].Ddd + model.Phones[i].Number;
                        }
                    }


                }

                for (int k = 0; k < model.Emails.Count; k++)
                {
                    if (k == 0)
                    {
                        newTreatment.EmailAddress1 = model.Emails[k].Address;
                    }
                    else
                    {
                        newTreatment.EmailAddress2 = model.Emails[k].Address;
                    }
                }

                newTreatment.DiseaseId = model.Pathology.Id;
                newTreatment.MedicamentId = model.Medication.Id;
                var treatment = _treatmentRepository.Insert(newTreatment);

                AddExamPatient(model, newTreatment.Id, doctorByProgram.DoctorId, null);

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            //throw ex;
            return false;
        }

        //System.Threading.Tasks.Task.FromResult(result);
    }

    protected ReturnMessage<string> AddAttachment(AttachmentModel model, Diagnostic diagnostic)
    {

        ReturnMessage<string> result = new ReturnMessage<string>();

        Api.Models.Annotation annotation = new Api.Models.Annotation();
        annotation.Id = Guid.NewGuid();
        annotation.Name = model.FileName;
        annotation.Subject = model.FileName;
        annotation.AnnotationTypeStringMapId = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity("#PRSC", "Annotation", "AnnotationTypeStringMap").StringMapId;


        var regardingEntity = new RegardingEntity()
        {
            //DE
            Name = Treatment.EntityName,
            Id = Guid.NewGuid(),
            RegardingObjectIdTarget = diagnostic.Id,
            RegardingEntityTypeCodeTarget = Treatment.EntityTypeCode,
            RegardingEntityNameTarget = Treatment.EntityName,
            RegardingObjectIdNameTarget = Treatment.EntityName,
            //PARA
            RegardingObjectIdSource = annotation.Id,
            RegardingEntityTypeCodeSource = Api.Models.Annotation.EntityTypeCode,
            RegardingEntityNameSource = Api.Models.Annotation.EntityName,
            RegardingObjectIdNameSource = Api.Models.Annotation.EntityName,
            InternalControl = diagnostic.FriendlyCode,
        };

        annotation.RegardingEntity = regardingEntity;

        Api.Models.Attachment attachment = new Api.Models.Attachment();
        attachment.FileName = model.FileName;
        attachment.Id = Guid.NewGuid();
        attachment.MimeType = model.ContentType;
        attachment.FileSize = model.FileSize;

        int index = model.DocumentBody.IndexOf('/', model.DocumentBody.IndexOf('/') + 1);

        string body = model.DocumentBody.Substring(index + 1);

        attachment.DocumentBody = body;
        attachment.AnnotationId = annotation.Id;

        annotation.Attachments.Add(attachment);

        var validationAnnotation = _annotationRepository.Insert(annotation);

        if (validationAnnotation.IsValid)
        {
            result.IsValidData = validationAnnotation.IsValid;
            result.Value = annotation.Id.ToString();
            return result;
        }

        return result;
    }

    private void AddExamPatient(PatientRequest model, Guid? treatmentId, Guid? doctorId, Guid? examDefinitionId)
    {
        Exam exam = new Exam();

        exam.Id = Guid.NewGuid();
        exam.HealthProgramId = model.HealthProgram.Id;
        exam.TreatmentId = treatmentId;
        exam.DoctorId = doctorId;
        exam.ScheduleDate = DateTime.Now;
        if (examDefinitionId is not null)
        {
            exam.ExamDefinitionId = examDefinitionId;
        }
        exam.ExamStatusStringMapId = Guid.Parse("D24E33EA-D2D6-46F4-AAEA-EB96AFB361B8");

        _examRepository.Insert(exam);


    }

    private bool AddPatientDiagnosticExam(PatientRequest model)
    {
        try
        {

            var doctor = _doctorByProgramRepository.GetDoctorByUser(model.Doctor.UserId);


            Diagnostic newDiagnostic = new Diagnostic();
            newDiagnostic.Id = Guid.NewGuid();
            newDiagnostic.Cpf = model.Cpf;

            if (model.Name.IndexOf(" ") > 0)
            {
                newDiagnostic.FirstName = model.Name.Substring(0, model.Name.IndexOf(" ")).Trim();
                newDiagnostic.LastName = model.Name.Substring(model.Name.IndexOf(" "), model.Name.Length - model.Name.IndexOf(" ")).Trim();
            }


            newDiagnostic.HealthProgramId = model.HealthProgram.Id;
            newDiagnostic.DoctorId = doctor.DoctorId;
            newDiagnostic.FullName = model.Name;
            newDiagnostic.Name = model.Name;
            newDiagnostic.ConsentToReceivePhonecalls = true;
            newDiagnostic.ProgramParticipationConsent = true;
            newDiagnostic.ConsentLgpd = true;
            newDiagnostic.ExamDefinitionId = model.ExamsDefinition[0].Id;
            newDiagnostic.DiagnosticStatusStringMapId = Guid.Parse("D24E33EA-D2D6-46F4-AAEA-EB96AFB361B8");


            for (int i = 0; i < model.Phones.Count; i++)
            {
                if (model.Phones[i].Number.Substring(0, 1) == "9")
                {
                    if (String.IsNullOrEmpty(newDiagnostic.Mobilephone1))
                    {
                        newDiagnostic.Mobilephone1 = model.Phones[i].Ddd + model.Phones[i].Number;
                    }
                    else if (String.IsNullOrEmpty(newDiagnostic.Mobilephone2))
                    {
                        newDiagnostic.Mobilephone2 = model.Phones[i].Ddd + model.Phones[i].Number;
                    }
                    else
                    {
                        newDiagnostic.Mobilephone3 = model.Phones[i].Ddd + model.Phones[i].Number;
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(newDiagnostic.Telephone1))
                    {
                        newDiagnostic.Telephone1 = model.Phones[i].Ddd + model.Phones[i].Number;
                    }
                    else if (String.IsNullOrEmpty(newDiagnostic.Telephone2))
                    {
                        newDiagnostic.Telephone2 = model.Phones[i].Ddd + model.Phones[i].Number;
                    }
                    else
                    {
                        newDiagnostic.Telephone3 = model.Phones[i].Ddd + model.Phones[i].Number;
                    }
                }

            }

            for (int k = 0; k < model.Emails.Count; k++)
            {
                if (k == 0)
                {
                    newDiagnostic.EmailAddress1 = model.Emails[k].Address;
                }
                else
                {
                    newDiagnostic.EmailAddress2 = model.Emails[k].Address;
                }
            }

            //newDiagnostic.DiseaseId = model.Pathology.Id;

            _diagnosticRepository.Insert(newDiagnostic);

            foreach (var itemPrescription in model.MedicalPrescriptionsAttach)
            {
                var resultAnnotation = AddAttachment(itemPrescription, newDiagnostic);
            }

            foreach (var itemExamDefinition in model.ExamsDefinition)
            {
                AddExamPatient(model, newDiagnostic.Id, newDiagnostic.DoctorId, itemExamDefinition.Id);
            }



            return true;

        }
        catch (Exception ex)
        {

            //throw ex;
            return false;
        }

        //System.Threading.Tasks.Task.FromResult(result);
    }

    public async Task<Guid?> SavePatient(PatientRequest patientModel)
    {
        if (patientModel.HealthProgram is null)
        {
            throw new Exception("É necessário informar os dados do programa...");
        }

        if (patientModel.Name is null)
        {
            throw new UserException("É necessário informar o nome do paciente...");
        }

        Patient patient = new()
        {
            FirstName = patientModel.Name[..patientModel.Name.IndexOf(" ")].Trim(),
            LastName = patientModel.Name[patientModel.Name.IndexOf(" ")..].Trim(),
            Name = patientModel.Name,
            Cpf = patientModel.Cpf,
            HealthProgramId = patientModel.HealthProgram.Id,
            StateCode = true
        };

        if (patientModel.Id is null)
        {
            patient.Id = Guid.NewGuid();

            var result = await _patientRepository.InsertAsync(patient);

            if (!result.IsValid)
            {
                throw new Exception(result.Message);
            }
        }
        else
        {
            await _patientRepository.UpdateAsync(patient);
        }

        return patient.Id;
    }

    public Task<ReturnMessage<PatientModel>> GetPatientByCpfProgram(string cpf, string programCode, string registerType)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<string>> AddExam(PatientRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<Tuple<string, string>>> DownloadReport(Guid diagnosticId)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<bool>> UploadFiles(PatientUploadFilesModel model)
    {
        throw new NotImplementedException();
    }
}
