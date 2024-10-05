using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Models
{
    public class TreatmentByCpf
    {
        public string? PatientName { get; set; }
        public string? CPF { get; set; }
        public string? MedicamentName { get; set; }
        public string? PatientRg { get; set; }
        public DateTime? PatientBirthDate { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientPhoneNumber { get; set; }
        public string? PatientSecondaryPhoneNumber { get; set; }

        public string? DoctorName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? UF { get; set; }
        public Guid? HealthProgramId { get; set; }

        public List<MedicamentResult>? Medicaments { get; set; }
        public List<DiseaseResult>? Diseases { get; set; }
        public string? PhaseName { get; set; }

        public Guid? TreatmentId { get; set; }

    }

    public class MedicamentResult
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
    public class DiseaseResult
    {
        public string? Name { get; set; }
    }
}
