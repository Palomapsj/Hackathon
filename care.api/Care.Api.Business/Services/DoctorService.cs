using AutoMapper;
using Care.Api.Business.Helper;
using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Security;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Care.Api.Business.Services;

public class DoctorService : IDoctorService
{
    protected readonly IDoctorRepository _doctorRepository;
    protected readonly IDoctorByProgramRepository _doctorByProgramRepository;
    protected readonly IHealthProgramRepository _healthProgramRepository;
    protected readonly IMedicalSpecialtyRepository _medicalSpecialtyRepository;
    protected readonly ICFMService _cfmService;
    protected readonly IUserService _userService;
    protected readonly IEmailService _emailService;
    protected readonly IEmailRepository _emailRepository;
    protected readonly IUserRepository _userRepository;
    protected readonly ICustomerAddressRepository _customerAddressRepository;
    protected readonly IExamRepository _examRepository;
    protected readonly IRegardingEntityRepository _regardingEntityRepository;
    protected readonly IAnnotationRepository _annotationRepository;
    protected readonly IServiceProvider serviceProvider;
    protected readonly IHealthProgramRepository healthProgramRepository;
    protected readonly IExamRepository examRepository;
    protected readonly IAnnotationRepository annotationRepository;
    protected readonly ICustomerAddressRepository customerAddressRepository;
    protected readonly IEmailService emailService;
    protected readonly ISmsService _smsService;
    protected readonly ISmsRepository _smsRepository;
    protected readonly ITemplateRepository _templateRepository;
    protected readonly IDoctorByProgramRepository doctorByProgramRepository;
    protected readonly IMedicalSpecialtyRepository medicalSpecialtyRepository;
    protected readonly IUserService userService;
    protected readonly IRegardingEntityRepository regardingEntityRepository;
    protected readonly ISmsRepository smsRepository;
    protected readonly ISmsService smsService;
    protected readonly ITemplateRepository templateRepository;
    protected readonly IAccessProfileRepository _accessProfileRepository;
    protected readonly ICryptographyService _cryptographyService;
    protected readonly IConfigurationRepository _configurationRepository;
    protected readonly IRepresentativeRepository _representativeRepository;
    protected readonly IDoctorsRepresentativeRepository _doctorsRepresentativeRepository;

    public DoctorService(
        IDoctorRepository doctorRepository,
        ICFMService cfmService,
        IDoctorByProgramRepository doctorByProgramRepository,
        IHealthProgramRepository healthProgramRepository,
        IMedicalSpecialtyRepository medicalSpecialtyRepository,
        IUserService userService,
        IServiceProvider serviceProvider,
        IEmailService emailService,
        IEmailRepository emailRepository,
        ICustomerAddressRepository customerAddressRepository,
        IExamRepository examRepository,
        IRegardingEntityRepository regardingEntityRepository,
        IAnnotationRepository annotationRepository,
        ISmsRepository smsRepository,
        ISmsService smsService,
        ITemplateRepository templateRepository,
        IAccessProfileRepository accessProfileRepository,
        ICryptographyService cryptographyService,
        IUserRepository userRepository,
        IConfigurationRepository configurationRepository,
        IDoctorsRepresentativeRepository doctorsRepresentativeRepository
        )
    {
        _doctorRepository = doctorRepository;
        _cfmService = cfmService;
        _doctorByProgramRepository = doctorByProgramRepository;
        _healthProgramRepository = healthProgramRepository;
        _medicalSpecialtyRepository = medicalSpecialtyRepository;
        _userService = userService;
        _emailService = emailService;
        _emailRepository = emailRepository;
        _customerAddressRepository = customerAddressRepository;
        _examRepository = examRepository;
        _regardingEntityRepository = regardingEntityRepository;
        _annotationRepository = annotationRepository;
        _smsRepository = smsRepository;
        _smsService = smsService;
        _templateRepository = templateRepository;
        _accessProfileRepository = accessProfileRepository;
        _cryptographyService = cryptographyService;
        _userRepository = userRepository;
        _configurationRepository = configurationRepository;
        _doctorsRepresentativeRepository = doctorsRepresentativeRepository;
    }

