using Care.Api.Business.Interfaces;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Care.Api.Security;
using Care.Api.Business.Interfaces.Sanofi;
using Care.Api.Business.Models;

namespace Care.Api.Business.Services;

public class LoginService : ILoginService
{
    protected readonly ICryptographyService? _cryptographyService;
    protected readonly IUserRepository? _userRepository;
    protected readonly ITokenService? _tokenService;
    protected readonly IHttpContextAccessor? _httpContext;
    protected readonly IHealthProgramRepository? _healthProgramRepository;
    protected readonly IEmailService? _emailService;
    protected readonly IConfiguration? _configuration;
    protected readonly IUserSanofiService? _userSanofiService;
    protected readonly IDoctorSanofiService? _doctorSanofiService;
    protected readonly ITreatmentRepository? _treatmentRepository;
    protected readonly IDiagnosticRepository? _diagnosticRepository;
    protected readonly IPatientRepository? _patientRepository;

    public LoginService(
        ICryptographyService cryptographyService,
        IUserRepository userRepository,
        ITokenService tokenService,
        IHttpContextAccessor httpContext,
        IHealthProgramRepository healthProgramRepository,
        IEmailService emailService,
        IConfiguration configuration,
        IUserSanofiService userSanofiService,
        IDoctorSanofiService doctorSanofiService,
        ITreatmentRepository treatmentRepository,
        IDiagnosticRepository diagnosticRepository,
        IPatientRepository patientRepository
        )
    {
        _cryptographyService = cryptographyService;
        _userRepository = userRepository;
        _tokenService = tokenService;
        _httpContext = httpContext;
        _healthProgramRepository = healthProgramRepository;
        _emailService = emailService;
        _configuration = configuration;
        _userSanofiService = userSanofiService;
        _doctorSanofiService = doctorSanofiService;
        _treatmentRepository = treatmentRepository;
        _diagnosticRepository = diagnosticRepository;
        _patientRepository = patientRepository;
    }

    public async Task<ReturnMessage<User>> LoginAsync(string email, string password, string helthProgramCode)
    {
        switch (helthProgramCode)
        {
            default:
                return await LoginAsyncGeneric(email, password, helthProgramCode);
                break;
        }
    }

    public async Task<ReturnMessage<User>> LoginAsyncGeneric(string email, string password, string helthProgramCode)
    {
        ReturnMessage<User> returnMessage = new ReturnMessage<User>();
        User user = _userRepository!.GetUser(email, _cryptographyService!.Encrypt(password), helthProgramCode);

        if (user is null)
        {
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = "Usuário não localizado.";

            return returnMessage;
        }

        if (string.IsNullOrEmpty(user?.Email) || string.IsNullOrEmpty(user?.UserName))
        {
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = "Usuário não localizado.";

            return returnMessage;
        }

        if (user.AccessProfiles.Count == 0)
        {
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = "Usuário sem perfil para o programa.";

            return returnMessage;
        }

        if(user.StatusCodeStringMapId == Guid.Parse("A0767247-633C-4C75-87F7-F16AA47B46FB")){
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = "Este cadastro está inativo.";

            return returnMessage;
        }

        List<Claim> roles = new List<Claim>();
        StringBuilder profilesInLine = new StringBuilder();


        if (user?.AccessProfiles is not null)
        {
            foreach (var profile in user.AccessProfiles)
            {
                if (!string.IsNullOrEmpty(profile.Name))
                {
                    roles.Add(new Claim(ClaimTypes.Role, profile.Name));
                    profilesInLine.Append(profile.Name + ";");
                }
            }
        }

        try
        {
            var tokenResult = _tokenService!.GenerateToken(email, user?.UserName!, user?.Id, roles);

            if (tokenResult is null)
            {
                returnMessage.Value = null;
                returnMessage.IsValidData = false;
                returnMessage.AdditionalMessage = "Internal Server Error";

                return returnMessage;
            }

            if (tokenResult.IsValidData == false)
            {
                returnMessage.Value = null;
                returnMessage.IsValidData = false;
                returnMessage.AdditionalMessage = tokenResult.AdditionalMessage;

                return returnMessage;
            }

            bool authenticationJwtActive = false;

            try
            {
                authenticationJwtActive = Convert.ToBoolean(_configuration["Jwt:AuthenticationJwtActive"]);
            }
            catch (Exception ex) { }

            if (!authenticationJwtActive)
            {
                var schema = CookieAuthenticationDefaults.AuthenticationScheme;
                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,  user!.UserName),
                        new Claim(ClaimTypes.Email, user!.Email is null ? "" : user.Email),
                        //new Claim(ClaimTypes.Role, ""),
                        new Claim(ClaimTypes.Authentication, tokenResult.Value!),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()!)
                    };

                claims.AddRange(roles);

                var identity = new ClaimsIdentity(claims, schema);
                var claimPrincipal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync(schema, claimPrincipal);

