using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Care.Api.Business.Models
{
	public class VisitDetailsModel
	{
		public Guid? VisitId { get; set; }
		public string? Name { get; set; }
		public EyePrescriptionModel? EyePrescription { get; set; }

	}
    public class VisitDetailsByNurseModel
    {
        public Guid? VisitId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorCPF { get; set; }
        public string? DoctorEmail { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string? DiseaseName { get; set; }
        public int? Amount { get; set; }

        // Nome do medico, CPF, Email, Data Agendada, doença, quantidade
    }
}
