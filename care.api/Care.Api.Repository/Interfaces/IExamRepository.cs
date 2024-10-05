using Care.Api.Models;
using Care.Api.Models.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IExamRepository : ICommonRepository<Exam>
    {
        Exam GetExamComplete(Guid id);
        Exam GetExamById(Guid id);
        List<ExamAudit> GetExamAudit(Guid id);
        List<Exam> GetExamsByTreatment(Guid? id);
        List<Exam> GetExamsByDiagnostic(Guid id);
        Task<List<ExamHistory>> GetExamHistory(Guid id);
        Task<List<Exam>> GetAllExamsByDoctor(Guid? userId, Guid? healthprogramId);
        Task<List<Exam>> GetAllExamsByProgramAndPatient(Guid healthProgram, Guid userId);
        Task<List<Exam>> GetAllExamsByProgramAndLogistic(Guid healthProgram, Guid userId); 
    }
}
