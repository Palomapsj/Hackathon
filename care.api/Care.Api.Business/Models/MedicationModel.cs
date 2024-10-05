using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class MedicationModel
    {

       public Guid Id { get; set; }
       public Guid DiseaseId { get; set; }
       public string Name { get; set; }    
      
    }
}
