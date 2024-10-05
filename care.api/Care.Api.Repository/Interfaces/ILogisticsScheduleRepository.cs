using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface ILogisticsScheduleRepository : ICommonRepository<LogisticsSchedule>
    {
        Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndDoctor(Guid healthProgram, Guid userId);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndDoctorId(Guid healthProgram, Guid userId);
        Task<LogisticsSchedule> GetLogisticsScheduleById(Guid id);
        Task<LogisticsSchedule> GetLogisticsScheduleByDiagnostic(Guid diagnosticId);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleByDiagnosticList(Guid diagnosticId);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleByExamList(Guid examId);
        Task<LogisticsSchedule> GetLogisticsScheduleByTreatment(Guid treatmentId);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndLogistic(Guid healthProgram, Guid userId);
        Task<LogisticsSchedule> GetExamsByLogisticsScheduleId(Guid id);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleAdmin(Guid healthProgram);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleAdminFiltered(Guid healthProgram,
            int pageSize, int page);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleLaboratoryFiltered(Guid healthProgram,
            int pageSize, int page, Guid userId);
        Task<List<LogisticsSchedule>> GetLogisticsSchedulePendencyAdminFiltered(Guid healthProgram,
            int pageSize, int page);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndDoctorProfessional(Guid healthProgram, Guid? userId);
        Task<List<LogisticsSchedule>> GetLogisticsScheduleByProgramAndLogisticProfessional(Guid healthProgram, Guid? userId);
    }

}
