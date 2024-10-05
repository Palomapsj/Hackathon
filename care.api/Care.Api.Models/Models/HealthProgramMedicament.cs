using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Models
{
    public partial class HealthProgramMedicament
    {
        public Guid HealthProgramId { get; set; }
        public Guid MedicamentId { get; set; }
    }
}
