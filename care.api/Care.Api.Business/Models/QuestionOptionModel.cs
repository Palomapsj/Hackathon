using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class QuestionOptionModel
    {
       public Guid? Id { get; set; }
       public string? OptionDescription { get; set; }
       public int? ExibitionOrder { get; set; }
       public Guid? QuestionId { get; set; }

       public QuestionModel Question { get; set; }
    }
}