using Care.Api.Business.Models;
using Care.Api.Business.Models.Basic;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Care.Api.Business.Interfaces;

public interface IDoctorService
{
    Task<PaginationResult<List<DoctorResultModel>>> GetDoctors(DoctorFilterModel model, Guid userId, string programcode);
    Task<ReturnMessage<string>> Add(DoctorModel doctorModel);
    Task<ReturnMessage<DoctorModel>> UpdateDoctor(DoctorModel doctorModel);
    Task<ReturnMessage<DoctorModel>> UpdateDoctor(DoctorModel doctorModel, Guid userId);
    bool RecoveryPassword(ForgotPasswordDoctorModel forgotPasswordDoctorModel);
    bool ForgorLoginbyCRM(ForgotLoginbyCRMModel forgotLoginbyCRMModel);
    Task<DoctorCFMModel?> GetDoctorByCRMUF(string crm, string ufcrm);
    DoctorByProgram GetDoctorByCRMDatabase(string licenseNumber, string licenseState, Guid healthProgramId);
    Doctor GetDoctorByUserId(Guid Id, string programcode);
    DoctorModel GetDoctorInfo(Guid userId, string programcode);
    Task<List<MedicalSpecialtyModel>> GetMedicalSpecialties();
    Task<List<AddressModel>> GetAddressByDoctor(Guid userId, string programcode);
    Task<ReturnMessage<string>> WelcomeEmailResend(DoctorEmailResendModel model, Guid userId, string programcode);
    Task<ReturnMessage<AttachmentModel>> GetAppraisal(Guid id, Guid userId);
    Task<ReturnMessage<string>> SendEmailDoctor(Guid userId, string emailaddress, string voucher, string templatename);
    Task<ReturnMessage<string>> SendSmsDoctor(Guid userId, string mobilephone, string voucher, string templatename);
    Task<ReturnMessage<string>> SendEmailDoctorAdmin(Guid userId, string emailaddress, string voucher, string templatename, string crm, string uf, string programcode);
    Task<ReturnMessage<string>> SendSmsDoctorAdmin(Guid userId, string mobilephone, string voucher, string templatename, string crm, string uf, string programcode);
    Task<ReturnMessage<string>> AddProfessional(RepresentativeCreateModel model, Guid userId);
    Task<PaginationResult<List<DoctorProgram>>> GetProgramsByUser(Guid userId);
    DoctorModel GetDoctorProgram(Guid doctorId, string programcode);
    Task<ReturnMessage<string>> TermDoctor(TermDoctorResult termDoctor);
    TermDoctorResult ValidateConsentDoctor(Guid doctorId, string programcode);
    Task<ReturnMessage<DoctorModel>> DisableDoctor(Guid userId);
    Task<ReturnMessage<DoctorModel>> InactiveDoctor(InactiveDoctorModel model);
    Task<List<DoctorsByRepresentative>> GetDoctorsByProgram(string programcode);
    Task<PaginationResult<List<RepresentativeResultModel>>> ListNurses(RepresentativeFilterModel model, string programcode, Guid? userId);
    Task<ReturnMessage<string>> ManagementNurses(ManagementNurses model, Guid userId);
    Task<ReturnMessage<string>> AddHealthProfessional(RepresentativeCreateModel representative);
    bool ForgotLoginbyLicenseNumber(ForgotLoginbyLicenseNumber forgotLoginbyLicenseNumber);
    Task<ReturnMessage<List<string>>> ValidateHealthProfessionalByProgram(string login);
    RepresentativeResultModel GetData(Guid userId, string programcode);
    Task<ReturnMessage<List<DoctorExistResultModel>>> GetDoctorCRMUFByProgram(string crm, string ufcrm, string programcode);
    Task<ReturnMessage<string>> AddHealthProfessionalByDoctor(RepresentativeCreateModel representative, Guid userId);
    Task<ReturnMessage<string>> RequestDoctorlBond(RepresentativeDoctorByProgramRequest representativeDoctorByProgramRequest, Guid userId);
    Task<ReturnMessage<string>> AlterRequestHealthProfessionalBondByDoctor(RepresentativeDoctorByProgramRequest representativeDoctorByProgramRequest, Guid userId);
    Task<List<RepresentativeByDoctorResultModel>> GetRepresentativeByDoctors(Guid userId, string programcode);
    Task<PaginationResult<List<DoctorProgram>>> GetProfileByHealthProfessional(Guid userId);
}