    public async Task<PaginationResult<List<DoctorResultModel>>> GetDoctors(DoctorFilterModel model, Guid userId, string programcode)
    {
        var healthprogram = _healthProgramRepository.GetValue(_ => _.Code == programcode);

        switch (programcode)
        {
            default:
                return await GetDoctorsGeneric(model, userId, healthprogram);
                break;
        }
    }

    public async Task<PaginationResult<List<DoctorResultModel>>> GetDoctorsGeneric(DoctorFilterModel model, Guid userId, Care.Api.Models.HealthProgram healthprogram)
    {
        PaginationResult<List<DoctorResultModel>> result = new PaginationResult<List<DoctorResultModel>>();

        var user = _userRepository.GetUserById(userId, healthprogram.Code);
        var profile = user.AccessProfiles.FirstOrDefault()!.Name;

        switch (profile)
        {
            case ("DOCTOR"):
                break;
            case ("LABORATORY"):
                result = await GetDoctorsRequested(model, healthprogram.Id);
                break;
            case ("OPERATION"):
                result = await GetDoctorsByProgram(model, user, healthprogram.Id);
                break;
            default:
                result = await GetDoctorsRequested(model, healthprogram.Id);
                break;
        }

        return result;
    }

    public async Task<ReturnMessage<string>> Add(DoctorModel doctorModel)
    {
        ReturnMessage<string> result = new ReturnMessage<string>();

        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == doctorModel.HealthProgramCode).Id;

        var doctorFound = _doctorByProgramRepository.GetValue(d => d.LicenseNumber == doctorModel.LicenseNumber
                                                                && d.LicenseState == doctorModel.LicenseState
                                                                && d.HealthProgram.Code == doctorModel.HealthProgramCode
                                                                && d.IsDeleted == false);

