using Care.Api.Business.Models;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;

namespace Care.Api.Business.Interfaces
{
    public interface ILoginService
    {
        Task<ReturnMessage<User>> LoginAsync(string email, string password, string code);
        Task<ReturnMessage<ResponseLogin>> LoginByProgram(string email, string password);
        Task<ReturnMessage<User>> LoginInTwoStepsAsync(string email, string password, string helthProgramCode, string tokenDigits = ""); 
        Task<ReturnMessage<string>> Logoff();
        Task<bool> VerifyTypePatient(Guid? userId);
    }
}
