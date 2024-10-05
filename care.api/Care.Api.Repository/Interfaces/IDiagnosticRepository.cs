using Care.Api.Models;
using System.Linq;

namespace Care.Api.Repository.Interfaces
{
    public interface IDiagnosticRepository : ICommonRepository<Diagnostic>
    {
        List<Diagnostic> GetDiagnosticsByDoctor(Guid doctorId, Guid healthProgramId);
        List<Diagnostic> GetDiagnosticsByLaboratory(Guid accountId, Guid healthProgramId);
        Task<List<Diagnostic>> GetDiagnosticsByProgram(Guid healthProgram);
        List<DiagnosticAudit> GetDiagnosticAudit(Guid id);
        Task<Diagnostic> GetDiagnosticByProgramAndPatient(Guid healthProgram, Guid userId);
        Task<List<Diagnostic>> GetDiagnosticByProgramAndDoctor(Guid healthProgram, Guid? userId);
        Task<Diagnostic> GetDiagnosticById(Guid Id);
        Task<Diagnostic?> GetByCPF(string cpf);
        Task<Diagnostic?> GetDiagnosticByCpfProgram(string cpf, Guid healthProigramId);
        Task<Diagnostic?> GetDiagnosticByCpfProgram(string cpf, string programCode);
        IQueryable<Diagnostic> Queryable();
    }
}
