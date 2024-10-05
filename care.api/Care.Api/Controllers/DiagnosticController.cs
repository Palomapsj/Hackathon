using Care.Api.Business.Models;
using Care.Api.Business.ServicesReturnMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Care.Api.Factory;
using Care.Api.Models;

namespace Care.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiagnosticController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public DiagnosticController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [Authorize]
        [HttpGet]
        [Route("Delete")]
        public async Task<JsonResult> Delete([FromQuery] Guid Id, string programCode)
        {
            var result = await DiagnosticFactory.GetInstance(_serviceProvider, programCode).Delete(Id, programCode);
            return new JsonResult(result);
        }

        [Authorize]
        [HttpGet]
        [Route("GetDiagnostics")]
        public async Task<JsonResult> GetDiagnostics([FromQuery] DiagnosticFilterModel model, string programcode)
        {
            Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await DiagnosticFactory.GetInstance(_serviceProvider, programcode).List(model, userId, programcode);

            return new JsonResult(result);
        }

        

        [Authorize]
        [HttpGet]
        [Route("GetExambyDiagnosticId")]
        public async Task<JsonResult> GetExamByDiagnoticId([FromQuery] ExamFilterModel model, string programcode, Guid diagnosticId)
        {
            Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await DiagnosticFactory.GetInstance(_serviceProvider, programcode).ListExamByDiagnosticbyId(model, programcode, userId, diagnosticId);

            return new JsonResult(result);
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateDiagnostic")]
        public async Task<JsonResult> UpdateDiagnostic([FromBody] ExamCreateModel model)
        {
            Guid userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await DiagnosticFactory.GetInstance(_serviceProvider, model.ProgramCode).Update(model, userId);

            return new JsonResult(result);
        }




        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddDiagnostic([FromBody] ExamCreateModel model)
        {
            try
            {
                var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await DiagnosticFactory.GetInstance(_serviceProvider, model.ProgramCode).Add(model, userId != null ? Guid.Parse(userId) : null);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Authorize]
        [HttpGet]
        [Route("GetDiagnosticbyCpf")]
        public async Task<IActionResult> GetDiagnosticByCpf(string cpf)
        {
            var result = DiagnosticFactory.GetInstance(_serviceProvider, null).GetDiagnosticByCPF(cpf);

            if (result is null)
                return NotFound();

            return Ok(result.Result);
        }

       
    }
}
