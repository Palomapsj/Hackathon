using Care.Api.Models;
using Care.Api.Models.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IReportRepository
    {
        Task<List<Diagnostic>> Teste(Guid healthProgramId);
        Task<List<ExamReport>> GetDiagnosticsByProgram(string programCode, string? patientName, bool? statusPaciente, DateTime? initialDateSolicitation, DateTime? endDateSolicitation, DateTime? initialDateScheduling, DateTime? endDateScheduling, Guid? pathologyId, Guid? examDefinitionId, string? examStatus, string? voucher, string? cpf);
    }
}