        if (doctorFound is null)
        {
            var doctorBase = _doctorRepository.GetValue(_ => _.LicenseNumber == doctorModel.LicenseNumber
                                                                && _.LicenseState == doctorModel.LicenseState
                                                                && _.IsDeleted == false);
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<DoctorModel, DoctorByProgram>()
                .ForMember(o => o.Mobilephone1, opt => opt.MapFrom(s => s.TelephoneNumber))
                .ForMember(o => o.Specialty, opt => opt.MapFrom(s => s.MedicalSpecialty))
                .ForMember(o => o.ModifiedBy, opt => opt.MapFrom(s => new Guid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")))
                .ForMember(o => o.OwnerId, opt => opt.MapFrom(s => new Guid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")))
                .ForMember(o => o.StatusCodeStringMapId, opt => opt.MapFrom(s => new Guid("7DB42492-05CD-4F30-A4E9-9CBCFBD2A39E")))
                .ForMember(o => o.ModifiedByName, opt => opt.MapFrom(s => "Admin"))
                .ForMember(o => o.OwnerIdName, opt => opt.MapFrom(s => "Admin"))
                .ForMember(o => o.EmailAddress1, opt => opt.MapFrom(s => s.EmailAddress));
            });

            var mapper = mapperConfig.CreateMapper();

            var doctor = mapper.Map<DoctorByProgram>(doctorModel);
            doctor.HealthProgramId = healthProgramId;

            var doctorName = doctorModel.DoctorName.IfNotEmptyReturnValue();

            if (doctorName.IndexOf(" ") > 0)
            {
                doctor.FirstName = doctorName.Substring(0, doctorName.IndexOf(" ")).Trim();
                doctor.LastName = doctorName.Substring(doctorName.IndexOf(" "), doctorName.Length - doctorName.IndexOf(" ")).Trim();
            }

            doctor.Id = Guid.NewGuid();
            doctor.DoctorId = doctorBase.Id;
            doctor.FullName = doctorName;
            doctor.Name = doctorName;
            doctor.ProgramParticipationConsent = true;
            doctor.ProgramParticipationConsentDate = DateTime.Now;
            doctor.ConsentLgpd = true;
            doctor.ProgramParticipationConsent2 = true;
            doctor.ConfirmPersonalInformation = true;
            doctor.SystemUserId = null;

            var doctorResult = _doctorByProgramRepository.Insert(doctor);

            string mail;
            switch (doctorModel.HealthProgramCode)
            {
                case ("995"):
                    mail = "operacao@lilly.com.br";
                    break;
                case ("049"):
                    mail = "noreply@suporteaopaciente.com.br";
                    break;
                default:
                    mail = "noreply@suporteaopaciente.com.br";
                    break;
            }


            if (doctorResult.IsValid)
            {
                List<Tuple<string, string>> replaceStrings = new List<Tuple<string, string>>();
                var site = "https://diagnosticocorreto.viveo.com.br";

                replaceStrings.Add(new Tuple<string, string>("[SITE]", $"<a href='{site}'>Diagnóstico Correto</a>"));
                CreateEmailAndSave(doctor, "#WELCOME_DOCTOR", doctor.EmailAddress1, replaceStrings);

                _emailService.MergeTemplateMail<DoctorByProgram>(DoctorByProgram.EntityName, DoctorByProgram.EntityTypeCode, "#NEW_DOCTOR", doctor.Id, doctor.HealthProgramId.Value, true, mail);

                var mapperUserConfig = new MapperConfiguration(c =>
                {
                    c.CreateMap<DoctorModel, UserCreateModel>()
                        .ForMember(o => o.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
                        .ForMember(o => o.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress))
                        .ForMember(o => o.Name, opt => opt.MapFrom(s => s.DoctorName ?? string.Empty))
                        .ForMember(o => o.UserName, opt => opt.MapFrom(s => s.DoctorName ?? string.Empty));
                });

                var mapperUser = mapperUserConfig.CreateMapper();

                var userModel = mapperUser.Map<UserCreateModel>(doctorModel);

                userModel.ProgramCode = doctorModel.HealthProgramCode;

                var newUser = _userService.CreateUser(userModel);

                doctor.SystemUserId = newUser.Id;

                _doctorByProgramRepository.Update(doctor);

                result.Value = "Médico cadastrado no programa com sucesso.";
                result.IsValidData = false;
                result.AdditionalMessage = "200";
                return result;
            }
            else
            {
                result.Value = "Médico não cadastrado no programa.";
                result.IsValidData = false;
                result.AdditionalMessage = "500";
                return result;
            }

        }
        else
        {
            result.Value = "Médico já cadastrado no programa.";
            result.IsValidData = false;
            result.AdditionalMessage = "200";
            return result;
        }
    }

    public Task<ReturnMessage<DoctorModel>> UpdateDoctor(DoctorModel doctorModel)
    {
        Doctor doctorFound = _doctorRepository.GetValue(p => p.Id == doctorModel.Id);

        IMapper _mapper;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DoctorModel, Doctor>();
        });

        _mapper = config.CreateMapper();
        _mapper.Map(doctorModel, doctorFound);
        var doctor = _doctorRepository.Update(doctorFound);

        var result = new ReturnMessage<DoctorModel>
        {
            Value = doctorModel,
            AdditionalMessage = "Dados atualizados com sucesso",
            IsUserException = false,
            IsValidData = true
        };

