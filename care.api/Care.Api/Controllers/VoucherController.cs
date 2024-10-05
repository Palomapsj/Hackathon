using Care.Api.Business.Models;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Factory;
using Care.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Care.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class VoucherController : Controller
{
    private readonly IServiceProvider _serviceProvider;

    public VoucherController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("ValidateVoucher")]
    public async Task<ReturnMessage<string>> ValidateVoucher(VoucherValidateModel model)
    {
        var result = await VoucherFactory.GetInstance(_serviceProvider, model.ProgramCode).ValidateVoucher(model);

        return result;
    }


    [Authorize]
    [HttpPost]
    [Route("add")]
    public Task<ReturnMessage<Voucher>> Add(VoucherModel model)
    {
        var result = VoucherFactory.GetInstance(_serviceProvider, model.ProgramCode).Add(model);

        return System.Threading.Tasks.Task.FromResult(result);
    }

   

    [Authorize]
    [HttpPost]
    [Route("update")]
    public Task<ReturnMessage<bool>> Update(VoucherModel model)
    {
        var result = VoucherFactory.GetInstance(_serviceProvider, model.ProgramCode).Update(model);

        return System.Threading.Tasks.Task.FromResult(result);
    }

    [Authorize]
    [HttpPost]
    [Route("delete")]
    public Task<ReturnMessage<bool>> Delete([FromQuery] Guid voucherId, [FromQuery] string programCode)
    {
        var result = VoucherFactory.GetInstance(_serviceProvider, programCode).Delete(voucherId, programCode);

        return System.Threading.Tasks.Task.FromResult(result);
    }

}
