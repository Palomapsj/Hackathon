using Care.Api.Business.Models.Basic;
using Care.Api.Business.Models;
using Care.Api.Models;
using Care.Api.Business.ServicesReturnMessage;

namespace Care.Api.Business.Interfaces
{
    public interface IUserService
    {
        bool IsValidUser(UserAuthModel userAuthModel);
        User GetUser(UserAuthModel userAuthModel);
        User GetUserByEmail(string email);
        User GetUserById(Guid? id);
        Task<PaginationResult<List<UserHistoryModel>>> GetUserHistory(UserHistoryFilterModel model, string programCode);
        ReturnMessage<string> UpdateUser(Guid userId, UserUpdateModel model);
        UserListModel GetUserByIdAsListModel(Guid? id);
        bool ChangePassword(User user, string newPassword, string programCode, bool forceChangePwdNextLogin = false, string accessToken = null);
        bool ForgorPassword(ForgotPasswordUserModel forgotPasswordDoctorModel);
        string SendNewTokenForUser(Guid userId, string helthProgramCode);
        User CreateUser(UserCreateModel userModel, bool isSendSms = true);
        bool GetIsFirstAccess(Guid userId);
        bool RegisterLogin(UserAuthModel userModel, bool sucess, Guid? userId = null);
        Task<bool> SaveUserAcceptances(Guid userId, bool acceptDataSharing, bool acceptContact);
        int GetCountAmountofAccesses(string email);
        bool ForgorPasswordbyUser(ForgotPasswordbyUserModel forgotPasswordbyUserModel);
        string PostUserData(PostDataModel postDataModel);

        List<Care.Api.Models.HealthProgram> GetHealthProgramById(string email);
        int GetCountAmountofAccesses(Guid Id);
        List<HealthProgram> GetHealthProgramById(Guid Id);
        Task<bool> HasAcceptedTerms(Guid userId);

        (List<PoliciesResult> policiesResult, bool isValid) Validate(string password);

        bool ChangePersonalizedPassword(User user, string email, string telephone, bool forceChangePwdNextLogin = false);

        List<DoctorProgram> GetProgramsByUser(Guid userId);

        bool RegisterLoginByProgram(UserAuthByProgramModel userModel, bool sucess, Guid? userId = null);

        		ReturnMessage<string> ForgotPassword(UserForgotPassword model);
        
        		User GetUserByLogin(UserAuthModel userAuthModel);

        		List<DoctorProgram> GetProfileByHealthProfessional(Guid userId);
        
        		bool EmailExists(string email, string programCode);
        		
        		Task<ReturnMessage<string>> ForgotPassword(ForgotPasswordModel model);
    }
}