        return System.Threading.Tasks.Task.FromResult(result);
    }

    public async Task<DoctorCFMModel?> GetDoctorByCRMUF(string crm, string ufcrm)
    {
        var doctor = await _cfmService.GetByLicense(crm, ufcrm);
        var licenseRegularStringMapId = new Guid("11BB86DC-E1BD-41C2-A067-6AAF858E9FD7");

        // TO DO
        // UTILIZAR RULES
        if (doctor.LicenseStatusStringMapId != licenseRegularStringMapId)
            return null;

        DoctorCFMModel doctorRestModel = new DoctorCFMModel();

        if (doctor != null)
        {
            doctorRestModel.Id = doctor.Id;
            doctorRestModel.Name = doctor.FirstName + " " + doctor.LastName;

            doctorRestModel.LicenseNumber = doctor.LicenseNumber.IfNotEmptyReturnValue();
            doctorRestModel.LicenseState = doctor.LicenseState.IfNotEmptyReturnValue();
            doctorRestModel.Email = doctor.EmailAddress1.IfNotEmptyReturnValue();
            doctorRestModel.Telephone = doctor.Telephone1.IfNotEmptyReturnValue();
            doctorRestModel.AddressCity = doctor.AddressCity.IfNotEmptyReturnValue();
            doctorRestModel.AddressDistrict = doctor.AddressDistrict.IfNotEmptyReturnValue();
            doctorRestModel.AddressState = doctor.AddressState.IfNotEmptyReturnValue();
            doctorRestModel.AddressNumber = doctor.AddressNumber.IfNotEmptyReturnValue();
            doctorRestModel.AddressName = doctor.AddressName.IfNotEmptyReturnValue();
            doctorRestModel.AddressComplement = doctor.AddressComplement.IfNotEmptyReturnValue();
            doctorRestModel.AddressPostalCode = doctor.AddressPostalCode.IfNotEmptyReturnValue();

            if (doctor.LicenseStatusStringMapId == licenseRegularStringMapId)
                doctorRestModel.Status = "REGULAR";

            if (doctor.MedicalSpecialties != null && doctor.MedicalSpecialties.Any())
            {
                var specialties = "";
                foreach (var item in doctor.MedicalSpecialties)
                {
                    if (string.IsNullOrEmpty(specialties))
                        specialties = item.Name;
                    else
                        specialties = specialties + "|" + item.Name;
                }
                doctorRestModel.MedicalSpecialty = specialties;
            }
        }

        return doctorRestModel;
    }
    public bool ForgorLoginbyCRM(ForgotLoginbyCRMModel forgotLoginbyCRMModel)
    {

        if (string.IsNullOrEmpty(forgotLoginbyCRMModel.licenseNumber) || string.IsNullOrEmpty(forgotLoginbyCRMModel.licenseState) || string.IsNullOrEmpty(forgotLoginbyCRMModel.healthProgramCode))
        {
            return false;
        }

        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == forgotLoginbyCRMModel.healthProgramCode).Id;

        DoctorByProgram doctorFound = GetDoctorByCRMDatabase(forgotLoginbyCRMModel.licenseNumber, forgotLoginbyCRMModel.licenseState, healthProgramId);

        if (doctorFound is null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(doctorFound.Name))
        {
            return false;
        }

        User user = _userService.GetUserById(doctorFound.SystemUserId);

        if (user == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(user.Name))
        {
            return false;
        }

        if (doctorFound.SystemUserId is null)
        {
            return false;
        }

        var login = user.UserName;

        Email _email = _emailService.MergeTemplateMail<User>(User.EntityName, User.EntityTypeCode, "#RECOVERYPASSWORD", doctorFound.SystemUserId.Value, healthProgramId, false, user.Email);
        if (_email == null)
        {
            return false;
        }
        else
        {
            _email.Body = _email.Body.Replace("[login]", login);

            _emailService.Save(_email);
        }

        return true;
    }

    public bool RecoveryPassword(ForgotPasswordDoctorModel forgotPasswordDoctorModel)
    {
        if (string.IsNullOrEmpty(forgotPasswordDoctorModel.CRM) || string.IsNullOrEmpty(forgotPasswordDoctorModel.CRMUF) || string.IsNullOrEmpty(forgotPasswordDoctorModel.Code))
        {
            return false;
        }

        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == forgotPasswordDoctorModel.Code).Id;

        DoctorByProgram doctorFound = GetDoctorByCRMDatabase(forgotPasswordDoctorModel.CRM, forgotPasswordDoctorModel.CRMUF, healthProgramId);

        if (doctorFound is null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(doctorFound.Name))
        {
            return false;
        }

        User user = _userService.GetUserById(doctorFound.SystemUserId);

        if (user == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(user.Name))
        {
            return false;
        }

        if (doctorFound.SystemUserId is null)
        {
            return false;
        }

        _userService.ChangePassword(user, "Mudar@123", forgotPasswordDoctorModel.Code, true);

        string mail;
        switch (forgotPasswordDoctorModel.Code)
        {
            case ("995"):
                mail = "operacao@lilly.com.br";
                break;
            case ("049"):
                mail = "noreply@suporteaopaciente.com.br";
                break;
            default:
                mail = "noreply@suporteaopaciente.com.br";
                break;
        }

        Email _email = _emailService.MergeTemplateMail<User>(User.EntityName, User.EntityTypeCode, "#RECOVERYPASSWORD", doctorFound.SystemUserId.Value, healthProgramId, true, mail);
        if (_email == null)
        {
            return false;
        }

        return true;
    }

    public DoctorByProgram GetDoctorByCRMDatabase(string licenseNumber, string licenseState, Guid healthProgramId)
    {
        try
        {
            if (!string.IsNullOrEmpty(licenseNumber) && !string.IsNullOrEmpty(licenseState))
            {
                DoctorByProgram doctorFound = _doctorByProgramRepository.GetValue(d => d.LicenseNumber == licenseNumber && d.LicenseState == licenseState && d.HealthProgramId == healthProgramId && d.IsDeleted == false);

                if (doctorFound is not null)
                {
                    return doctorFound;
                }
            }
        }
        catch (Exception ex)
        {
        }

        return new DoctorByProgram();
    }

    //public List<DoctorModel> GetActiveDoctorsByProgrma(string healthProgramCode)
    //{
    //    List<DoctorByProgram> doctorFound = _doctorByProgramRepository.GetActiveDoctorByProgram(healthProgramCode);

    //    if (doctorFound is not null)
    //    {
    //        var mapperConfig = new MapperConfiguration(c =>
    //        {
    //            c.CreateMap<DoctorByProgram, DoctorModel>();
    //        });

    //        var mapper = mapperConfig.CreateMapper();

    //        List<DoctorModel> doctors = mapper.Map<List<DoctorModel>>(doctorFound);

    //        return doctors;
    //    }

    //    return new List<DoctorModel>();
    //}

    private async Task<PaginationResult<List<DoctorResultModel>>> GetDoctorsByProgram(DoctorFilterModel model, User user, Guid healthProgramId)
    {
        List<DoctorByProgram> doctorsFound = _doctorByProgramRepository.GetValues(_ => _.HealthProgramId == healthProgramId);

        if (doctorsFound is null)
        {
            return new PaginationResult<List<DoctorResultModel>>();
        }

        List<DoctorResultModel> doctors = new List<DoctorResultModel>();

        foreach (var doctor in doctorsFound)
        {
            doctors.Add(new DoctorResultModel
            {
                DoctorId = doctor.Id,
                CreatedOn = doctor.CreatedOn.HasValue ? doctor.CreatedOn : DateTime.MinValue,
                DoctorName = doctor.FullName,
                DoctorCRMUF = $"{doctor.LicenseNumber}/{doctor.LicenseState}",
                DoctorSpecialty = doctor.Specialty,
                Email = doctor.EmailAddress1,
                Mobilephone = doctor.Mobilephone1,
                AddressCity = doctor.AddressCity,
                AddressState = doctor.AddressState,
                StateCode = doctor.StateCode
            });
        }

        var doctorsFiltered = FilterExams(model, doctors);

        return new PaginationResult<List<DoctorResultModel>>
        {
            TotalSize = VerifyHasFilterDoctor(model) ? doctorsFiltered.Count : doctors.Count,
            Data = doctorsFiltered
        };
    }

    private async Task<PaginationResult<List<DoctorResultModel>>> GetDoctorsRequested(DoctorFilterModel model, Guid healthProgramId)
    {
        List<DoctorResultModel> doctorsFound = new List<DoctorResultModel>();

        var doctorsRequested = _examRepository.Find(_ => _.HealthProgramId == healthProgramId && _.IsDeleted == false).Select(_ => _.DoctorId).Distinct();

        if (doctorsRequested is null)
        {
            return new PaginationResult<List<DoctorResultModel>>();
        }

        foreach (var doctorId in doctorsRequested)
        {
            var doctor = _doctorByProgramRepository.GetValue(_ => _.HealthProgramId == healthProgramId && _.DoctorId == doctorId && _.IsDeleted == false);
            var newdoctor = new DoctorResultModel()
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.FullName,
                DoctorCRMUF = $"{doctor.LicenseNumber}/{doctor.LicenseState}",
                StateCode = true
            };

            doctorsFound.Add(newdoctor);
        }

        return new PaginationResult<List<DoctorResultModel>>
        {
            TotalSize = doctorsFound.Count,
            Data = doctorsFound
        };
    }

    public List<DoctorResultModel> FilterExams(DoctorFilterModel model, List<DoctorResultModel> doctors)
    {

        var skip = (model.Page - 1) * model.PageSize;

        if (!string.IsNullOrEmpty(model.DoctorName))
        {
            doctors = doctors.Where(_ => !string.IsNullOrEmpty(_.DoctorName) && _.DoctorName.Contains(model.DoctorName)).ToList();
        }

        if (!string.IsNullOrEmpty(model.DoctorCRMUF))
        {
            doctors = doctors.Where(_ => !string.IsNullOrEmpty(_.DoctorCRMUF) && _.DoctorCRMUF.Contains(model.DoctorCRMUF)).ToList();
        }

        if (!string.IsNullOrEmpty(model.DoctorSpecialty))
        {
            doctors = doctors.Where(_ => !string.IsNullOrEmpty(_.DoctorSpecialty) && _.DoctorSpecialty.Contains(model.DoctorSpecialty)).ToList();
        }


        //if (!string.IsNullOrEmpty(model.TypeDate))
        //{
        //    if (model.TypeDate.Equals("DATE_REQUESTED"))
        //    {
        //        if (model.StartDate.HasValue)
        //            exams = exams.Where(_ => _.CreatedOn.Date >= model.StartDate.Value.Date).ToList();
        //        if (model.EndDate.HasValue)
        //            exams = exams.Where(_ => _.CreatedOn.Date <= model.EndDate.Value.Date).ToList();
        //    }
        //    else
        //    {
        //        if (model.StartDate.HasValue)
        //            exams = exams.Where(_ => _.ScheduledDate.Date >= model.StartDate.Value.Date).ToList();
        //        if (model.EndDate.HasValue)
        //            exams = exams.Where(_ => _.ScheduledDate.Date <= model.EndDate.Value.Date).ToList();
        //    }
        //}

        doctors = doctors.OrderByDescending(_ => _.CreatedOn).Skip(skip).Take(model.PageSize).ToList();

        return doctors;
    }

    private bool VerifyHasFilterDoctor(DoctorFilterModel model)
    {
        if (!string.IsNullOrEmpty(model.DoctorCRMUF))
            return true;
        else if (!string.IsNullOrEmpty(model.DoctorName))
            return true;
        else if (!string.IsNullOrEmpty(model.DoctorSpecialty))
            return true;
        return false;
    }

    public DoctorModel GetDoctorInfo(Guid userId, string programcode)
    {
        switch (programcode)
        {
            default:
                return GetDoctorInfoGeneric(userId, programcode);
                break;
        }
    }

    public DoctorModel GetDoctorInfoGeneric(Guid userId, string programcode)
    {
        DoctorModel result = new DoctorModel();
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programcode).Id;

        var docByProg = _doctorByProgramRepository.GetValue(_ => _.SystemUserId == userId && _.HealthProgramId == healthProgramId);

        if (docByProg is not null)
        {
            result.DoctorId = docByProg.DoctorId.Value;
            result.LicenseNumber = docByProg.LicenseNumber;
            result.LicenseState = docByProg.LicenseState;
            result.Name = docByProg.FullName;

            return result;
        }
        else
        {
            return result;
        }
    }

    public async Task<List<MedicalSpecialtyModel>> GetMedicalSpecialties()
    {

        List<MedicalSpecialtyModel> result = new List<MedicalSpecialtyModel>();

        var medicalSpecialties = _medicalSpecialtyRepository.GetAll().Where(_ => _.IsDeleted == false).ToList();

        var mapperConfig = new MapperConfiguration(c => c.CreateMap<MedicalSpecialty, MedicalSpecialtyModel>());
        var mapper = mapperConfig.CreateMapper();

        result = mapper.Map<List<MedicalSpecialtyModel>>(medicalSpecialties);

        return result;

    }

    public async Task<List<AddressModel>> GetAddressByDoctor(Guid userId, string programcode)
    {
        List<AddressModel> result = new List<AddressModel>();

        var customerAddresses = _customerAddressRepository.GetAddressByDoctor(userId, programcode);

        var mapperConfig = new MapperConfiguration(c => c.CreateMap<CustomerAddress, AddressModel>());
        var mapper = mapperConfig.CreateMapper();

        result = mapper.Map<List<AddressModel>>(customerAddresses);

        return result;
    }

    public async Task<ReturnMessage<string>> WelcomeEmailResend(DoctorEmailResendModel model, Guid userId, string programcode)
    {
        switch (programcode)
        {
            default:
                return await WelcomeEmailResendGeneric(model, userId, programcode);
                break;
        }
    }

    public async Task<ReturnMessage<string>> WelcomeEmailResendGeneric(DoctorEmailResendModel model, Guid userId, string programcode)
    {
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programcode).Id;
        var doctorFound = _doctorByProgramRepository.GetValue(_ => _.Id == model.DoctorId && _.HealthProgramId == healthProgramId);

        if (doctorFound is null)
        {
            return new ReturnMessage<string>
            {
                Value = string.Empty,
                IsValidData = false,
                AdditionalMessage = "Médico não localizado."
            };
        }

        string emailAddress = string.Empty;

        if (string.IsNullOrEmpty(model.Email))
        {
            emailAddress = doctorFound.EmailAddress1;
        }
        else
        {
            emailAddress = model.Email;
        }

        Email email = _emailService.MergeTemplateMail<DoctorByProgram>(DoctorByProgram.EntityName, DoctorByProgram.EntityTypeCode, "#WELCOME_DOCTOR", doctorFound.Id, doctorFound.HealthProgramId.Value, true, emailAddress);

        if (email is null)
        {
            return new ReturnMessage<string>
            {
                Value = string.Empty,
                IsValidData = false,
                AdditionalMessage = "Falha ao enviar o e-mail."
            };
        }

        return new ReturnMessage<string>
        {
            Value = string.Empty,
            IsValidData = true,
            AdditionalMessage = "Email enviado com sucesso."
        };
    }

    public async Task<ReturnMessage<AttachmentModel>> GetAppraisal(Guid id, Guid userId)
    {
        ReturnMessage<AttachmentModel> result = new ReturnMessage<AttachmentModel>();

        var email = _emailService.GetById(id);
        var docByProg = _doctorByProgramRepository.GetValue(_ => _.SystemUserId == userId && _.HealthProgramId == email.HealthProgramId);

        var regardingEmail = _regardingEntityRepository.GetValue(_ => _.Id == email.RegardingEntityId);
        var regardingAnnotation = _regardingEntityRepository.GetValue(_ => _.Id == email.OriginRegardingEntityId);

        var annotation = _annotationRepository.GetAnnotationByRegardingId(regardingAnnotation.Id);

        if (annotation is not null)
        {
            var exam = _examRepository.GetValue(_ => _.FriendlyCode == annotation.RegardingEntity.InternalControl && _.IsDeleted == false);

            if (exam.DoctorId != docByProg.DoctorId)
            {
                result.IsValidData = false;
                result.AdditionalMessage = "Laudo não pertence ao médico.";

                return result;
            }
            else
            {

                var attachment = annotation.Attachments.FirstOrDefault();
                AttachmentModel attach = new AttachmentModel()
                {
                    FileName = attachment.FileName,
                    ContentType = attachment.MimeType,
                    DocumentBody = attachment.DocumentBody,
                    FileSize = attachment.FileSize,
                    Name = annotation.Subject,
                };

                result.IsValidData = true;
                result.Value = attach;

                regardingEmail.InternalControl = null;

                _regardingEntityRepository.Update(regardingEmail);

                return result;
            }
        }

        result.IsValidData = false;
        result.AdditionalMessage = "Arquivo não encontrado.";

        return result;

    }

    protected Email CreateEmailAndSave(DoctorByProgram doctor, string templateName, string emailAddress, List<Tuple<string, string>> replaceStrings, DateTime? sendScheduledDate = null)
    {
        var email = _emailService.MergeTemplateMail<DoctorByProgram>(DoctorByProgram.EntityName, DoctorByProgram.EntityTypeCode, templateName, doctor.Id, doctor.HealthProgramId.Value, false, emailAddress);

        if (email != null)
        {
            foreach (var item in replaceStrings)
            {
                email.Body = email.Body.Replace(item.Item1, item.Item2);
            }
            _emailService.Save(email);
        }



        return email;
    }

    public virtual async Task<ReturnMessage<string>> SendEmailDoctor(Guid userId, string emailaddress, string voucher, string templatename)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<ReturnMessage<string>> SendSmsDoctor(Guid userId, string emailaddress, string mobilephone, string templatename)
    {
        throw new NotImplementedException();
    }

    public Doctor GetDoctorByUserId(Guid Id, string programcode)
    {
        throw new NotImplementedException();
    }

    public virtual Task<PaginationResult<List<DoctorProgram>>> GetProgramsByUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<string>> AddProfessional(RepresentativeCreateModel model, Guid userId)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<ReturnMessage<string>> SendEmailDoctorAdmin(Guid userId, string emailaddress, string voucher, string templatename, string crm, string uf, string programcode)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<ReturnMessage<string>> SendSmsDoctorAdmin(Guid userId, string mobilephone, string voucher, string templatename, string crm, string uf, string programcode)
    {
        throw new NotImplementedException();
    }

    public virtual DoctorModel GetDoctorProgram(Guid doctorId, string programcode)
    {
        throw new NotImplementedException();
    }

    public virtual Task<ReturnMessage<string>> TermDoctor(TermDoctorResult termDoctor)
    {
        throw new NotImplementedException();
    }

    public virtual TermDoctorResult ValidateConsentDoctor(Guid doctorId, string programcode)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<DoctorModel>> UpdateDoctor(DoctorModel doctorModel, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<string>> AddHealthProfessional(RepresentativeCreateModel representative)
    {
        throw new NotImplementedException();
    }
    
    public Task<List<DoctorsByRepresentative>> GetDoctorsByProgram(string programcode)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<DoctorModel>> DisableDoctor(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<PaginationResult<List<RepresentativeResultModel>>> ListNurses(RepresentativeFilterModel model, string programcode, Guid? userId)
    {
        throw new NotImplementedException();
    }
    
    public bool ForgotLoginbyLicenseNumber(ForgotLoginbyLicenseNumber forgotLoginbyCRMModel)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<DoctorModel>> InactiveDoctor(InactiveDoctorModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<string>> ManagementNurses(ManagementNurses model, Guid userId)
    {
        throw new NotImplementedException();
    }
    
    public async Task<ReturnMessage<List<string>>> ValidateHealthProfessionalByProgram(string login)
    {
        throw new NotImplementedException();
    }
    public RepresentativeResultModel GetData(Guid userId, string programcode)
    {
        throw new NotImplementedException();
    }

    public async Task<ReturnMessage<List<DoctorExistResultModel>>> GetDoctorCRMUFByProgram(string crm, string ufcrm, string programcode)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<string>> AddHealthProfessionalByDoctor(RepresentativeCreateModel representative, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ReturnMessage<string>> RequestDoctorlBond(RepresentativeDoctorByProgramRequest representativeDoctorByProgramRequest, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ReturnMessage<string>> AlterRequestHealthProfessionalBondByDoctor(RepresentativeDoctorByProgramRequest representativeDoctorByProgramRequest, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RepresentativeByDoctorResultModel>> GetRepresentativeByDoctors(Guid userId, string programcode)
    {
        throw new NotImplementedException();
    }

    public virtual Task<PaginationResult<List<DoctorProgram>>> GetProfileByHealthProfessional(Guid userId)
    {
        throw new NotImplementedException();
    }
}