                if (_httpContext!.HttpContext is not null)
                {
                    await _httpContext.HttpContext.SignInAsync(schema, claimPrincipal);

                    var session_id = _httpContext.HttpContext.Session.Id;
                    //var cookie = new CookieHeaderValue("session", session.ToString());
                    returnMessage.AdditionalMessage = session_id;
                }
            }
            else
            {
                returnMessage.AdditionalMessage = tokenResult.Value;
            }

            returnMessage.Value = user;
            returnMessage.IsValidData = true;

        }
        catch (Exception ex)
        {
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = ex.Message;
        }

        return returnMessage;
    }

    public Task<ReturnMessage<ResponseLogin>> LoginByProgram(string email, string password, string helthProgramCode)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnMessage<ResponseLogin>> LoginByProgram(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<ReturnMessage<User>> LoginInTwoStepsAsync(string email, string password, string helthProgramCode, string tokenDigits = "")
    {
        ReturnMessage<User> returnMessage = new ReturnMessage<User>();
        User user = _userRepository!.GetUser(email, _cryptographyService!.Encrypt(password), helthProgramCode);

        if (user is null)
        {
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = "Usuário não localizado.";

            return returnMessage;
        }

        if (string.IsNullOrEmpty(user?.Email) || string.IsNullOrEmpty(user?.UserName))
        {
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = "Usuário não localizado.";

            return returnMessage;
        }
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
            if (string.IsNullOrEmpty(tokenDigits))
            {
                Random random = new Random();
                int token = random.Next(1000, 9999);
                var healthProgramId = _healthProgramRepository!.GetValue(_ => _.Code == helthProgramCode).Id;

                Dictionary<string, string> bodyReplace = new Dictionary<string, string>();
                bodyReplace.Add("[token]", token.ToString());

                Email _email = _emailService!.MergeTemplateMail<User>(User.EntityName, User.EntityTypeCode, "#TWOSTEPLOGIN", user.Id, healthProgramId, true, mail, true, true, bodyReplace);
                if (_email is not null)
                {
                    returnMessage.Value = user;
                    returnMessage.IsValidData = true;
                    returnMessage.AdditionalMessage = token.ToString();
                    //_httpContext!.HttpContext!.Session.SetString(user.Id.ToString(), token.ToString());
                    user.InternalControl = $"{token}|{DateTime.Now}";
                    _userRepository.Update(user);
                }
            }
            else
            {
                //string? token = _httpContext!.HttpContext!.Session.GetString(user.Id.ToString());

                //if (string.IsNullOrEmpty(token))
                //{
                //    returnMessage.Value = null;
                //    returnMessage.IsValidData = false;
                //    returnMessage.AdditionalMessage = "Erro interno. Token não recuperado.";
                //}
                //else
                //{
                //    if (tokenDigits == token)
                //    {
                //        return await LoginAsync(email, password, helthProgramCode);
                //    }

                //    returnMessage.Value = null;
                //    returnMessage.IsValidData = false;
                //    returnMessage.AdditionalMessage = "Token não conferem.";
                //}

                if (string.IsNullOrEmpty(user.InternalControl))
                {
                    returnMessage.Value = null;
                    returnMessage.IsValidData = false;
                    returnMessage.AdditionalMessage = "Erro interno. Token não recuperado.";
                }
                else
                {
                    var tokenInformation = user.InternalControl.Split('|');
                    string? token = tokenInformation[0];
                    DateTime tokenTime = DateTime.Parse(tokenInformation[1]);

                    double tokenExpiresInMin = _configuration["Jwt:TokenExpireInMin"] is null ? 5 : Convert.ToDouble(_configuration["Jwt:TokenExpireInMin"]);

                    if (tokenTime.CompareTo(DateTime.Now.AddMinutes(tokenExpiresInMin)) > 0)
                    {
                        user.InternalControl = null;
                        _userRepository.Update(user);

                        returnMessage.Value = null;
                        returnMessage.IsValidData = false;
                        returnMessage.AdditionalMessage = "Token Expirado.";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(token))
                        {
                            returnMessage.Value = null;
                            returnMessage.IsValidData = false;
                            returnMessage.AdditionalMessage = "Erro interno. Token não recuperado.";
                        }
                        else
                        {
                            if (tokenDigits == token)
                            {
                                user.InternalControl = null;
                                _userRepository.Update(user);

                                return await LoginAsync(email, password, helthProgramCode);
                            }

                            returnMessage.Value = null;
                            returnMessage.IsValidData = false;
                            returnMessage.AdditionalMessage = "Token não conferem.";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = ex.Message;
        }

        return returnMessage;
    }

    public async Task<ReturnMessage<string>> Logoff()
    {
        ReturnMessage<string> returnMessage = new ReturnMessage<string>();
        try
        {
            //await HttpContext.SignOutAsync();
            if (_httpContext.HttpContext is not null)
            {
                await _httpContext.HttpContext.SignOutAsync();
                //foreach (var cookie in Request.Cookies.Keys)
                //{
                //    Response.Cookies.Delete(cookie);
                //}
                foreach (var cookie in _httpContext.HttpContext.Request.Cookies.Keys)
                {
                    _httpContext.HttpContext.Response.Cookies.Delete(cookie);
                }

                returnMessage.Value = "Logoff";
                returnMessage.IsValidData = true;
                returnMessage.AdditionalMessage = "Logoff com sucesso.";
            }
            else
            {
                returnMessage.Value = null;
                returnMessage.IsValidData = false;
                returnMessage.AdditionalMessage = "Internal Server Error";
            }
        }
        catch (Exception ex)
        {
            returnMessage.Value = null;
            returnMessage.IsValidData = false;
            returnMessage.AdditionalMessage = ex.Message;
        }

        return returnMessage;
    }

    public virtual async Task<bool> VerifyTypePatient(Guid? userId)
    {
        throw new NotImplementedException();
    }
}
