using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class QuestionModel
    {
       public Guid? Id { get; set; }
       public string? QuestionDescription { get; set; }
       public int? QuestionType { get; set; }
       public int? ExibitionOrder { get; set; }
       public Guid? SurveyId { get; set; }

       public List<QuestionOptionModel> QuestionOption { get; set; }
    }
}