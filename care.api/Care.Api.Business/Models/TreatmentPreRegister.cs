using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class TreatmentPreRegister
    {
        public Guid Id { get; set; }
        public string? PatientName { get; set; }
        public string? CPF { get; set; }
        public Guid? MedicamentId { get; set;}
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? DoctorName { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseState { get; set; }
        public string? ProgramCode { get; set; }
        public AttachmentModel? MedicalPrescriptionAttach { get; set; }

    }
}
