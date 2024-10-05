using AutoMapper;
using Care.Api.Business.Interfaces;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.Models;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Security;
using AutoMapper;
using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Security;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Care.Api.Models.Models;
using Care.Api.Repository.Repositories;
using Care.Api.Context;
using Microsoft.AspNetCore.Mvc;
using Care.Api.Business.ServicesReturnMessage;
using System.Text.RegularExpressions;

namespace Care.Api.Business.Services;

public class UserService : IUserService
{
    protected readonly IUserRepository _userRepository;
    protected readonly ICryptographyService _cryptographyService;
    protected readonly IEmailService _emailService;
    protected readonly IHealthProgramRepository _healthProgramRepository;
    protected readonly IEmailRepository _emailRepository;
    protected readonly IAccessProfileRepository _accessProfileRepository;
    protected readonly IUserSystemLogRepository _userSystemLogRepository;
    protected readonly ITokenService _tokenService;
    protected readonly ITemplateRepository _templateRepository;
    protected readonly IAccessProfileUserRepository _accessProfileUserRepository;
    protected readonly IDoctorByProgramRepository _doctorByProgramRepository;
    protected readonly IDoctorRepository _doctorRepository;
    protected readonly IPatientRepository _patientRepository;

    public UserService(
        IUserRepository userRepository,
        ICryptographyService cryptographyService,
        IEmailService emailService,
        IHealthProgramRepository healthProgramRepository,
        IEmailRepository emailRepository,
        IAccessProfileRepository accessProfileRepository,
        IUserSystemLogRepository userSystemLogRepository,
        ITokenService tokenService,
        ITemplateRepository templateRepository,
        IAccessProfileUserRepository accessProfileUserRepository,
        IDoctorByProgramRepository doctorByProgramRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository
        )
    {
        _userRepository = userRepository;
        _cryptographyService = cryptographyService;
        _emailService = emailService;
        _healthProgramRepository = healthProgramRepository;
        _emailRepository = emailRepository;
        _accessProfileRepository = accessProfileRepository;
        _userSystemLogRepository = userSystemLogRepository;
        _tokenService = tokenService;
        _templateRepository = templateRepository;
        _accessProfileUserRepository = accessProfileUserRepository;
        _doctorByProgramRepository = doctorByProgramRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public bool IsValidUser(UserAuthModel userAuthModel)
    {
        try
        {
            string password = userAuthModel.Password is null ? "" : userAuthModel.Password;
            string passwordEncrypted = _cryptographyService.Encrypt(password);
            User user = _userRepository.GetValue(u => u.Email == userAuthModel.Email && u.Password == passwordEncrypted);
            return true;
        }
        catch (Exception ex)
        {
        }

        return false;
    }

    public bool EmailExists(string email, string programCode)
    {
        try
        {
            var user = _userRepository.GetUser(email, programCode);
            if (user is not null && user.AccessProfiles != null && user.AccessProfiles.Any()) return true;
        }
        catch
        {
            return false;
        }

        return false;
    }

    public User GetUser(UserAuthModel userAuthModel)
    {
        string password = _cryptographyService.Encrypt(userAuthModel.Password);

        return _userRepository.GetUser(userAuthModel.Email, password, userAuthModel.HealthProgramCode);
    }

    public string PostUserData(PostDataModel postDataModel)
    {
        string result = string.Empty;
        if (postDataModel.marker == "1")
        {
            User user = _userRepository.GetValue(u => u.Email == postDataModel.data && u.IsDeleted == false);
            if (user is null)
                return result = string.Empty;

            if (string.IsNullOrEmpty(user.Email))
                return result = string.Empty;

            user.Email = postDataModel.newData;
            var userFound = _userRepository.Update(user);
        }
        if (postDataModel.marker == "2")
        {
            User user = _userRepository.GetValue(u => u.Name == postDataModel.data && u.IsDeleted == false);
            if (user is null)
                return result = string.Empty;

            if (string.IsNullOrEmpty(user.Email))
                return result = string.Empty;

            user.Name = postDataModel.newData;
            var userFound = _userRepository.Update(user);
        }


        return result;


    }

    public User GetUserByEmail(string email)
    {
        try
        {
            User user = _userRepository.GetValue(u => u.Email == email);
            foreach (var p in user.AccessProfiles)
            {
                Console.WriteLine(p.Name);
            }
            return user;
        }
        catch (Exception ex)
        {
        }

        return new User();
    }

    public int GetCountAmountofAccesses(Guid Id)
    {

        User user = _userRepository.Find(u => u.Id == Id).FirstOrDefault();
        var count = _userSystemLogRepository.Find(_ => _.UserId == user.Id
                                                            && _.ActionName.Contains("LOGIN_SUCCESSFUL")).Count();

        return count;
    }

    public User GetUserById(Guid? id)
    {
        try
        {
            User user = _userRepository.GetValue(u => u.Id == id);
            foreach (var p in user.AccessProfiles)
            {
                Console.WriteLine(p.Name);
            }
            return user;
        }
        catch (Exception ex)
        {
        }

        return new User();
    }

    public virtual User CreateUser(UserCreateModel userModel)
    {
        var healthProgramId = _healthProgramRepository.Find(_ => _.Code == userModel.ProgramCode).FirstOrDefault();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.CreateMap<UserCreateModel, User>()
            .ForMember(o => o.CreatedBy, opt => opt.MapFrom(s => new Guid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")))
            .ForMember(o => o.ModifiedBy, opt => opt.MapFrom(s => new Guid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")))
            .ForMember(o => o.OwnerId, opt => opt.MapFrom(s => new Guid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")))
            .ForMember(o => o.StatusCodeStringMapId, opt => opt.MapFrom(s => new Guid("700F2D36-9745-40C9-BBF5-0F277D32E217")))
            .ForMember(o => o.CreatedByName, opt => opt.MapFrom(s => "Admin"))
            .ForMember(o => o.ModifiedByName, opt => opt.MapFrom(s => "Admin"))
            .ForMember(o => o.OwnerIdName, opt => opt.MapFrom(s => "Admin"))
            .ForMember(o => o.StateCode, opt => opt.MapFrom(s => true))
            .ForMember(o => o.Email, opt => opt.MapFrom(s => s.EmailAddress))
            .ForMember(o => o.Password, opt => opt.MapFrom(s => _cryptographyService.Encrypt(s.Password)))
            .ForMember(o => o.Language, opt => opt.MapFrom(s => 1046));
        });

        var profile = _accessProfileRepository.Find(_ => _.Name == "DOCTOR" && _.HealthProgramId == healthProgramId.Id).FirstOrDefault();
        var mapper = mapperConfig.CreateMapper();
        var newUser = mapper.Map<User>(userModel);
        newUser.AccessProfiles.Add(profile);

        var result = _userRepository.Insert(newUser);

        return newUser;
    }

    public UserListModel GetUserByIdAsListModel(Guid? id)
    {
        throw new NotImplementedException();
    }

    public virtual User CreateUser(UserCreateModel userModel, bool isSendSms = true)
    {
        try
        {

            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == userModel.ProgramCode).Id;
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UserCreateModel, User>()
                .ForMember(o => o.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
                .ForMember(o => o.Name, opt => opt.MapFrom(s => userModel.Name))
                .ForMember(o => o.UserName, opt => opt.MapFrom(s => userModel.EmailAddress))
                .ForMember(o => o.CreatedBy, opt => opt.MapFrom(s => new Guid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")))
                .ForMember(o => o.ModifiedBy, opt => opt.MapFrom(s => new Guid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")))
                .ForMember(o => o.OwnerId, opt => opt.MapFrom(s => new Guid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")))
                .ForMember(o => o.StatusCodeStringMapId, opt => opt.MapFrom(s => new Guid("700F2D36-9745-40C9-BBF5-0F277D32E217")))
                .ForMember(o => o.CreatedByName, opt => opt.MapFrom(s => "Admin"))
                .ForMember(o => o.ModifiedByName, opt => opt.MapFrom(s => "Admin"))
                .ForMember(o => o.OwnerIdName, opt => opt.MapFrom(s => "Admin"))
                .ForMember(o => o.StateCode, opt => opt.MapFrom(s => true))
                .ForMember(o => o.Email, opt => opt.MapFrom(s => s.EmailAddress))
                .ForMember(o => o.Password, opt => opt.MapFrom(s => _cryptographyService.Encrypt(s.Password)))
                .ForMember(o => o.Language, opt => opt.MapFrom(s => 1046))
                .ForMember(o => o.Profile, opt => opt.MapFrom(s => (Api.Models.Profile?)null));

            });

            AccessProfile profile = _accessProfileRepository.GetValue(_ => _.Name == userModel.Profile && _.HealthProgramId == healthProgramId);
            var mapper = mapperConfig.CreateMapper();
            var newUser = mapper.Map<User>(userModel);
            newUser.AccessProfiles.Add(profile);
            newUser.Id = Guid.NewGuid();
            newUser.UserName = newUser.Email;

            var result = _userRepository.Insert(newUser);

            return newUser;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public ReturnMessage<string> UpdateUser(Guid userId, UserUpdateModel model)
    {
        var result = new ReturnMessage<string>();
        try
        {

            User userNew = _userRepository.GetUserByEmail(model.UserEmail, model.ProgramCode);


            if (userNew is not null)
            {
                result.Value = "E-mail já está em uso.";
                result.IsValidData = false;
                result.AdditionalMessage = "500";
                return result;
            }

            User userOld = _userRepository.GetUserByEmail(model.UserOldEmail, model.ProgramCode);

            if (userOld is not null)
            {
                userOld.UserName = model.UserEmail;
                userOld.Email = model.UserEmail;

                var userFound = _userRepository.Update(userOld);

                result.Value = "Login atualizado com sucesso.";
                result.IsValidData = true;
                result.AdditionalMessage = "200";
                return result;
            }

            else
            {
                result.Value = "Error ao atualizar login, usuario não encontrado.";
                result.IsValidData = false;
                result.AdditionalMessage = "500";
                return result;
            }

        }
        catch (Exception ex)
        {
            result.Value = "Login não foi alterado";
            result.IsValidData = false;
            result.AdditionalMessage = "500";
            return result;
        }


    }
    public virtual bool ChangePassword(User user, string newPassword, string programCode, bool forceChangePwdNextLogin = false, string accessToken = null)
    {
        if (user is not null)
        {
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = _cryptographyService.Encrypt(newPassword);

                if (forceChangePwdNextLogin)
                    user.InternalControl = "FORCE_CHANGE_PWD;";
                else
                    user.InternalControl = "";

                var userFound = _userRepository.Update(user);

                if (userFound is not null)
                    return true;
            }
        }
        return false;
    }

    public bool ChangePersonalizedPassword(User user, string email, string telephone, bool forceChangePwdNextLogin = false)
    {
        if (user is not null)
        {
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = _cryptographyService.Encrypt(user.Password);

                user.Email = email;


                if (forceChangePwdNextLogin)
                    user.InternalControl = "FORCE_CHANGE_PWD;";
                else
                    user.InternalControl = "";

                var userFound = _userRepository.Update(user);

                if (userFound is not null)
                {
                    var doctorByProgram = _doctorByProgramRepository.Find(dbp => dbp.SystemUserId == user.Id).FirstOrDefault();


                    doctorByProgram.EmailAddress1 = email;
                    doctorByProgram.Telephone1 = telephone;


                    var result = _doctorByProgramRepository.Update(doctorByProgram);

                    if (result is not null)
                    {
                        var doctor = _doctorRepository.Find(d => d.Id == doctorByProgram.DoctorId).FirstOrDefault();


                        doctor.EmailAddress1 = email;
                        doctor.Telephone1 = telephone;

                        var result2 = _doctorRepository.Update(doctor);

                        if (result2 is not null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }

    public static string alfanumericoAleatorio(int tamanho)
    {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, tamanho)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

    public bool ForgorPassword(ForgotPasswordUserModel forgotPasswordDoctorModel)
    {
        var standardPwd = alfanumericoAleatorio(8);
        var mail = "noreply@suporteaopaciente.com.br";
        User user = new User();

        if (forgotPasswordDoctorModel is null) return false;
        switch (forgotPasswordDoctorModel.Code)
        {
            case ("995"):
                mail = "operacao@lilly.com.br";
                break;
            case ("049"):
                mail = "noreply@suporteaopaciente.com.br";
                break;
        }
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == forgotPasswordDoctorModel.Code).Id;
        var doctor = _doctorByProgramRepository.GetValue(d => d.EmailAddress1 == forgotPasswordDoctorModel.email
                                                         && d.HealthProgramId == healthProgramId
                                                         && d.IsDeleted == false);
        if (doctor is not null)
        {
            user = _userRepository.GetValue(u => u.Id == doctor.SystemUserId && u.IsDeleted == false);
        }
        else if (doctor is null)
        {
            var patient = _patientRepository.GetValue(p => p.EmailAddress1 == forgotPasswordDoctorModel.email && p.HealthProgramId == healthProgramId);
            if (patient is not null)
            {
                user = _userRepository.GetValue(u => u.Id == patient.SystemUserId && u.IsDeleted == false);
            }
            else if (patient is null)
            {
                user = _userRepository.GetValue(u => u.Email == forgotPasswordDoctorModel.email && u.IsDeleted == false);
            }
        }


        if (user is null)
            return false;

        bool isPasswordChanged = ChangePassword(user, standardPwd, forgotPasswordDoctorModel.Code, true);

        if (isPasswordChanged)
        {
            Dictionary<string, string> bodyReplace = new Dictionary<string, string>
            {
                { "[senha]", standardPwd },
                { "[nome]", user.Name }
            };

            Email _email = _emailService.MergeTemplateMail<User>(User.EntityName, User.EntityTypeCode, "#RECOVERYPASSWORD", user.Id, healthProgramId, false, forgotPasswordDoctorModel.email, true, true, bodyReplace);

            if (_email == null)
            {
                return false;
            }
        }

        return true;
    }

    public ReturnMessage<string> ForgotPassword(UserForgotPassword model)
    {
        var result = new ReturnMessage<string>();

        try
        {
            string token = string.Empty;
            var tokenPayload = _tokenService.GenerateShortToken();
            if (tokenPayload.IsValidData)
                token = tokenPayload.Value;
            else
                throw new InvalidOperationException("Token não foi gerado.");

            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == model.ProgramCode).Id;
            var userId = _userRepository.GetUserByEmail(model.UserEmail, model.ProgramCode).Id;
            var templateName = _templateRepository.GetValue(t => t.HealthProgramId == healthProgramId && t.Name == model.TemplateName).Name;

            var bodyReplace = new Dictionary<string, string>
            {
                { "[token]", token }
            };

            _emailService.MergeTemplateMail<User>(User.EntityName, User.EntityTypeCode, templateName, userId, healthProgramId, true, model.UserEmail, true, true, bodyReplace);
        }
        catch (Exception ex)
        {
            result.Value = "Token não foi gerado.";
            result.IsValidData = false;
            result.AdditionalMessage = "500";
            return result;
        }

        result.Value = "Token enviado por e-mail.";
        result.IsValidData = true;
        result.AdditionalMessage = "200";

        return result;
    }

    public string SendNewTokenForUser(Guid userId, string helthProgramCode)
    {
        string mail;
        switch (helthProgramCode)
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

        try
        {
            Random random = new Random();
            int token = random.Next(1000, 9999);
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == helthProgramCode).Id;

            Email _email = _emailService.MergeTemplateMail<User>(User.EntityName, User.EntityTypeCode, "#TWOSTEPLOGIN", userId, healthProgramId, false, mail, true, true);

            var bodyReplace = _email.Body;
            bodyReplace = bodyReplace.Replace("[token]", token.ToString());

            _emailRepository.Insert(_email);

            if (_email is not null)
            {
                return token.ToString();
            }
        }
        catch (Exception ex)
        { }

        return "";
    }

    public bool RegisterLogin(UserAuthModel authModel, bool success, Guid? userId = null)
    {
        var healthProgram = _healthProgramRepository.GetValue(_ => _.Code == authModel.HealthProgramCode);

        if (authModel is not null)
        {
            if (success)
            {
                var userLog = new UserSystemLog()
                {
                    Id = Guid.NewGuid(),
                    ActionName = "[LOGIN_SUCCESSFUL]",
                    UserId = userId,
                    HealthProgramId = healthProgram.Id,
                    StartDate = DateTime.Now
                };

                _userSystemLogRepository.Insert(userLog);
            }
            else
            {
                var userLog = new UserSystemLog()
                {
                    Id = Guid.NewGuid(),
                    ActionName = "[LOGIN_FAIL]",
                    ActionKey = authModel.Email,
                    UserId = userId,
                    HealthProgramId = healthProgram.Id,
                    StartDate = DateTime.Now
                };

                _userSystemLogRepository.Insert(userLog);
            }

            return true;
        }

        return false;
    }

    public async Task<PaginationResult<List<UserHistoryModel>>> GetUserHistory(UserHistoryFilterModel model, string programcode)
    {
        PaginationResult<List<UserHistoryModel>> result = new PaginationResult<List<UserHistoryModel>>();
        List<UserHistoryModel> userHistoryModels = new List<UserHistoryModel>();
        List<User> userAux = new List<User>();

        var healthProgram = _healthProgramRepository.GetValue(_ => _.Code == programcode);


        var userHistories = _userSystemLogRepository.Find(_ => _.HealthProgramId == healthProgram.Id
                                                            && _.ActionName.Contains("LOGIN")).ToList();

        if (userHistories is not null)
        {
            foreach (var history in userHistories)
            {
                User userTemp = new User();
                if (userAux.Any(_ => _.Id == history.UserId))
                    userTemp = userAux.FirstOrDefault(_ => _.Id == history.UserId);
                else
                {
                    userTemp = _userRepository.GetValue(_ => _.Id == history.UserId);

                    if (userTemp is not null)
                        userAux.Add(userTemp);
                }

                var userHistory = new UserHistoryModel()
                {
                    Id = userTemp is not null ? userTemp.Id : Guid.Empty,
                    Date = history.StartDate.Value,
                    Email = userTemp is not null ? userTemp.Email : history.ActionKey,
                    Name = userTemp is not null ? userTemp.Name : string.Empty
                };

                userHistory.Action = userHistory.GetAction(history.ActionName);

                userHistoryModels.Add(userHistory);

            }
        }

        var userHistoryFiltered = FilterUserHistory(model, userHistoryModels);

        return new PaginationResult<List<UserHistoryModel>>
        {
            TotalSize = VerifyHasFilter(model) ? userHistoryFiltered.Count : userHistoryModels.Count,
            Data = userHistoryFiltered
        };
    }

    public List<UserHistoryModel> FilterUserHistory(UserHistoryFilterModel model, List<UserHistoryModel> userHistories)
    {

        var skip = (model.Page - 1) * model.PageSize;

        if (model.StartDate.HasValue)
            userHistories = userHistories.Where(_ => _.Date.Date >= model.StartDate.Value.Date).ToList();
        if (model.EndDate.HasValue)
            userHistories = userHistories.Where(_ => _.Date.Date <= model.EndDate.Value.Date).ToList();

        userHistories = userHistories.OrderByDescending(_ => _.Date).Skip(skip).Take(model.PageSize).ToList();

        return userHistories;
    }

    public bool VerifyHasFilter(UserHistoryFilterModel model)
    {
        if (model.EndDate.HasValue)
            return true;
        else if (model.StartDate.HasValue)
            return true;

        return false;
    }

    public Task<bool> SaveUserAcceptances(Guid userId, bool acceptDataSharing, bool acceptContact)
    {
        throw new NotImplementedException();
    }

    public bool ForgorPasswordbyUser(ForgotPasswordbyUserModel forgotPasswordbyUserModel)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var standardPwd = new String(stringChars);
        string mail;
        if (forgotPasswordbyUserModel is null)
            return false;

        User user = _userRepository.GetValue(u => u.UserName == forgotPasswordbyUserModel.login && u.IsDeleted == false);

        if (user is null)
            return false;

        if (string.IsNullOrEmpty(user.Name))
            return false;

        switch (forgotPasswordbyUserModel.healthProgramCode)
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

        bool isPasswordChanged = ChangePassword(user, standardPwd, forgotPasswordbyUserModel.healthProgramCode, true);

        if (isPasswordChanged)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == forgotPasswordbyUserModel.healthProgramCode).Id;
            Email _email = _emailService.MergeTemplateMail<User>(User.EntityName, User.EntityTypeCode, "#RECOVERYPASSWORD", user.Id, healthProgramId, false, mail, true, true);
            var bodyReplace = _email.Body;
            bodyReplace = bodyReplace.Replace("[senha]", standardPwd);

            _email.Body = bodyReplace;

            _emailRepository.Insert(_email);

            if (_email == null)
            {
                return false;
            }
        }

        return true;
    }

    public bool PostUserLogin(PutUserModel putUserModel)
    {
        User user = _userRepository.GetValue(u => u.UserName == putUserModel.User && u.IsDeleted == false);

        if (user is null)
            return false;

        if (string.IsNullOrEmpty(user.Email))
            return false;

        user.UserName = putUserModel.newUser;
        var userFound = _userRepository.Update(user);

        return true;
    }

    public bool PostUserName(PostUsernameName postUsernameName)
    {
        User user = _userRepository.GetValue(u => u.UserName == postUsernameName.Name && u.IsDeleted == false);

        if (user is null)
            return false;

        if (string.IsNullOrEmpty(user.Email))
            return false;

        user.UserName = postUsernameName.newName;
        var userFound = _userRepository.Update(user);

        return true;
    }

    public List<Api.Models.HealthProgram> GetHealthProgramById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Guid GetIdByEmail(string email)
    {
        Guid Id = _userRepository.Find(u => u.Email == email).FirstOrDefault().Id;

        return Id;
    }

    public int GetCountAmountofAccesses(string email)
    {
        throw new NotImplementedException();
    }

    public List<Api.Models.HealthProgram> GetHealthProgramById(string email)
    {
        throw new NotImplementedException();
    }

    public bool GetIsFirstAccess(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasAcceptedTerms(Guid userId)
    {
        throw new NotImplementedException();
    }

    public (List<PoliciesResult> policiesResult, bool isValid) Validate(string password)
    {
        List<PoliciesResult> policiesResult = new List<PoliciesResult>();
        bool isValid = false;


        if (password.Contains("123mudar") || password.Contains("123Mudar") || password.Contains("123MUDAR"))
        {
            policiesResult.Add(new PoliciesResult { message = "A senha não pode conter 123mudar", isValid = false });
            isValid = false;
            return (policiesResult, isValid);
        }

        string password123Mudar = password.ToUpper();

        if (password123Mudar.Contains("123MUDAR"))
        {
            policiesResult.Add(new PoliciesResult { message = "A senha não pode conter 123mudar", isValid = false });
            isValid = false;
            return (policiesResult, isValid);
        }

        if (password.Length < 8)
        {
            policiesResult.Add(new PoliciesResult { message = "Mínimo de 8 carácteres", isValid = false });
        }
        else
        {
            policiesResult.Add(new PoliciesResult { message = "Mínimo de 8 carácteres", isValid = true });
        }

        if (password.Length > 12)
        {
            policiesResult.Add(new PoliciesResult { message = "Máximo de 12 carácteres", isValid = false });
        }
        else
        {
            policiesResult.Add(new PoliciesResult { message = "Máximo de 12 carácteres", isValid = true });
        }

        // Verificar se a senha contém pelo menos uma letra maiúscula
        if (!Regex.IsMatch(password, "[A-Z]"))
        {
            policiesResult.Add(new PoliciesResult { message = "Ter no mínimo 1 letra maiúscula", isValid = false });
        }
        else
        {
            policiesResult.Add(new PoliciesResult { message = "Ter no mínimo 1 letra maiúscula", isValid = true });
        }

        // Verificar se a senha contém pelo menos uma letra minúscula
        if (!Regex.IsMatch(password, "[a-z]"))
        {
            policiesResult.Add(new PoliciesResult { message = "Ter no mínimo 1 letra minúscula", isValid = false });
        }
        else
        {
            policiesResult.Add(new PoliciesResult { message = "Ter no mínimo 1 letra minúscula", isValid = true });
        }

        // Verificar se a senha contém pelo menos um número
        if (!Regex.IsMatch(password, "[0-9]"))
        {
            policiesResult.Add(new PoliciesResult { message = "Ter no mínimo 1 número", isValid = false });
        }
        else
        {
            policiesResult.Add(new PoliciesResult { message = "Ter no mínimo 1 número", isValid = true });
        }

        // Verificar se a senha contém pelo menos um caractere especial
        if (!Regex.IsMatch(password, "[!@#$%^&*(),.?\":{}|<>]"))
        {
            policiesResult.Add(new PoliciesResult { message = "Ter no mínimo 1 carácter especial (!@#$%&)", isValid = false });
        }
        else
        {
            policiesResult.Add(new PoliciesResult { message = "Ter no mínimo 1 carácter especial (!@#$%&)", isValid = true });
        }

        if (policiesResult.Where(p => p.isValid == false).Any())
        {
            isValid = false;
        }
        else
        {
            isValid = true;
        }

        return (policiesResult, isValid);
    }

    public Task<bool> GetProgramsByUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public bool RegisterLoginByProgram(UserAuthByProgramModel userModel, bool sucess, Guid? userId = null)
    {
        throw new NotImplementedException();
    }

    List<DoctorProgram> IUserService.GetProgramsByUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public virtual Task<ReturnMessage<string>> ForgotPassword(ForgotPasswordModel model)
    {
        throw new NotImplementedException();
    }
    
    public User GetUserByLogin(UserAuthModel userAuthModel)
    {
        string password = _cryptographyService.Encrypt(userAuthModel.Password);
        return _userRepository.GetUserByLogin(userAuthModel.Login, password);
    }

    List<DoctorProgram> IUserService.GetProfileByHealthProfessional(Guid userId)
    {
        throw new NotImplementedException();
    }
}
