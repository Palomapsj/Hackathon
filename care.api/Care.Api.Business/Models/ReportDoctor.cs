using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ReportDoctor
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; } 

        public string? PatientName { get; set; }
        public string? PatientCpf { get; set; }
        public string? StatusPaciente { get; set; }
        public string? Patologia { get; set; }
        public string? DosagemInicial { get; set; }
        public string? DosagemAtual { get; set; }
        public string? UF { get; set; }
        public string? Cidade { get; set; }
        public DateTime? RegisterDate { get; set; }
        public Guid? PatientStatus { get; set; }
        public string? PatientStatusName { get; set; }
        public Guid? MedicamentId { get; set; }
        public string? MedicamentName { get; set; }
        public Guid? PhaseId { get; set; }
        public string? PhaseName { get; set; }
        public Guid? TreatmentId { get; set; }
        public string HealthProgramCode { get; set; }
        public Guid? UserId { get; set; }
        public List<ReportExam>? ReportExam { get; set; }

    }
    public class ReportExam
    {
        public int? Page { get; set; } 
        public int? PageSize { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? ExamDefinition { get; set; }
        public string? ExamDefinitionName { get; set; }
        public Guid? ExamStatus { get; set; }
        public string? ExamStatusName { get; set; }
        public Guid? LocalId { get; set; }
        public string? LocalName { get; set; }

    }
}
