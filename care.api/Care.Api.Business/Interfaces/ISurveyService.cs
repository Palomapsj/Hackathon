using Care.Api.Business.Models;
using Care.Api.Business.ServicesReturnMessage;

namespace Care.Api.Business.Interfaces
{
    public interface ISurveyService
    {
        Task<List<QuestionModel>> GetQuestionsSurvey(string name, string programcode);
        Task<ReturnMessage<string>> AddResponseSurvey(List<SurveyResponseModel> surveyResponseModel, string programcode, Guid userId);
        Task<ReturnMessage<string>> AddConsentSurvey(string programcode, bool consentsurvey, Guid userId);
        Task<SurveyResponseValidationModel> GetLastSurveyResponse(string name, string programcode, Guid userId);
        Task<List<QuestionModel>> GetAllFromProgram(string programcode);
    }
}
