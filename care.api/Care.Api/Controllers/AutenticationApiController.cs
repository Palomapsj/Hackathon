using Azure.Core;
using Care.Api.Business.Enums;
using Care.Api.Business.Interfaces;
using Care.Api.Business.Interfaces.Sanofi;
using Care.Api.Business.Models;
using Care.Api.Business.Models.Messages.Response;
using Care.Api.Business.Services;
using Care.Api.Business.Services.HealthProgram.EmFrente;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Factory;
using Care.Api.Factory.Azi;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.Security.Claims;
using System.Text;
using System.Xml.Serialization;

namespace Care.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = false)]
[Route("[controller]")]
[ApiController]
public class AutenticationApiController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILoginService _loginService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IDoctorByProgramRepository _doctorByProgramRepository;

    public AutenticationApiController(
        IConfiguration configuration,
        ILoginService loginService,
        IServiceProvider serviceProvider,
        IDoctorByProgramRepository doctorByProgramRepository
        )
    {
        _configuration = configuration;
        _loginService = loginService;
        _serviceProvider = serviceProvider;
        _doctorByProgramRepository = doctorByProgramRepository;
    }

    [AllowAnonymous]
    [HttpPost("/validateregistertoken")]
    public IActionResult ValidateRegisterToken(SmsTokenValidationModel smsTokenValidationModel)
    {
        ReturnMessage<string> result = new ReturnMessage<string>();
        switch (smsTokenValidationModel.ProgramCode)
        {
            case "951":
            case "073":
            case "003":
            case "1002":
                result = _tokenService.ValidateRegisterTokenSms(smsTokenValidationModel);
                break;
            default:
                result.Value = "200";
                result.IsValidData = true;
                result.AdditionalMessage = string.Empty;
                break;
        }
        return StatusCode(int.Parse(result.AdditionalMessage), new { status = result.AdditionalMessage, isValidaData = result.IsValidData, value = result.Value });
    }

    [AllowAnonymous]
    [HttpPost("/validate/email/token")]
    public IActionResult ValidateRegisterTokenEmail(EmailTokenValidationModel emailTokenValidationModel)
    {
        ReturnMessage<string> result = new ReturnMessage<string>();
        switch (emailTokenValidationModel.ProgramCode)
        {
            case "1002":
                result = _tokenService.ValidateRegisterTokenEmail(emailTokenValidationModel);
                break;
            default:
                result.Value = "200";
                result.IsValidData = true;
                result.AdditionalMessage = string.Empty;
                break;
        }
        return StatusCode(int.Parse(result.AdditionalMessage), new { status = result.AdditionalMessage, isValidaData = result.IsValidData, value = result.Value });
    }

    [AllowAnonymous]
    [HttpPost("/validatechangepasswordtoken")]
    public IActionResult ValidateChangePasswordToken(EmailTokenValidationModel emailTokenValidationModel)
    {
        var result = new ReturnMessage<string>();
        switch (emailTokenValidationModel.ProgramCode)
        {
            case "073":
                result = _tokenService.ValidateChangePasswordTokenEmail(emailTokenValidationModel);
                break;
            default:
                result.Value = "200";
                result.IsValidData = true;
                result.AdditionalMessage = string.Empty;
                break;
        }

        return StatusCode(int.Parse(result.AdditionalMessage), new { status = result.AdditionalMessage, isValidaData = result.IsValidData, value = result.Value });
    }


    [AllowAnonymous]
    [HttpPost("/token/sms")]
    public IActionResult SendTokenSms(SmsTokenValidationModel smsTokenValidationModel)
    {
        ReturnMessage<string> result = new ReturnMessage<string>();
        switch (smsTokenValidationModel.ProgramCode)
        {
            case "951":
            case "1002":
                result = _tokenService.RegisterSmsToBeSend(smsTokenValidationModel, smsTokenValidationModel.ProgramCode);
                break;
            default:
                result.Value = "200";
                result.IsValidData = true;
                result.AdditionalMessage = string.Empty;
                break;
        }
        return StatusCode(int.Parse(result.AdditionalMessage), new { status = result.AdditionalMessage, isValidaData = result.IsValidData, value = result.Value });
    }

    [AllowAnonymous]
    [HttpPost("/token")]
    public IActionResult TokenRequest(UserAuthModel userAuthModel)
    {
        if (userAuthModel == null)
        {
            //return Results.BadRequest();
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        User user = _userService.GetUser(userAuthModel);

        if (user != null)
        {
            if (user.Email is not null)
            {
                string? key = _configuration["Jwt:Key"] is null ? "" : _configuration["Jwt:Key"];
                string? issuer = _configuration["Jwt:Issuer"] is null ? "" : _configuration["Jwt:Issuer"];
                string? audience = _configuration["Jwt:Audience"] is null ? "" : _configuration["Jwt:Audience"];

                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(issuer) && !string.IsNullOrEmpty(audience))
                {
                    var tokenString = _tokenService.GetToken(key, issuer, audience, userAuthModel);
                    return StatusCode(StatusCodes.Status200OK, new { logged = true, user.UserName, user.Email, token = tokenString, message = "Usuário autenticado" });
                    //return Results.Ok(new { logged = true, user.UserName, user.Email, token = tokenString, message = "Usuário autenticado" });
                }
            }

            return StatusCode(StatusCodes.Status404NotFound, new { logged = false, user.UserName, user.Email, token = "", message = "Internal Server Error" });
            //return Results.NoContent();
        }

        return StatusCode(StatusCodes.Status404NotFound, new { logged = false, UserName = "", userAuthModel.Email, token = "", message = "Login Inválido" });
        //return Results.NotFound(new { logged = false, UserName = "", userAuthModel.Email, token = "", message = "Login Inválido" });
    }

    [AllowAnonymous]
    [HttpPost("/login")]
    public async Task<IActionResult> Login(UserAuthModel userAuthModel)
    {
        if (userAuthModel == null)
            return StatusCode(StatusCodes.Status400BadRequest, "Login Inválido");

        if (string.IsNullOrEmpty(userAuthModel.Email) || string.IsNullOrEmpty(userAuthModel.Password) || string.IsNullOrEmpty(userAuthModel.HealthProgramCode))
            return StatusCode(StatusCodes.Status400BadRequest, "Login Inválido");

        var result = await LoginFactory.GetInstance(_serviceProvider, userAuthModel.HealthProgramCode).LoginAsync(userAuthModel.Email, userAuthModel.Password, userAuthModel.HealthProgramCode);

        if (result.IsValidData == false)
            return StatusCode(StatusCodes.Status404NotFound, result.AdditionalMessage);

        var profilesInLine = new StringBuilder();
        foreach (var profile in result.Value!.AccessProfiles)
            profilesInLine.Append(profile.Name);

        bool typePatient = false;

        if (userAuthModel.HealthProgramCode == "004" && profilesInLine.ToString() == "Paciente")
        {
            typePatient = await LoginFactory.GetInstance(_serviceProvider, userAuthModel.HealthProgramCode).VerifyTypePatient(result.Value.Id);
        }


        return StatusCode(
            StatusCodes.Status200OK,
            new
            {
                logged = true,
                UserName = result.Value.Name,
                Name = result.Value.UserName,
                Email = result.Value.Email,
                role = profilesInLine.ToString(),
                token = result.AdditionalMessage,
                message = "Usuário autenticado",
                ObrigatorioAlterarSenha = result.Value.InternalControl is null ? false : result.Value.InternalControl!.Contains("FORCE_CHANGE_PWD"),
                FirstLogin = result.Value.ImportCode == "0",
                TypePatient = typePatient,
                Id = result.Value.Id,
                Telephone = result.Value.Telephone
            });
    }

    [AllowAnonymous]
    [HttpPost("/loginAzi")]
    public async Task<IActionResult> LoginAzi(UserAuthModel userAuthModel)
    {
        if (userAuthModel == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Login Inválido");
            //return Results.BadRequest();
        }

        if (string.IsNullOrEmpty(userAuthModel.Email) || string.IsNullOrEmpty(userAuthModel.Password) || userAuthModel.HealthPrograms.Count() == 0)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Login Inválido");
        }

        var healthProgramCode = userAuthModel.HealthProgramCode != null ? userAuthModel.HealthProgramCode : "";

        ReturnMessage<MessageUserResponse<UserResponse>> result = new();
        foreach (var program in userAuthModel.HealthPrograms)
        {
            result = await LoginAziFactory.GetInstance(_serviceProvider, program).LoginAsync(userAuthModel.Email, userAuthModel.Password, program);

            healthProgramCode = program;
            if (result.Value != null)
                break;

        }

        if (result.IsValidData == false)
        {
            return StatusCode(StatusCodes.Status404NotFound, result.AdditionalMessage);
        }

        StringBuilder profilesInLine = new StringBuilder();

        ApplicationUser user = new ApplicationUser();

        user.Code = result.Value.User.Code;

        foreach (var profile in result.Value.User!.AccessProfiles)
        {
            if (profile.Name == "DOCTOR")
            {
                user.UserType = Enums.UserType.Doctor;
            }

            if (profile.Name.Contains("ADMIN"))
            {
                user.UserType = Enums.UserType.Master;
            }

            if (profile.Name == "SUPERVISOR-SOMOS RAROS VACINAS")
            {
                user.UserType = Enums.UserType.Master;
            }

            if (profile.Name.Contains("SUPERVISOR"))
            {
                user.UserType = Enums.UserType.Supervisor;
            }

            if (profile.Name.Contains("CLIENT"))
            {
                user.UserType = Enums.UserType.Client;
            }
        }

        user.ProgramCode = int.Parse(healthProgramCode);
        user.ProgramId = result.Value.User.ProgramId;
        user.Email = result.Value.User.Email;

        var validatePass = _userService.Validate(userAuthModel.Password);
        user.FirstAccess = validatePass.isValid == false ? 1 : 0;

        if (result.Value.User.InternalControl != null && validatePass.isValid == true)
        {
            user.FirstAccess = result.Value.User.InternalControl!.Contains("FORCE_CHANGE_PWD") ? 1 : 0;
        }

        DateTime dtCreation = DateTime.Now;
        DateTime dtExpiration = dtCreation + TimeSpan.FromMinutes(480);
        var resultReturn = new Care.Api.Business.Models.TokenAzi<ApplicationUser>()
        {
            Created = dtCreation.ToString("yyyy-MM-dd HH:mm:ss"),
            Expiration = dtExpiration.ToString("yyyy-MM-dd HH:mm:ss"),
            AccessToken = result.AdditionalMessage,
            RefreshToken = Guid.NewGuid().ToString().Replace("-", string.Empty),
            Message = "OK",
            User = user
        };

        return StatusCode(StatusCodes.Status200OK, new { resultReturn });
    }


    [AllowAnonymous]
    [HttpPost("/logintwosteps")]
    public async Task<IActionResult> LoginInTwoStepsAsync(UserAuthTwoStepsModel userAuthTwoStepsModel)
    {
        if (userAuthTwoStepsModel == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Login Inválido");
            //return Results.BadRequest();
        }

        if (string.IsNullOrEmpty(userAuthTwoStepsModel.Email) || string.IsNullOrEmpty(userAuthTwoStepsModel.Password) || string.IsNullOrEmpty(userAuthTwoStepsModel.HealthProgramCode))
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Login Inválido");
        }

        var result = await _loginService.LoginInTwoStepsAsync(userAuthTwoStepsModel.Email, userAuthTwoStepsModel.Password, userAuthTwoStepsModel.HealthProgramCode, userAuthTwoStepsModel.token!);

        if (result.IsValidData == false)
        {
            return StatusCode(StatusCodes.Status404NotFound, result.AdditionalMessage);
        }

        bool bLogged = false;
        StringBuilder profilesInLine = new StringBuilder();

        if (!string.IsNullOrEmpty(userAuthTwoStepsModel.token))
        {
            bLogged = true;

            foreach (var profile in result.Value!.AccessProfiles)
                profilesInLine.Append(profile.Name);
        }

        if (result.Value.InternalControl is null)
            result.Value.InternalControl = string.Empty;

        //return StatusCode(StatusCodes.Status200OK, new { logged = bLogged, result.Value!.UserName, result.Value.Email, perfis = profilesInLine.ToString(), token = result.AdditionalMessage, message = $"Usuário Autenticado = {bLogged}", ObrigatorioAlterarSenha = result.Value.InternalControl!.Contains("FORCE_CHANGE_PWD") });

        return StatusCode(StatusCodes.Status200OK, new { logged = true, Name = result.Value.UserName, result.Value.Email, role = profilesInLine.ToString(), token = result.AdditionalMessage, message = "Usuário autenticado", ObrigatorioAlterarSenha = result.Value.InternalControl is null ? false : result.Value.InternalControl!.Contains("FORCE_CHANGE_PWD") });
    }

    [Authorize]
    [HttpPost("/logoff")]
    public async Task<IActionResult> LogoffRequest()
    {
        var result = await _loginService.Logoff();
        if (result.IsValidData)
        {
            return StatusCode(StatusCodes.Status200OK, result.Value);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [Authorize]
    [HttpPost("/changepassword")]
    public IActionResult ChangePassword(PasswordModel passwordModel)
    {
        if (passwordModel == null)
            return StatusCode(StatusCodes.Status400BadRequest);

        var accessToken = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var validatePass = _userService.Validate(passwordModel.NewPassword);

        if (validatePass.isValid == false)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Senhas não seguem o padrão necessário!");
        }

        string username = passwordModel.Email is null ? "" : passwordModel.Email;
        string oldPassword = passwordModel.OldPassword is null ? "" : passwordModel.OldPassword;
        string newPassword = passwordModel.NewPassword is null ? "" : passwordModel.NewPassword;
        string confirmPassword = passwordModel.ConfirmPassword is null ? "" : passwordModel.ConfirmPassword;

        if (newPassword != confirmPassword)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Senhas não conferem!");
        }

        UserAuthModel userAuthModel = new UserAuthModel
        {
            Email = username,
            Password = oldPassword,
            HealthProgramCode = passwordModel.Programcode
        };

        User user = _userService.GetUser(userAuthModel);

        if (user == null || user.Id == Guid.Empty)
            return StatusCode(StatusCodes.Status400BadRequest, "Usuário e/ou senha inválidos!");


        var resultUserPasswordHistory = UserPasswordHistoryFactory.GetInstance(_serviceProvider, passwordModel.Programcode).CheckPasswordMatchTheLastTen(user, passwordModel.Programcode, newPassword);

        if (resultUserPasswordHistory.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, resultUserPasswordHistory.Message);
        }


        bool result = UserFactory.GetInstance(_serviceProvider, passwordModel.Programcode).ChangePassword(user, newPassword, passwordModel.Programcode, false, accessToken);

        return result ? StatusCode(StatusCodes.Status200OK, "Senha alterada com sucesso.") : StatusCode(StatusCodes.Status500InternalServerError, "Erro na alteração da senha.");


    }

    [Authorize]
    [HttpPost("/changepersonalizedpassword")]
    public IActionResult ChangePersonalizedPassword(PasswordPersonalizedModel passwordModel)
    {
        if (passwordModel == null)
        {
            //return Results.BadRequest();
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        string username = string.Empty;

        if (passwordModel.Email != passwordModel.OldEmail)
        {
            username = passwordModel.OldEmail is null ? "" : passwordModel.OldEmail;
        }
        else
        {
            username = passwordModel.Email is null ? "" : passwordModel.Email;
        }

        if (passwordModel.Email == null || passwordModel.Email == "")
        {
            passwordModel.Email = passwordModel.OldEmail;
        }

        string oldPassword = passwordModel.OldPassword is null ? "" : passwordModel.OldPassword;
        string newPassword = passwordModel.NewPassword is null ? "" : passwordModel.NewPassword;
        string confirmPassword = passwordModel.ConfirmPassword is null ? "" : passwordModel.ConfirmPassword;

        if (newPassword != confirmPassword)
        {
            //return Results.BadRequest("Senhas não conferem!");
            return StatusCode(StatusCodes.Status400BadRequest, "Senhas não conferem!");
        }

        UserAuthModel userAuthModel = new UserAuthModel
        {
            Email = username,
            Password = oldPassword
        };

        User user = _userService.GetUser(userAuthModel);

        if (user == null)
        {
            //return Results.BadRequest("Usuário e/ou senha inválidos!");
            return StatusCode(StatusCodes.Status400BadRequest, "Usuário e/ou senha inválidos!");
        }

        user.Password = newPassword;

        return _userService.ChangePersonalizedPassword(user, passwordModel.Email, passwordModel.Telephone) ? StatusCode(StatusCodes.Status200OK, "Senha alterada com sucesso.") : StatusCode(StatusCodes.Status500InternalServerError, "Erro na alteração da senha.");
    }


    [AllowAnonymous]
    [HttpPost("/resetpassword")]
    public IActionResult ResetPassword(UserAuthModel userAuthModel)
    {
        string? newPassword = "Mudar@123";
        string email = userAuthModel.Email is null ? "" : userAuthModel.Email;
        User user = _userService.GetUserByEmail(email);

        if (user == null)
        {
            //return Results.BadRequest("Usuário e/ou senha inválidos!");
            return StatusCode(StatusCodes.Status400BadRequest, "Usuário e/ou senha inválidos!");
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            //return Results.BadRequest("Usuário e/ou senha inválidos!");
            return StatusCode(StatusCodes.Status400BadRequest, "Usuário e/ou senha inválidos!");
        }

        return UserFactory.GetInstance(_serviceProvider, userAuthModel.HealthProgramCode).ChangePassword(user, newPassword, userAuthModel.HealthProgramCode, true) ? StatusCode(StatusCodes.Status200OK, $"Senha alterada para {newPassword} com sucesso.") : StatusCode(StatusCodes.Status500InternalServerError, "Erro na alteração da senha.");
    }

    [AllowAnonymous]
    [HttpPost("/forgotpassword")]
    public IActionResult ForgotPassword(ForgotPasswordUserModel forgotPasswordUserModel)
    {
        if (_userService.ForgorPassword(forgotPasswordUserModel))
            return StatusCode(StatusCodes.Status200OK, "A nova senha foi enviada no seu e-mail cadastrado.");
        return StatusCode(StatusCodes.Status404NotFound, "Não foi encontrado cadastro com o e-mail informado.");
    }

    [AllowAnonymous]
    [HttpPost("/registerlogin")]
    public async Task<JsonResult> RegisterLogin(UserAuthModel userAuthModel, bool success)
    {
        Guid? userId = null;

        if (HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier) is not null)
            userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

        var result = _userService.RegisterLogin(userAuthModel, success, userId);

        return new JsonResult(result);

    }

    [AllowAnonymous]
    [HttpPost("/registerloginbyprogram")]
    public async Task<JsonResult> RegisterLoginByProgram(UserAuthByProgramModel userAuthModel, bool success)
    {
        Guid? userId = null;

        if (HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier) is not null)
            userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

        var result = _userService.RegisterLoginByProgram(userAuthModel, success, userId);

        return new JsonResult(result);

    }

    [Authorize]
    [HttpGet]
    [Route("/getuserhistory")]
    public async Task<JsonResult> GetUserHistory([FromQuery] UserHistoryFilterModel model, string programcode)
    {
        var result = await _userService.GetUserHistory(model, programcode);

        return new JsonResult(result);
    }

    [Authorize]
    [HttpPost("/isfirstaccess")]
    public async Task<JsonResult> IsFirstAccess()
    {
        Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
        var user = _userService.GetIsFirstAccess(userId);
        var hasAcceptedTerms = await _userService.HasAcceptedTerms(userId);

        return new JsonResult(new { isFirstAccess = user, hasAcceptedTerms = hasAcceptedTerms });
    }

    [Authorize]
    [HttpPost("/save-acceptances")]
    public async Task<IActionResult> SaveAcceptances([FromBody] AcceptDataSharingModel model)
    {
        Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
        var result = await _userService.SaveUserAcceptances(userId, model.acceptDataSharing, model.acceptContact);

        if (result)
        {
            return Ok(new { Message = "Aceites salvos com sucesso." });
        }
        return BadRequest(new { Message = "Erro ao salvar aceites." });
    }

    [AllowAnonymous]
    [HttpPost("/forgotpasswordbyuser")]
    public IActionResult ForgotPasswordbyUser(ForgotPasswordbyUserModel forgotPasswordbyUserModel)
    {
        if (_userService.ForgorPasswordbyUser(forgotPasswordbyUserModel))
            return StatusCode(StatusCodes.Status200OK, "Nova senha enviada por e-mail");
        return StatusCode(StatusCodes.Status404NotFound, "Não foi encontrado cadastro com o e-mail informado.");
    }

    [AllowAnonymous]
    [HttpPost("/remember-credentials")]
    public IActionResult RememberCredentials([FromBody] RememberCredentialsModel rememberCredentialsModel)
    {
        if (rememberCredentialsModel.AcceptCookies)
        {
            var result = _credentialsService.RememberCredentials(rememberCredentialsModel.Login, rememberCredentialsModel.Password);

            return Ok(result);
        }

        return Ok(new { Message = "Credenciais não gravadas!" });
    }

    [AllowAnonymous]
    [HttpPost("/verify-cookies")]
    public IActionResult VerifyCookies([FromBody] RememberCredentialsModel credentials)
    {
        var result = _credentialsService.DecryptCredentials(credentials.Login, credentials.Password);

        return Ok(result);
    }

    [Authorize]
    [HttpPost("/changepassworddoctor")]
    public IActionResult ChangePasswordDoctor(PasswordPersonalizedModel passwordModel)
    {
        if (passwordModel == null)
        {
            //return Results.BadRequest();
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        var validatePass = _userService.Validate(passwordModel.NewPassword);

        if (validatePass.isValid == false)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Senhas não seguem o padrão necessário!");
        }

        string username = passwordModel.Login is null ? "" : passwordModel.Login;
        string oldEmail = passwordModel.Email is null ? "" : passwordModel.Email;
        string oldPassword = passwordModel.OldPassword is null ? "" : passwordModel.OldPassword;
        string newPassword = passwordModel.NewPassword is null ? "" : passwordModel.NewPassword;
        string confirmPassword = passwordModel.ConfirmPassword is null ? "" : passwordModel.ConfirmPassword;
        string newTelephone = passwordModel.Telephone is null ? "" : passwordModel.Telephone;
        string programCode = passwordModel.ProgramCode is null ? "" : passwordModel.ProgramCode;

        if (newPassword != confirmPassword)
        {
            //return Results.BadRequest("Senhas não conferem!");
            return StatusCode(StatusCodes.Status400BadRequest, "Senhas não conferem!");
        }

        UserAuthModel userAuthModel = new UserAuthModel
        {
            Login = username,
            Email = oldEmail,
            Password = oldPassword
        };

        User user = _userService.GetUserByEmail(userAuthModel.Email);

        if (user == null)
        {
            //return Results.BadRequest("Usuário e/ou senha inválidos!");
            return StatusCode(StatusCodes.Status400BadRequest, "Usuário e/ou senha inválidos!");
        }

        var doctor = _doctorByProgramRepository.GetValue(d => d.SystemUserId == user.Id);

        if (doctor == null)
        {
            //return Results.BadRequest("Usuário e/ou senha inválidos!");
            return StatusCode(StatusCodes.Status400BadRequest, "Usuário e/ou senha inválidos!");
        }

        doctor.Telephone1 = newTelephone;

        _doctorByProgramRepository.Update(doctor);
 
        user.Telephone = newTelephone;

        return UserFactory.GetInstance(_serviceProvider, passwordModel.ProgramCode).ChangePassword(user, newPassword, passwordModel.ProgramCode, true) ? StatusCode(StatusCodes.Status200OK, $"Senha alterada para {newPassword} com sucesso.") : StatusCode(StatusCodes.Status500InternalServerError, "Erro na alteração da senha.");
    }

    [Authorize]
    [HttpPost("/changepasswordhealthprofessional")]
    public async Task<IActionResult> ChangePasswordHealthProfessional(PasswordPersonalizedModel passwordModel)
    {
        if (passwordModel == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        var validatePass = _userService.Validate(passwordModel.NewPassword);

        if (validatePass.isValid == false)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Senhas não seguem o padrão necessário!");
        }

        string oldPassword = passwordModel.OldPassword is null ? "" : passwordModel.OldPassword;
        string newPassword = passwordModel.NewPassword is null ? "" : passwordModel.NewPassword;
        string confirmPassword = passwordModel.ConfirmPassword is null ? "" : passwordModel.ConfirmPassword;
        string newTelephone = passwordModel.Telephone is null ? "" : passwordModel.Telephone;
        string programCode = passwordModel.ProgramCode is null ? "" : passwordModel.ProgramCode;

        if (newPassword != confirmPassword)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Senhas não conferem!");
        }

        User user = _userService.GetUserByEmail(passwordModel.Email);

        if (user == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Usuário e/ou senha inválidos!");
        }

        var representative = _doctorSanofiService.GetData(user.Id,programCode);

        if (representative == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Usuário e/ou senha inválidos!");
        }

        representative.Telefone1 = newTelephone;

        var resultUpdateRepresentative = await _representativeSanofiService.Update(representative, user.Id);

        if (resultUpdateRepresentative.IsValidData)
        {
            user.Password = newPassword;
            user.Telephone = newTelephone;

            return UserFactory.GetInstance(_serviceProvider, passwordModel.ProgramCode).ChangePassword(user, newPassword, passwordModel.ProgramCode, true) ? StatusCode(StatusCodes.Status200OK, $"Senha alterada para {newPassword} com sucesso.") : StatusCode(StatusCodes.Status500InternalServerError, "Erro na alteração da senha.");
    }
        else
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Não foi possível alterar os dados");
        }

    }

    [AllowAnonymous]
    [HttpPost("/forgotpassword/doctor")]
    public async Task<IActionResult> ForgotPasswordDoctor([FromBody] ForgotPasswordModel model)
    {
        try
        {
            var result = await UserFactory.GetInstance(_serviceProvider, model.ProgramCode).ForgotPassword(model);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("/user/forgotpassword")]
    public IActionResult ForgotPassword(UserForgotPassword userForgotPassword)
    {
        try
        {
            var result = _userService.ForgotPassword(userForgotPassword);

            return new JsonResult(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("/checkexpiredpassword")]
    public IActionResult CheckExpiredPassword(string programcode)
    {
        Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
        User user = _userService.GetUserById(userId);

        if (user == null)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, new { logged = false, message = "Usuário inválido" });
        }

        var expired = UserPasswordHistoryFactory.GetInstance(_serviceProvider, programcode).CheckExpiredPassword(user, programcode);

        if (expired)
            return StatusCode(StatusCodes.Status400BadRequest, new { logged = false, message = "Senha expirada" });

        return StatusCode(StatusCodes.Status200OK, new { logged = true, message = "Senha válida" });
    }
}

