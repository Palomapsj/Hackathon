using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class SurveyResponseValidationModel
    {
        public bool? AcceptedQuestionnaire { get; set; }
        public bool? ThreeMonthsSinceLastResponse { get; set; }
        public bool? PendingResponse { get; set; }
        public bool? IsOnboardingAnswered { get; set; }
        public bool? IsAccessionPhase { get; set; }
    }
}