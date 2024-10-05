using Care.Api.Business.Models;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;

namespace Care.Api.Business.Interfaces
{
    public interface IVoucherService
    {
        ReturnMessage<Voucher> Add(VoucherModel voucher);
        ReturnMessage<Voucher> AddAdmin(VoucherModel voucher);
        ReturnMessage<Voucher> Update(Voucher voucher);
        ReturnMessage<bool> Update(VoucherModel voucher);
        ReturnMessage<bool> Delete(Guid voucherId, string programCode);
        Task<ReturnMessage<string>> ValidateVoucher(VoucherValidateModel voucher);
        Task<ReturnMessage<List<string>>> GetVoucherTypes(string programCode);
        Task<ReturnMessage<string>> GetDiseaseMessage(Guid treatmentId);
        Task<ReturnMessage<string>> VerifyAllowedExams(Guid treatmentId, Guid examDefinitionId);
        Task<ReturnMessage<List<OptionResultModel<Guid>>>> GetVoucherStatus(string programCode);
        Task<ReturnMessage<List<VoucherResultModel>>> List(string programCode, string? voucherTypes = null, Guid? status = null, int? deadlineInDays = null);
        Task<ReturnMessage<DiagnosticVoucherResultModel>> ListByPatient(string programCode, string cpf, Guid? status = null);
        Task<ReturnMessage<VoucherResulmeResult>> GetResulme(string programCode, string? voucherTypes = null, Guid? status = null, int? deadlineInDays = null);
        Task<ReturnMessage<List<DiagnosticVoucherResultModel>>> ListAllPatient(string programCode);
        ReturnMessage<bool> Rescue(Guid voucherId, string programCode);
        ReturnMessage<bool> Use(Guid voucherId, string programCode, string purchaseGroupCode);
        Task<ReturnMessage<DiagnosticVoucherResultModel>> ListByPatientRescue(string programCode, string cpf);
        Task<ReturnMessage<List<ResumeUsedVoucherModel>>> ResumeUsedVoucher(string programCode);
        Task<bool> LinkVouchersToNewUser(Diagnostic diagnostic);
        Task<VoucherModel> ValidateVoucherDoctor(VoucherValidateModel voucher);

        //Gerar o voucher através do VoucherConfiguration
        Guid GenerateVoucher(string voucherConfigurationCode);
        Task<ReturnMessage<string>> Add(TreatmentAndExamModel model);
        Task<ReturnMessage<string>> AddVoucherAdmin(TreatmentAndExamModel model);
    }
}
