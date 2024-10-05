using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ExamStatusModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }    
    }

    public class ExamStatusListModel : List<ExamStatusModel> { }
}
