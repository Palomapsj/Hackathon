using Care.Api.Business.Models;
using Care.Api.Models;
using Care.Api.Models.Models;
using System.Linq.Expressions;

namespace Care.Api.Repository.Interfaces
{
    public interface ITreatmentRepository : ICommonRepository<Treatment>
    {
        Treatment? GetFullTreatmentByPredicate(Expression<Func<Treatment, bool>> predicate);
        List<TreatmentAudit> GetTreatmentAudit(Guid id);
        Task<List<Treatment>> GetTreatmentByProgramAndDoctor(Guid healthProgram, Guid? userId);
        Task<List<Treatment>> GetTreatmentByProgramAdmin(Guid healthProgram);
        Task<Treatment>GetTreatmentByProgramAndPatient(Guid healthProgram, Guid userId);
        Task<List<Treatment>> GetAllInactiveTreatmentsByDoctor(Guid? userId, Guid inactiveStatusId);
        Task<List<Treatment>> GetAllInactiveTreatmentsByDoctorAndProgram(Guid? userId, Guid inactiveStatusId, Guid? healthProgramId);
        Task<List<Treatment>> GetAllAcessTreatmentsByDoctor(Guid? userId, Guid? healthprogramid);
        Task<Treatment> GetById(Guid? id);
        Task<Treatment> GetByPatientId(Guid id);

        Task<List<Treatment>> GetTreatmentByDoctorRepresentative(Guid healthProgram, Guid? userId);
        TreatmentAddress GetByCPF(Guid treatmentId);
        Treatment GetMedicamentById(Guid? treatmentId, Guid? medicamentId);
         Task<List<ByDateRangeModel>> GetByDateRange(DateTime startDate, DateTime endDate, Guid doctorId, string healthProgramCode);
        Task<List<string>> GetTreatmentByMedicamentId(Guid medicamentId);
        Task<List<Treatment>> GetTreatmentsByPatientId(Guid patientId);
        Task<List<InfusionHistory>> GetTreatmentHistoryByInfusion(Guid id);
        Task<List<Treatment>> GetTreatmentsWithDisease(Guid? userId, Guid diseaseId);
        Task<List<StrengthMedicament>> GetDosageById(Guid? id);

        Task<Treatment> GetTreatmentByCpfProgram(string cpf, Guid healthProigramId);
    }
}
