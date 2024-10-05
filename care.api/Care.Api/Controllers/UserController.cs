using Care.Api.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Care.Api.Factory;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Business.Services;

namespace Care.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = false)]
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;

    public UserController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("create")]
    public Task<JsonResult> Create([FromBody] UserCreateModel model)
    {
        var result = UserFactory.GetInstance(_serviceProvider, model.ProgramCode).CreateUser(model);

        return Task.FromResult(new JsonResult(result));
    }

    [Authorize]
    [HttpPost]
    [Route("update")]
    public Task<JsonResult> Update([FromBody] UserUpdateModel model)
    {
        var userId = Guid.Parse(HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var result = UserFactory.GetInstance(_serviceProvider, model.ProgramCode).UpdateUser(userId, model);

        return Task.FromResult(new JsonResult(result));
    }

}