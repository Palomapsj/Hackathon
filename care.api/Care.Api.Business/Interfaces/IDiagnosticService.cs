using Care.Api.Business.Models;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using static Care.Api.Business.Models.ExamResultModel;

namespace Care.Api.Business.Interfaces
{
    public interface IDiagnosticService
    {
        Task<PaginationResult<List<DiagnosticExamModel>>> List(DiagnosticFilterModel model, Guid userId, string programcode);
        Task<PaginationResult<List<DiagnosticExamModel>>> ListAdmin(DiagnosticFilterModel model, Guid userId, string programcode);
        Task<PaginationResult<List<DiagnosticExamModel>>> ListExamByDiagnosticPatient(DiagnosticFilterModel model, string programcode, Guid userId);
        Task<List<SourceConsentModel>> GetSourceConsent(string programcode);
        Task<ReturnMessage<string>> Add(ExamCreateModel model, Guid? userId);
        Task<ReturnMessage<string>> Update(ExamCreateModel model, Guid userId);
        Task<ReturnMessage<string>> Delete(Guid Id, string programCode);
        Task<ReturnMessage<bool>> InformExamResult(ExamResultModel model, Guid userId);
        Task<ReturnMessage<bool>> InformPendencyAnalisys(InformPendencyExamModel model, Guid userId);
        Task<PaginationResult<List<DiagnosticExamResultModel>>> ListExamByDiagnostic(ExamFilterModel model, string programcode, Guid userId);
        Task<DiagnosticExamModel> Get(Guid Id, string programCode);
        Task<ReturnMessage<string>> Inactivate(Guid Id, string programCode);
        Task<ReturnMessage<string>> RequestExam(ExamRequestModel model, Guid? userId);
        Task<ReturnMessage<string>> RequestDiagnosticExamList(RequestDiagnosticExamModel model, Guid userId);
        Task<List<Account>> ListNearbyAccounts(Guid userId, string addressPostalCode, int? page = 1, int? pageSize = 5);
        Task<ReturnMessage<string>> ScheduleVisitToClinic(VisitCreateModel model, Guid userId);
        Task<ReturnMessage<string>> ScheduleVisit(VisitCreateModel model, Guid userId);
        Task<ReturnMessage<string>> EditVisitToClinic(VisitEditModel model, Guid userId);
        Task<ReturnMessage<string>> ConfirmVisitAttendance(VisitAttendanceModel model, Guid userId);
        Task<ReturnMessage<string>> CancelVisitAttendance(VisitAttendanceModel model, Guid userId);
        Task<ReturnMessage<string>> PatientNotAttended(VisitAttendanceModel model, Guid userId);
        Task<PaginationResult<List<DiagnosticExamResultModel>>> ListExamByDiagnosticbyId(ExamFilterModel model, string programcode, Guid userId, Guid diagnosticId);
        Task<List<VisitAttendanceResponse>> ListVisitAttendance(Guid userId,
                                                               string programCode,
                                                               bool? isVisitConfirmed = false,
                                                               bool? isAttendanceConfirmed = false,
                                                               bool? isAttendanceCanceled = false,
                                                               bool? isAttendancePreCanceled = false,
                                                               int page = 1,
                                                               int pageSize = 5);
        Task<ReturnMessage<string>> ConfirmVisitToClinic(Guid visitId, Guid userId);
        Task<ReturnMessage<string>> CancelVisitToClinic(Guid visitId, Guid userId);
        Task<List<VisitListModel>> ListVisitsToClinic(Guid userId,
                                                        string programCode,
                                                        bool? isPreScheduling = false,
                                                        bool? isConfirmed = false,
                                                        bool? isCanceled = null,
                                                        string? month = null,
                                                        int page = 1,
                                                        int pageSize = 5);
        Task<VisitDetailsModel> ListVisitDetails(Guid visitId, string programCode);
        Task<PatientResultModel?> GetDiagnosticByCPF(string cpf);
        Task<Diagnostic> GetByCPF(string cpf);
        Task<ReturnMessage<string>> AddUserPatient(ExamCreateModel model);

        Task<PaginationResult<List<DiagnosticServiceTypeResultModel>>> ListDiagnosticsByServiceType(DiagnosticFilterModel model, string programcode, Guid userId);

        Task<DiagnosticExamModel> GetPatientInformationIndependencia(Guid userId, string programcode);
        Task<ReturnMessage<string>> SendSmsDiagnostic(Guid diagnosticId, string mobilephone, string voucher, string templatename);
        Task<ReturnMessage<string>> SendEmailDiagnostic(Guid diagnosticId, string emailaddress, string voucher, string templatename);
        Task<ReturnMessage<string>> SendSmsDiagnosticPatient(string mobilephone, string voucher, string templatename, Guid userId);
        Task<ReturnMessage<string>> SendEmailDiagnosticPatient(string emailaddress, string voucher, string templatename, Guid userId);
        Task<PaginationResult<List<DiagnosticExamModel>>> ListNurse(DiagnosticFilterModel model, Guid userId, string programcode);
        string GetRandomKey(int len);
        Task<PaginationResult<List<DiagnosticExamResultModel>>> ListExamByDiagnosticNurse(ExamFilterModel model, string programcode, Guid userId);
    }
}
