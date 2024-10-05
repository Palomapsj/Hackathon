using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Business.Models
{
    public class PoliciesResult
    {
        public string? message { get; set; }
        public bool? isValid { get; set; }

    }

    public class VariaveisResponse
    {
        public List<PoliciesResult> policiesResult { get; set; }
        public bool isValid { get; set; }
    }
}
