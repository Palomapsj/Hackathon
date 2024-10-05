using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Care.Api.Business.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Business.Services
{
    public class VoucherService : IVoucherService
    {
        protected readonly IVoucherRepository _voucherRepository;
        protected readonly IVoucherConfigurationRepository _voucherConfigurationRepository;
        protected readonly IIdentityCodeRepository _identityCodeRepository;
        protected readonly IHealthProgramRepository _healthProgramRepository;
        protected readonly IHttpContextAccessor _httpContext;
        protected readonly IStringMapRepository _stringMapRepository;
        protected readonly IDoctorByProgramRepository _doctorByProgRepository;
        protected readonly ITreatmentAndDiagnosticActionService _treatmentAndDiagnosticActionService;
        protected readonly ITreatmentRepository _treatmentRepository;
        protected readonly IExamRepository _examRepository;
        protected readonly IInfusionRepository _infusionRepository;
        protected readonly IExamDefinitionRepository _examDefinitionRepository;
        protected readonly IDiagnosticRepository _diagnosticRepository;
        protected readonly ILogisticStuffRepository _logisticStuffRepository;
        protected readonly IPurchaseRepository _purchaseRepository;
        protected readonly IAccountSettingsByProgramRepository _accountSettingsByProgramRepository;
        protected readonly IAnnotationRepository _annotationRepository;
        protected readonly IPatientRepository _patientRepository;
        protected readonly IEmailService _emailService;

        public VoucherService(
            IVoucherRepository voucherRepository,
            IVoucherConfigurationRepository voucherConfigurationRepository,
            IIdentityCodeRepository identityCodeRepository,
            IHealthProgramRepository healthProgramRepository,
            IHttpContextAccessor httpContext,
            IStringMapRepository stringMapRepository,
            IDoctorByProgramRepository doctorByProgRepository,
            ILogisticStuffRepository logisticStuffRepository,
            IPurchaseRepository purchaseRepository,
            IAccountSettingsByProgramRepository accountSettingsByProgramRepository,
            ITreatmentAndDiagnosticActionService treatmentAndDiagnosticActionService,
            ITreatmentRepository treatmentRepository,
            IDiagnosticRepository diagnosticRepository,
            IExamRepository examRepository,
            IInfusionRepository infusionRepository,
            IExamDefinitionRepository examDefinitionRepository,
            IAnnotationRepository annotationRepository,
            IPatientRepository patientRepository,
            IEmailService emailService)
        {
            _voucherRepository = voucherRepository;
            _voucherConfigurationRepository = voucherConfigurationRepository;
            _identityCodeRepository = identityCodeRepository;
            _healthProgramRepository = healthProgramRepository;
            _httpContext = httpContext;
            _stringMapRepository = stringMapRepository;
            _doctorByProgRepository = doctorByProgRepository;
            _treatmentAndDiagnosticActionService = treatmentAndDiagnosticActionService;
            _treatmentRepository = treatmentRepository;
            _examRepository = examRepository;
            _infusionRepository = infusionRepository;
            _examDefinitionRepository = examDefinitionRepository;
            _diagnosticRepository = diagnosticRepository;
            _logisticStuffRepository = logisticStuffRepository;
            _purchaseRepository = purchaseRepository;
            _accountSettingsByProgramRepository = accountSettingsByProgramRepository;
            _annotationRepository = annotationRepository;
            _patientRepository = patientRepository;
            _emailService = emailService;
        }

        public VoucherService(
            IVoucherRepository voucherRepository,
            IVoucherConfigurationRepository voucherConfigurationRepository,
            IIdentityCodeRepository identityCodeRepository)
        {
            _voucherRepository = voucherRepository;
            _voucherConfigurationRepository = voucherConfigurationRepository;
            _identityCodeRepository = identityCodeRepository;
        }

        public virtual ReturnMessage<Voucher> Add(VoucherModel voucher)
        {
            var entity = new Voucher()
            {
                Id = Guid.NewGuid(),
                TreatmentId = voucher.TreatmentId,
                DiagnosticId = voucher.DiagnosticId,
                HealthProgramId = voucher.HealthProgramId,
                VoucherConfigurationId = voucher.VoucherConfigurationId,
                VoucherStatusStringMapId = voucher.StatusStringMapId,
                SourceStringMapId = voucher.SourceStringMapId
            };

            var result = new ReturnMessage<Voucher>();
            VoucherConfiguration configuration = _voucherConfigurationRepository.GetValue(_ => _.Id == entity.VoucherConfigurationId.Value);

            if (configuration != null)
            {
                IdentityCode identityCode = null;
                string voucherCode = string.Empty;
                if (configuration.HasSequencialCode.HasValue && configuration.HasSequencialCode.Value)
                {
                    List<IdentityCode> identitiesList = _identityCodeRepository.GetIdentityCode(entity.VoucherConfigurationId.Value);
                    if (identitiesList.Count > 0)
                    {
                        identityCode = identitiesList[0];
                        voucherCode = GenerateRandomCodeWithSequentialValue(configuration.CodePattern, identityCode.SequentialValue);
                    }
                }
                else
                {
                    voucherCode = GenerateRandomCode(configuration.CodePattern);

                    var exist = _voucherRepository.GetVoucherByNumber(configuration.HealthProgramId.Value, voucherCode);

                    while (exist.Count() > 0)
                    {
                        voucherCode = GenerateRandomCode(configuration.CodePattern);
                        exist = _voucherRepository.GetVoucherByNumber(configuration.HealthProgramId.Value, voucherCode);
                    }
                }

                entity.Name = voucherCode;
                entity.Number = voucherCode;

                Repository.Validation.ValidationResult resultInsert = _voucherRepository.Insert(entity);

                if (resultInsert.IsValid && identityCode != null)
                {
                    string newIdentityValue = GenerateSequentialCode(identityCode.SequentialValue);
                    _identityCodeRepository.SetIdentityCode(configuration.Id, newIdentityValue);
                }

                result.Value = entity;
                return result;
            }
            else
            {
                result.AdditionalMessage = "Voucher Configuration not set.";
                result.IsValidData = false;
                return result;
            }
        }

        public virtual ReturnMessage<Voucher> AddAdmin(VoucherModel voucher)
        {
            throw new NotImplementedException();
        }

        public ReturnMessage<Voucher> Update(Voucher voucher)
        {
            var result = new ReturnMessage<Voucher>();
            var voucherUpdated = _voucherRepository.Update(voucher);

            if (voucherUpdated != null)
            {
                result.IsValidData = true;
                result.Value = voucherUpdated;
                return result;
            }

            return result;
        }

        public virtual ReturnMessage<bool> Update(VoucherModel voucher)
        {
            var healthProgramId = voucher.HealthProgramId != null
                ? voucher.HealthProgramId
                : _healthProgramRepository.GetValue(_ => _.Code == voucher.ProgramCode).Id;

            var voucherUpdate = _voucherRepository.GetValue(x => x.Id == voucher.Id && x.HealthProgramId == healthProgramId && !x.IsDeleted);
            if (voucherUpdate == null) return HelperReturnMessageBoolError("Voucher não encontrado");

            var voucherConfigurationUpdate = _voucherConfigurationRepository.GetValue(x => x.Id == voucherUpdate.VoucherConfigurationId && x.HealthProgramId == healthProgramId && !x.IsDeleted);
            if (voucherConfigurationUpdate == null) return HelperReturnMessageBoolError("VoucherConfiguration não encontrado");

            var userId = Guid.Parse(_httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            var userName = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            var calcDays = (voucher.DeadlineInDays ?? 0) - (voucherConfigurationUpdate.DeadlineInDays ?? 0);

            voucherUpdate.DiscountType = voucher.DiscountType;
            voucherUpdate.DiscountValue = voucher.DiscountValue;
            voucherUpdate.Note = voucher.Note;
            voucherUpdate.VoucherStatusStringMapId = voucher.StatusStringMapId ?? voucherUpdate.VoucherStatusStringMapId;
            voucherUpdate.SourceStringMapId = voucher.SourceStringMapId;
            voucherUpdate.ModifiedBy = userId;
            voucherUpdate.ModifiedByName = userName;
            voucherUpdate.TreatmentId = voucher.TreatmentId;
            voucherUpdate.DiagnosticId = voucher.DiagnosticId;
            voucherUpdate.StatusCodeStringMapId = voucher.StatusStringMapId;
            voucherUpdate.SourceStringMapId = voucher.SourceStringMapId;
            voucherUpdate.DueDate = voucherUpdate.DueDate != null ? voucherUpdate.DueDate.Value.AddDays(calcDays) : DateTime.Now.AddDays(voucher.DeadlineInDays ?? 0);

            voucherUpdate = _voucherRepository.Update(voucherUpdate);
            if (voucherUpdate == null) return HelperReturnMessageBoolError("Erro ao alterar o voucher");

            voucherConfigurationUpdate.Name = voucher.Name;
            voucherConfigurationUpdate.DeadlineInDays = voucher.DeadlineInDays;
            voucherConfigurationUpdate.ModifiedBy = userId;
            voucherConfigurationUpdate.ModifiedByName = userName;

            voucherConfigurationUpdate = _voucherConfigurationRepository.Update(voucherConfigurationUpdate);
            if (voucherConfigurationUpdate == null) return HelperReturnMessageBoolError("Erro ao alterar o voucherConfiguration");

            return new ReturnMessage<bool>
            {
                Value = true,
                IsValidData = true,
            };
        }

        public ReturnMessage<bool> Delete(Guid voucherId, string programCode)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var userId = Guid.Parse(_httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            var userName = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            var voucherUpdate = _voucherRepository.GetValue(x => x.Id == voucherId && x.HealthProgramId == healthProgramId && !x.IsDeleted);
            if (voucherUpdate == null) return HelperReturnMessageBoolError("Voucher não encontrado");

            var childVouchers = _voucherRepository.Find(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.InternalControl == voucherId.ToString());

            var voucherConfigurationUpdate = _voucherConfigurationRepository.GetValue(x => x.Id == voucherUpdate.VoucherConfigurationId && x.HealthProgramId == healthProgramId && !x.IsDeleted);
            if (voucherConfigurationUpdate == null) return HelperReturnMessageBoolError("VoucherConfiguration não encontrado");
            var voucherStatusStringMap = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#CANCELED" && x.ProgramId == healthProgramId);

            voucherUpdate.IsDeleted = true;
            voucherUpdate.DeletedBy = userId;
            voucherUpdate.DeletedByName = userName;
            voucherUpdate.DeletedOn = DateTime.UtcNow;
            voucherUpdate.VoucherStatusStringMapId = voucherStatusStringMap?.StringMapId;
            voucherUpdate = _voucherRepository.Update(voucherUpdate);
            if (voucherUpdate == null) return HelperReturnMessageBoolError("Erro ao alterar o voucher");

            foreach (var childVoucher in childVouchers)
            {
                childVoucher.IsDeleted = true;
                childVoucher.DeletedBy = userId;
                childVoucher.DeletedByName = userName;
                childVoucher.DeletedOn = DateTime.UtcNow;
                childVoucher.VoucherStatusStringMapId = voucherStatusStringMap?.StringMapId;
                _voucherRepository.Update(childVoucher);
            }

            voucherConfigurationUpdate.IsDeleted = true;
            voucherConfigurationUpdate.DeletedBy = userId;
            voucherConfigurationUpdate.DeletedByName = userName;
            voucherConfigurationUpdate.DeletedOn = DateTime.UtcNow;
            voucherConfigurationUpdate = _voucherConfigurationRepository.Update(voucherConfigurationUpdate);
            if (voucherConfigurationUpdate == null) return HelperReturnMessageBoolError("Erro ao alterar o voucherConfiguration");

            return new ReturnMessage<bool>
            {
                Value = true,
                IsValidData = true,
            };
        }

        public virtual async Task<ReturnMessage<string>> ValidateVoucher(VoucherValidateModel voucher)
        {
            ReturnMessage<string> result = new ReturnMessage<string>();

            var voucherFind = _voucherRepository.Find(v => v.Name == voucher.Name
            && v.IsDeleted == false).FirstOrDefault();

            if (voucherFind != null)
            {
                result.IsValidData = true;
                result.Value = "200";
                return result;
            }
            else
            {
                result.IsValidData = false;
                result.Value = "Voucher não encontrado.";
                result.AdditionalMessage = "200";
                return result;
            }
        }

        public Task<ReturnMessage<List<string>>> GetVoucherTypes(string programCode)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var voucherDiscountTypes = _voucherRepository
                .Find(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.InternalControl == null)
                .Select(x => x.DiscountType)
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .Order()
                .ToList();

            return System.Threading.Tasks.Task.FromResult(new ReturnMessage<List<string>>
            {
                Value = voucherDiscountTypes as List<string>,
                IsValidData = true
            });
        }

        public virtual Task<ReturnMessage<List<OptionResultModel<Guid>>>> GetVoucherStatus(string programCode)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var voucherStatusStringMaps = _stringMapRepository.Find(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.ProgramId == healthProgramId);

            var listValidStatus = new List<string>
            {
                "#ISSUED",
                "#EXPIRED",
                "#CANCELED",
                "#UTILIZED",
                "#PENDING"
            };
            var dictionaryLabel = new Dictionary<string, string>();
            dictionaryLabel.Add("#ISSUED", "VÁLIDO");
            dictionaryLabel.Add("#EXPIRED", "EXPIRADO");
            dictionaryLabel.Add("#CANCELED", "CANCELADO");
            dictionaryLabel.Add("#UTILIZED", "UTILIZADO");
            dictionaryLabel.Add("#PENDING", "RESGATADO");

            var data = voucherStatusStringMaps
                        .Where(x => listValidStatus.Contains(x.Flag ?? ""))
                        .Select(x => new OptionResultModel<Guid>
                        {
                            Value = x.StringMapId,
                            Label = dictionaryLabel.GetValueOrDefault(x.Flag ?? "") ?? ""
                        })
                        .ToList();

            return System.Threading.Tasks.Task.FromResult(new ReturnMessage<List<OptionResultModel<Guid>>>
            {
                Value = data,
                IsValidData = true
            });
        }
        public async Task<ReturnMessage<string>> GetDiseaseMessage(Guid treatmentId)
        {
            throw new NotImplementedException();
        }
        public async Task<ReturnMessage<string>> VerifyAllowedExams(Guid treatmentId, Guid examDefinitionId)
        {
            throw new NotImplementedException();
        }
        public async Task<ReturnMessage<List<VoucherResultModel>>> List(string programCode, string? voucherTypes = null, Guid? status = null, int? deadlineInDays = null)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var voucherQuery = _voucherRepository
                .Queryable()
                .AsNoTracking()
                .Include(x => x.VoucherConfiguration)
                .Where(x => x.HealthProgramId == healthProgramId && x.InternalControl == null);

            if (!string.IsNullOrEmpty(voucherTypes))
                voucherQuery = voucherQuery.Where(x => x.DiscountType.ToUpper() == voucherTypes.ToUpper());

            if (status != null && status != Guid.Empty)
            {
                var canceledStatus = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#CANCELED" && x.ProgramId == healthProgramId);
                var expiredStatus = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#EXPIRED" && x.ProgramId == healthProgramId);

                if (canceledStatus.StringMapId != status && expiredStatus.StringMapId != status)
                    voucherQuery = voucherQuery.Where(x => !x.IsDeleted);

                if (status == expiredStatus.StringMapId)
                    voucherQuery = voucherQuery.Where(x => x.DueDate < DateTime.Now);
                else
                    voucherQuery = voucherQuery.Where(x => x.VoucherStatusStringMapId == status && x.DueDate >= DateTime.Now);
            }
            if (deadlineInDays != null && deadlineInDays != 0)
                voucherQuery = voucherQuery.Where(x => x.VoucherConfiguration.DeadlineInDays == deadlineInDays);

            var voucherData = await voucherQuery.ToListAsync();

            var resultData = voucherData.Select(x => new VoucherResultModel
            {
                DeadlineInDays = x.VoucherConfiguration?.DeadlineInDays,
                DiscountType = x.DiscountType,
                DueDate = x.DueDate,
                Id = x.Id,
                Number = x.Number,
                Status = x.VoucherStatusStringMapId,
                CreatedDate = x.CreatedOn,
                DiscountValue = x.DiscountValue,
                Name = x.VoucherConfiguration?.Name,
                Note = x.Note
            }).ToList();

            return new ReturnMessage<List<VoucherResultModel>>
            {
                Value = resultData,
                IsValidData = true
            };
        }

        public async Task<ReturnMessage<DiagnosticVoucherResultModel>> ListByPatient(string programCode, string cpf, Guid? status = null)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var voucherStatusStringMap = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#UTILIZED" && x.ProgramId == healthProgramId);
            var diagnostic = _diagnosticRepository.GetValue(x => x.HealthProgramId == healthProgramId && x.Cpf == cpf && !x.IsDeleted);

            if (diagnostic == null)
                return new ReturnMessage<DiagnosticVoucherResultModel> { IsValidData = false, AdditionalMessage = "Diagnostic não encontrado!" };

            var voucherHistoryQuery = await _voucherRepository
                .Queryable()
                .AsNoTracking()
                .Include(x => x.VoucherConfiguration)
                .Include(x => x.Account)
                .Where(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.DiagnosticId == diagnostic.Id && x.VoucherStatusStringMapId == voucherStatusStringMap.StringMapId)
                .OrderByDescending(x => x.UseDate)
                .ToListAsync();

            var voucherQuery = _voucherRepository
                .Queryable()
                .AsNoTracking()
                .Include(x => x.VoucherConfiguration)
                .Where(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.DiagnosticId == diagnostic.Id);

            if (status != null && status != Guid.Empty)
            {
                var voucherStatusStringMaps = _stringMapRepository.Find(x => x.AttributeMetadataIdName == "VoucherStatusStringMap");

                if (status == voucherStatusStringMaps.FirstOrDefault(x => x.Flag == "#EXPIRED" && x.ProgramId == healthProgramId)?.StringMapId)
                    voucherQuery = voucherQuery.Where(x => x.DueDate < DateTime.Now);
                else
                    voucherQuery = voucherQuery.Where(x => x.VoucherStatusStringMapId == status && x.DueDate >= DateTime.Now);
            }

            var voucherData = await voucherQuery.ToListAsync();

            var resultVoucherData = voucherData.Select(x => new VoucherResultModel
            {
                DeadlineInDays = x.VoucherConfiguration?.DeadlineInDays,
                DiscountType = x.DiscountType,
                DueDate = x.DueDate,
                Id = x.Id,
                Number = x.Number,
                Status = x.VoucherStatusStringMapId,
                CreatedDate = x.CreatedOn,
                DiscountValue = x.DiscountValue,
            }).ToList();

            var resultVoucherHistoryData = voucherHistoryQuery.Select(x => new VoucherUtilizedHistoryResultModel
            {
                UseDate = x.UseDate,
                DeadlineInDays = x.VoucherConfiguration?.DeadlineInDays,
                DiscountType = x.DiscountType,
                Number = x.Number,
                Locality = x.Account?.Name,
                DiscountValue = x.DiscountValue
            }).ToList();

            var resultData = new DiagnosticVoucherResultModel
            {
                Id = diagnostic.Id,
                Name = diagnostic.FullName,
                Cpf = diagnostic.Cpf,
                Email = diagnostic.EmailAddress1,
                Vouchers = resultVoucherData,
                UtilizedHistory = resultVoucherHistoryData
            };

            return new ReturnMessage<DiagnosticVoucherResultModel>
            {
                Value = resultData,
                IsValidData = true
            };
        }

        public async Task<ReturnMessage<VoucherResulmeResult>> GetResulme(string programCode, string? voucherTypes = null, Guid? status = null, int? deadlineInDays = null)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var voucherQuery = _voucherRepository
                .Queryable()
                .AsNoTracking()
                .Include(x => x.VoucherConfiguration)
                .Where(x => x.HealthProgramId == healthProgramId && x.InternalControl != null && !x.IsDeleted);

            var statuses = _stringMapRepository.Find(x => x.AttributeMetadataId == Guid.Parse("652AAE06-B147-4A19-8994-8A12ECE0BFC2"));
            if (statuses == null) return new ReturnMessage<VoucherResulmeResult> { IsValidData = false, AdditionalMessage = "Statuses not found!" };

            if (!string.IsNullOrEmpty(voucherTypes))
                voucherQuery = voucherQuery.Where(x => x.DiscountType.ToUpper() == voucherTypes.ToUpper());

            if (status != null && status != Guid.Empty)
            {
                if (status == statuses.FirstOrDefault(x => x.Flag == "#EXPIRED" && x.ProgramId == healthProgramId)?.StringMapId) voucherQuery = voucherQuery.Where(x => x.DueDate < DateTime.Now);
                else voucherQuery = voucherQuery.Where(x => x.VoucherStatusStringMapId == status && x.DueDate >= DateTime.Now);
            }
            if (deadlineInDays != null && deadlineInDays != 0)
                voucherQuery = voucherQuery.Where(x => x.VoucherConfiguration.DeadlineInDays == deadlineInDays);

            var voucherData = await voucherQuery
                .Select(x => new Voucher
                {
                    DueDate = x.DueDate,
                    VoucherStatusStringMapId = x.VoucherStatusStringMapId
                })
                .ToListAsync();

            var result = new VoucherResulmeResult
            {
                Expired = voucherData.Count(x => DateTime.Now > x.DueDate && x.VoucherStatusStringMapId == statuses.FirstOrDefault(x => x.Flag == "#EXPIRED" && x.ProgramId == healthProgramId)?.StringMapId),
                Ransomed = voucherData.Count(x => x.VoucherStatusStringMapId == statuses.FirstOrDefault(x => x.Flag == "#PENDING" && x.ProgramId == healthProgramId)?.StringMapId),
                ToRescue = voucherData.Count(x => x.VoucherStatusStringMapId == statuses.FirstOrDefault(x => x.Flag == "#ISSUED" && x.ProgramId == healthProgramId)?.StringMapId && x.DueDate >= DateTime.Now),
                Used = voucherData.Count(x => x.VoucherStatusStringMapId == statuses.FirstOrDefault(x => x.Flag == "#UTILIZED" && x.ProgramId == healthProgramId)?.StringMapId),
            };

            return new ReturnMessage<VoucherResulmeResult>
            {
                Value = result,
                IsValidData = true
            };
        }

        public async Task<ReturnMessage<List<DiagnosticVoucherResultModel>>> ListAllPatient(string programCode)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;

            var diagnosticData = await _voucherRepository
                .Queryable()
                .AsNoTracking()
                .Include(x => x.Diagnostic)
                .Where(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.InternalControl != null && x.DiagnosticId != null)
                .ToListAsync();

            var resultData = diagnosticData?.Select(x => new DiagnosticVoucherResultModel
            {
                Id = x.Diagnostic?.Id ?? Guid.Empty,
                Cpf = x.Diagnostic?.Cpf,
                Email = x.Diagnostic?.EmailAddress1,
                Name = x.Diagnostic?.FullName,
                CreatedOn = x.Diagnostic?.CreatedOn
            })
            .DistinctBy(x => x.Id)
            .ToList();

            return new ReturnMessage<List<DiagnosticVoucherResultModel>>
            {
                Value = resultData,
                IsValidData = true
            };
        }

        public ReturnMessage<bool> Rescue(Guid voucherId, string programCode)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var voucher = _voucherRepository.GetValue(x => x.HealthProgramId == healthProgramId && x.Id == voucherId);
            if (voucher == null)
            {
                return new ReturnMessage<bool>
                {
                    IsValidData = false,
                    AdditionalMessage = "Voucher not found!"
                };
            }

            var voucherActiveStatusId = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#ISSUED" && x.ProgramId == healthProgramId)?.StringMapId;
            if (voucher.VoucherStatusStringMapId != voucherActiveStatusId || voucher.DueDate < DateTime.Now)
            {
                return new ReturnMessage<bool>
                {
                    IsValidData = false,
                    AdditionalMessage = "Invalid operation!"
                };
            }

            var voucherPendingStatusId = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#PENDING" && x.ProgramId == healthProgramId)?.StringMapId;

            voucher.VoucherStatusStringMapId = voucherPendingStatusId;
            _voucherRepository.Update(voucher);

            var diagnostic = _diagnosticRepository.GetValue(x => x.Id == voucher.DiagnosticId);
            var patient = _patientRepository.GetValue(x => x.Id == diagnostic.PatientId);

            _emailService.MergeTemplateMail<Patient>(
                Patient.EntityName,
                Patient.EntityTypeCode,
                "#VOUCHER_RESGATADO_COM_SUCESSO",
                patient.Id,
                healthProgramId,
                true,
                patient.EmailAddress1!,
                bodyReplace: new Dictionary<string, string> { ["[NOME_PACIENTE]"] = patient.FullName! });

            return new ReturnMessage<bool>
            {
                IsValidData = true,
                Value = true
            };
        }

        public ReturnMessage<bool> Use(Guid voucherId, string programCode, string purchaseGroupCode)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;

            var voucher = _voucherRepository.GetValue(x => x.HealthProgramId == healthProgramId && x.Id == voucherId);
            if (voucher == null)
                return new ReturnMessage<bool> { IsValidData = false, AdditionalMessage = "Voucher not found!" };

            var voucherPendingStatusId = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#PENDING" && x.ProgramId == healthProgramId)?.StringMapId;
            if (voucher.VoucherStatusStringMapId != voucherPendingStatusId || voucher.DueDate < DateTime.Now)
                return new ReturnMessage<bool> { IsValidData = false, AdditionalMessage = "Invalid operation!" };

            var voucherUtilizedStatusId = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#UTILIZED" && x.ProgramId == healthProgramId)?.StringMapId;
            var userId = Guid.Parse(_httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.SystemUserId == userId);

            voucher.VoucherStatusStringMapId = voucherUtilizedStatusId;
            voucher.FriendlyCode = purchaseGroupCode.ToString();
            voucher.UseDate = DateTime.Now;
            voucher.AccountId = accountSettingsByProgram.AccountId;
            _voucherRepository.Update(voucher);

            return new ReturnMessage<bool>
            {
                IsValidData = true,
                Value = true
            };
        }

        public async Task<ReturnMessage<DiagnosticVoucherResultModel>> ListByPatientRescue(string programCode, string cpf)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var diagnostic = _diagnosticRepository.GetValue(x => x.HealthProgramId == healthProgramId && x.Cpf == cpf && !x.IsDeleted);

            if (diagnostic == null)
                return new ReturnMessage<DiagnosticVoucherResultModel> { IsValidData = false, AdditionalMessage = "Diagnostic não encontrado!" };

            var voucherStatusPendingId = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#PENDING" && x.ProgramId == healthProgramId).StringMapId;

            var voucherData = await _voucherRepository
                .Queryable()
                .AsNoTracking()
                .Include(x => x.VoucherConfiguration)
                .Where(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.DiagnosticId == diagnostic.Id && x.VoucherStatusStringMapId == voucherStatusPendingId)
                .ToListAsync();

            var resultVoucherData = voucherData.Select(x => new VoucherResultModel
            {
                DeadlineInDays = x.VoucherConfiguration?.DeadlineInDays,
                DiscountType = x.DiscountType,
                DueDate = x.DueDate,
                Id = x.Id,
                Number = x.Number,
                Status = x.VoucherStatusStringMapId,
                CreatedDate = x.CreatedOn,
                DiscountValue = x.DiscountValue,
            }).ToList();

            var resultData = new DiagnosticVoucherResultModel
            {
                Id = diagnostic.Id,
                Name = diagnostic.FullName,
                Cpf = diagnostic.Cpf,
                Email = diagnostic.EmailAddress1,
                Vouchers = resultVoucherData,
            };

            return new ReturnMessage<DiagnosticVoucherResultModel>
            {
                Value = resultData,
                IsValidData = true
            };
        }

        public async Task<ReturnMessage<List<ResumeUsedVoucherModel>>> ResumeUsedVoucher(string programCode)
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var voucherStatusStringMap = _stringMapRepository.GetValue(x => x.AttributeMetadataIdName == "VoucherStatusStringMap" && x.Flag == "#UTILIZED" && x.ProgramId == healthProgramId);
            var vouchers = _voucherRepository.Find(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.VoucherStatusStringMapId == voucherStatusStringMap.StringMapId && x.FriendlyCode != null);
            var resultData = new List<ResumeUsedVoucherModel>();
            var userId = Guid.Parse(_httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.SystemUserId == userId);

            if (vouchers != null && vouchers.Count == 0)
            {
                return new ReturnMessage<List<ResumeUsedVoucherModel>>
                {
                    IsValidData = true,
                    Value = resultData
                };
            }

            var products = await _logisticStuffRepository
                .Queryable()
                .Select(x => new LogisticsStuff
                {
                    Id = x.Id,
                    HealthProgramId = x.HealthProgramId,
                    CodeNumber = x.CodeNumber,
                    IsDeleted = x.IsDeleted
                })
                .Where(x => x.HealthProgramId == healthProgramId && !x.IsDeleted)
                .ToListAsync();

            foreach (var voucher in vouchers)
            {
                var purchases = accountSettingsByProgram == null
                    ? _purchaseRepository.Find(x => x.HealthProgramId == healthProgramId && x.ImportCode == voucher.FriendlyCode)
                    : _purchaseRepository.Find(x => x.HealthProgramId == healthProgramId && x.ImportCode == voucher.FriendlyCode && x.CreatedBy == userId);
                var purchaseDictionary = new Dictionary<string, int>();

                foreach (var purchase in purchases)
                {
                    var productCode = products.FirstOrDefault(x => x.Id.ToString() == purchase.InternalControl).CodeNumber;

                    if (purchaseDictionary.GetValueOrDefault(productCode) != 0)
                        purchaseDictionary[productCode] = purchaseDictionary[productCode] + 1;
                    else
                        purchaseDictionary[productCode] = 1;
                }

                foreach (var key in purchaseDictionary.Keys)
                {
                    resultData.Add(new ResumeUsedVoucherModel
                    {
                        Amount = purchaseDictionary[key],
                        Product = key,
                        Type = "COMBO3+1",
                        Voucher = voucher.Number,
                        Date = voucher.CreatedOn.Value
                    });
                }
            }

            return new ReturnMessage<List<ResumeUsedVoucherModel>>
            {
                IsValidData = true,
                Value = resultData
            };
        }

        public async Task<bool> LinkVouchersToNewUser(Diagnostic diagnostic)
        {
            var vouchers = await _voucherRepository
                .Queryable()
                .Include(x => x.VoucherConfiguration)
                .Where(x => x.HealthProgramId == diagnostic.HealthProgramId && x.DueDate > DateTime.Now && !x.IsDeleted && x.InternalControl == null)
                .ToListAsync();

            var voucherNumbersRegistered = _voucherRepository
                .Queryable()
                .Where(x => x.HealthProgramId == diagnostic.HealthProgramId)
                .Select(x => x.Number)
                .ToList();
            var voucherList = new List<Voucher>();

            foreach (var voucher in vouchers)
            {
                var newVoucherCode = this.GetVoucherNumber(voucher.VoucherConfiguration?.CodePattern, voucherNumbersRegistered);
                var newVoucher = new Voucher
                {
                    Id = Guid.NewGuid(),
                    HealthProgramId = diagnostic.HealthProgramId,
                    VoucherConfigurationId = voucher.VoucherConfigurationId,
                    VoucherStatusStringMapId = voucher.VoucherStatusStringMapId,
                    SourceStringMapId = voucher.SourceStringMapId,
                    DiscountType = voucher.DiscountType,
                    DiscountValue = voucher.DiscountValue,
                    Note = voucher.Note,
                    DueDate = voucher.DueDate,
                    CreatedBy = voucher.CreatedBy,
                    ModifiedBy = voucher.ModifiedBy,
                    CreatedByName = voucher.CreatedByName,
                    ModifiedByName = voucher.ModifiedByName,
                    InternalControl = voucher.Id.ToString(),
                    Name = newVoucherCode,
                    Number = newVoucherCode,
                    DiagnosticId = diagnostic.Id,
                    CreatedOn = DateTime.Now,
                };

                voucherList.Add(newVoucher);
            }

            _voucherRepository.Insert(voucherList);

            return true;
        }

        public virtual async Task<VoucherModel> ValidateVoucherDoctor(VoucherValidateModel voucher)
        {
            VoucherModel voucherModel = new VoucherModel();

            var healthProgram = _healthProgramRepository.Find(h => h.Code == voucher.ProgramCode).FirstOrDefault();

            var voucherFind = _voucherRepository.GetVoucherByName(healthProgram.Id, voucher.Name);

            if (voucherFind != null)
            {
                voucherModel.DoctorLicenseNumber = voucherFind.Doctor.LicenseNumber;
                voucherModel.DoctorLicenseState = voucherFind.Doctor.LicenseState;
                voucherModel.DoctorName = voucherFind.Doctor.FullName;
                voucherModel.VoucherIsValid = true;
            }
            else
            {
                voucherModel.DoctorLicenseNumber = string.Empty;
                voucherModel.DoctorLicenseState = string.Empty;
                voucherModel.DoctorName = string.Empty;
                voucherModel.VoucherIsValid = false;
            }

            return voucherModel;
        }

        protected string GenerateRandomCodeWithSequentialValue(string fullCodePattern, string lastSequentialCode)
        {
            int sequentialInitialPosition = fullCodePattern.IndexOf('0');
            int sequentialLastPosition = fullCodePattern.LastIndexOf('0');

            string newSequentialCode = GenerateSequentialCode(lastSequentialCode);

            string newCodeWithoutSequentialValue = GenerateRandomCode(fullCodePattern);
            string newCodeWithSequentialValue = String.Empty;

            newCodeWithSequentialValue = newSequentialCode;

            return newCodeWithSequentialValue;
        }

        protected string GenerateSequentialCode(string lastSequentialCode)
        {
            int sequentialInt = int.Parse(lastSequentialCode);
            sequentialInt++;

            string result = sequentialInt.ToString();

            string zeros = String.Empty;
            for (int a = 0; a < lastSequentialCode.Length; a++)
            {
                zeros += "0";
            }
            result = zeros + result;
            return result.Substring(result.Length - lastSequentialCode.Length);
        }

        protected static string GenerateRandomCode(string fullCodePattern)
        {
            string randomCode = String.Empty;
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            foreach (char c in fullCodePattern)
            {
                switch (c)
                {
                    case '9':
                        char newNumber = GenerateNumericCharacter(crypto);
                        randomCode += newNumber.ToString();
                        break;
                    case '@':
                        char newLetter = GenerateLetterCharacter(crypto);
                        randomCode += newLetter.ToString();
                        break;
                    case '#':
                        char newAlphanumericChar = GenerateAlphanumericCharacter(crypto);
                        randomCode += newAlphanumericChar.ToString();
                        break;
                    default:
                        randomCode += c.ToString();
                        break;
                }
            }

            return randomCode;
        }

        protected static char GenerateNumericCharacter(RNGCryptoServiceProvider crypto)
        {
            char[] chars = new char[10];
            string a;
            a = "1234567890";
            chars = a.ToCharArray();

            byte[] data = new byte[1];

            crypto.GetNonZeroBytes(data);

            return (char)(chars[data[0] % (chars.Length)]);
        }

        protected static char GenerateLetterCharacter(RNGCryptoServiceProvider crypto)
        {
            string a;

            char[] chars = new char[26];
            a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            chars = a.ToCharArray();

            byte[] data = new byte[1];

            crypto.GetNonZeroBytes(data);

            return (char)(chars[data[0] % (chars.Length)]);
        }

        protected static char GenerateAlphanumericCharacter(RNGCryptoServiceProvider crypto)
        {
            string a;

            char[] chars = new char[36];
            a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            chars = a.ToCharArray();

            byte[] data = new byte[1];

            crypto.GetNonZeroBytes(data);

            return (char)(chars[data[0] % (chars.Length)]);
        }

        public DateTime DateTimeNow()
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeZoneInfo horaBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, horaBrasilia);
        }

        protected ReturnMessage<bool> HelperReturnMessageBoolError(string message) =>
            new ReturnMessage<bool>() { Value = false, IsValidData = false, AdditionalMessage = message };

        protected string GetVoucherNumber(string codePattern, List<string> voucherNumbersRegistered)
        {
            var voucherCode = "";
            var exist = true;

            while (exist)
            {
                voucherCode = GenerateRandomCode(codePattern);
                exist = voucherNumbersRegistered.Count(x => x == voucherCode) > 0;
            }

            return voucherCode;
        }

        public Task<bool> VerifyAllowedExams(Guid treatmentId)
        {
            throw new NotImplementedException();
        }

        public Guid GenerateVoucher(string voucherConfigurationCode)
        {
            var configuration = _voucherConfigurationRepository.GetValue(_ => _.ImportCode == voucherConfigurationCode);
            var entity = new Voucher();

            IdentityCode identityCode = null;
            string voucherCode = string.Empty;
            if (configuration.HasSequencialCode.HasValue && configuration.HasSequencialCode.Value)
            {

                List<IdentityCode> identitiesList = _identityCodeRepository.GetIdentityCode(configuration.Id);
                if (identitiesList.Count > 0)
                {
                    identityCode = identitiesList[0];
                    voucherCode = GenerateRandomCodeWithSequentialValue(configuration.CodePattern, identityCode.SequentialValue);
                }
            }
            else
            {
                voucherCode = GenerateRandomCode(configuration.CodePattern);

                var exist = _voucherRepository.GetVoucherByNumber(configuration.HealthProgramId.Value, voucherCode);

                while (exist.Count() > 0)
                {
                    voucherCode = GenerateRandomCode(configuration.CodePattern);
                    exist = _voucherRepository.GetVoucherByNumber(configuration.HealthProgramId.Value, voucherCode);
                }
            }

            entity.Id = Guid.NewGuid();
            entity.Name = voucherCode;
            entity.Number = voucherCode;
            entity.SourceStringMapId = Guid.Parse("F5112DA2-D610-4748-B358-9B62B396A275");
            entity.VoucherConfigurationId = configuration.Id;
            entity.VoucherStatusStringMapId = Guid.Parse("6B820A03-0DA0-4E09-8948-452E4EADAC1C");
            entity.CreatedOn = DateTime.Now;
            entity.ModifiedOn = DateTime.Now;
            entity.CreatedBy = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
            entity.CreatedByName = "Admin";
            entity.ModifiedBy = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
            entity.ModifiedByName = "Admin";
            entity.IsDeleted = false;
            entity.OwnerId = Guid.Parse("6B93EA3E-0AC5-4B4D-8E88-06A77736C785");
            entity.OwnerIdName = "Admin";
            entity.StateCode = true;
            entity.StatusCodeStringMapId = Guid.Parse("1D9D1E5A-A670-4DD9-BC3E-DCDA6804FAB6");
            entity.HealthProgramId = configuration.HealthProgramId.Value;
            entity.FriendlyCode = voucherCode;
            entity.ImportCode = voucherCode;

            var result = _voucherRepository.Insert(entity);

            if (result.IsValid && identityCode != null)
            {
                string newIdentityValue = GenerateSequentialCode(identityCode.SequentialValue);
                _identityCodeRepository.SetIdentityCode(configuration.Id, newIdentityValue);
            }

            return entity.Id;
        }

        public virtual Task<ReturnMessage<string>> Add(TreatmentAndExamModel model)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ReturnMessage<string>> AddVoucherAdmin(TreatmentAndExamModel model)
        {
            throw new NotImplementedException();
        }
    }
}
