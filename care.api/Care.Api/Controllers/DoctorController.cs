using Care.Api.Business.Models;
using Care.Api.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Care.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public DoctorController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        

        [AllowAnonymous]
        [HttpPost]
        [Route("adddoctor")]
        public async Task<IActionResult> AddDoctor(DoctorModel doctor)
        {
            var result = await DoctorFactory.GetInstance(_serviceProvider, doctor.HealthProgramCode).Add(doctor);

            if (!result.IsValidData)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateDoctor")]

        public async Task<IActionResult> UpdateDoctor(DoctorModel doctor)
        {
            var result = await DoctorFactory.GetInstance(_serviceProvider, doctor.HealthProgramCode).UpdateDoctor(doctor);

            if (result is null)
            {
                return BadRequest("Medico não atualizado.");
            }

            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        [Route("GetAdress")]
        public async Task<IActionResult> GetAddress(string programcode)
        {
            Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await DoctorFactory.GetInstance(_serviceProvider, programcode).GetAddressByDoctor(userId, programcode);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SendEmailDoctor")]
        public async Task<JsonResult> SendEmailDoctor(string emailaddress, string voucher, string templatename, string programcode)
        {
            Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await DoctorFactory.GetInstance(_serviceProvider, programcode).SendEmailDoctor(userId, emailaddress, voucher, templatename);

            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("sendsmsdoctor")]
        public async Task<JsonResult> SendSmsDoctor(string mobilephone, string voucher, string templatename, string programcode)
        {
            Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await DoctorFactory.GetInstance(_serviceProvider, programcode).SendSmsDoctor(userId, mobilephone, voucher, templatename);

            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpPost("forgetpasswordbycrm")]
        public IActionResult ForgetPassword(ForgotPasswordDoctorModel forgotPasswordDoctorModel, string programcode)
        {
            if (forgotPasswordDoctorModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            if (DoctorFactory.GetInstance(_serviceProvider, programcode).RecoveryPassword(forgotPasswordDoctorModel))
                return StatusCode(StatusCodes.Status200OK, "Nova senha enviada por e-mail");

            return StatusCode(StatusCodes.Status500InternalServerError, "Não foi encontrado cadastro com o e-mail informado.");
        }

        [AllowAnonymous]
        [HttpPost("/forgetloginbycrm")]
        public IActionResult ForgotLoginbyCRM(ForgotLoginbyCRMModel forgotLoginbyCRMModel)
        {
            if (DoctorFactory.GetInstance(_serviceProvider, forgotLoginbyCRMModel.healthProgramCode).ForgorLoginbyCRM(forgotLoginbyCRMModel))
                return Ok(new { message = "Será enviado um email com seu login." });
            else
                return NotFound(new { message = "Não foi encontrado cadastro com o e-mail informado." });
        }

     
        [Authorize]
        [HttpGet]
        [Route("getdoctorcrmufbyprogram")]
        public async Task<JsonResult> GetDoctorCRMUFByProgram(string crm, string ufcrm, string programcode)
        {
            var result = await DoctorFactory.GetInstance(_serviceProvider, programcode).GetDoctorCRMUFByProgram(crm, ufcrm, programcode);

            return new JsonResult(result);
        }

       
    }
}
