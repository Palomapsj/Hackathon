using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class InfusionModel
    {
        public Guid Id { get; set; }
        public Guid DiseaseId { get; set; }
        public Guid TreatmentId { get; set; }  
        public Guid DoctorId { get; set; }
        public Guid? PatientId { get; set; }
        public string? HealthProgramCode { get; set; }
        public AttachmentModel? MedicalPrescriptionAttach { get; set; }
        public AttachmentModel? MedicalReportAttach { get; set; }

    }
}
