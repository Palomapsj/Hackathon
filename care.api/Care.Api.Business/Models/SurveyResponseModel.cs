using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class SurveyResponseModel
    {
        public Guid? SurveyId { get; set; }
        public string? QuestionResponse { get; set; }
        public Guid? QuestionId { get; set; }
        public int? Order { get; set; }
        public string? Control { get; set; }
    }
}