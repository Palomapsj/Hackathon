using Care.Api.Business.Models;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Care.Api.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Care.Api.Business.Interfaces;

    public interface IExamService
    {
        Task<ExamPendingModel> GetExamPending(Guid id);
        Task<ReturnMessage<bool>> ExamResolvePendency(ExamPendingResolveModel model);
        Task<ExamCreateModel> GetExam(Guid id);
        Task<List<PendencyReasonModel>> GetPendencyReasons(string programcode);
        Task<bool> ExamConfirmCollect(ExamConfirmCollectModel model);
        Task<List<DocValidationTypeModel>> GetDocValidationType(string programcode);
        Task<List<ReasonsForLabDisapprovalModel>> GetReasonsForLabDisapproval(string programcode);
        Task<bool> InformPendencyExam(ExamPendenciesModel model);
        Task<bool> InformExamCancellation(ExamCancellationModel model);
        Task<List<AuditGenericModel>> GetExamAudit(Guid id);
        Task<ExamStatusListModel> GetExamStatus(string? programcode);
        Task<ReturnMessage<string>> PostPreSchedulingExam(PostPreSchedulingExamModel model, Guid? userId);
    }


