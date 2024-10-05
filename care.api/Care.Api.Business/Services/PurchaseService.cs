using System.Security.Claims;
using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Business.Services;

public class PurchaseService : IPurchaseService
{
    protected readonly IHealthProgramRepository _healthProgramRepository;
    protected readonly IHttpContextAccessor _httpContext;
    protected readonly ILogisticStuffRepository _logisticStuffRepository;
    protected readonly IAccountSettingsByProgramRepository _accountSettingsByProgramRepository;
    protected readonly IPurchaseRepository _purchaseRepository;
    protected readonly IAttachmentRepository _attachmentRepository;
    protected readonly IVoucherService _voucherService;
    protected readonly IVoucherRepository _voucherRepository;
    protected readonly IDiagnosticRepository _diagnosticRepository;
    protected readonly IPatientRepository _patientRepository;
    protected readonly IEmailService _emailService;
    protected readonly IRegardingEntityRepository _regardingEntityRepository;

    public PurchaseService(
        IHealthProgramRepository healthProgramRepository,
        IHttpContextAccessor httpContext,
        ILogisticStuffRepository logisticStuffRepository,
        IAccountSettingsByProgramRepository accountSettingsByProgramRepository,
        IPurchaseRepository purchaseRepository,
        IAttachmentRepository attachmentRepository,
        IVoucherService voucherService,
        IVoucherRepository voucherRepository,
        IDiagnosticRepository diagnosticRepository,
        IPatientRepository patientRepository,
        IEmailService emailService,
        IRegardingEntityRepository regardingEntityRepository)
    {
        _healthProgramRepository = healthProgramRepository;
        _httpContext = httpContext;
        _logisticStuffRepository = logisticStuffRepository;
        _accountSettingsByProgramRepository = accountSettingsByProgramRepository;
        _purchaseRepository = purchaseRepository;
        _attachmentRepository = attachmentRepository;
        _voucherService = voucherService;
        _voucherRepository = voucherRepository;
        _diagnosticRepository = diagnosticRepository;
        _patientRepository = patientRepository;
        _emailService = emailService;
        _regardingEntityRepository = regardingEntityRepository;
    }

    public ReturnMessage<List<PurchaseResultModel>> List(string programCode)
    {
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
        var userId = Guid.Parse(_httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
        var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.SystemUserId == userId);

        var purchases = _purchaseRepository.Find(x => x.HealthProgramId == healthProgramId && x.AccountId == accountSettingsByProgram.AccountId && !x.IsDeleted && x.EntityOriginalValues == "#SALES_ORDER");
        var resultModel = new List<PurchaseResultModel>();
        if (purchases == null)
        {
            return new ReturnMessage<List<PurchaseResultModel>>
            {
                Value = resultModel,
                IsValidData = false
            };
        }

        purchases.ForEach(item =>
        {
            if (resultModel.Any(x => x.GroupCode == item.ImportCode))
            {
                resultModel.First(x => x.GroupCode == item.ImportCode).Items!.Add(new PurchaseItemResultModel
                {
                    ProductId = item.InternalControl ?? "",
                    ProductName = item.Observations ?? "",
                    Ean = item.Lot ?? "",
                    Amount = item.Amount ?? 0,
                });
            }
            else
            {
                resultModel.Add(new PurchaseResultModel
                {
                    GroupCode = item.ImportCode ?? "",
                    Identifier = item.Identifier ?? "",
                    PointOfPurchase = item.Name ?? "",
                    Cnpj = accountSettingsByProgram.Cnpj ?? "",
                    Items = new List<PurchaseItemResultModel>
                    {
                        new PurchaseItemResultModel
                        {
                            ProductId = item.InternalControl ?? "",
                            ProductName = item.Observations ?? "",
                            Ean = item.Lot ?? "",
                            Amount = item.Amount ?? 0,
                        }
                    }
                });
            }
        });

        resultModel = resultModel.OrderBy(x => int.Parse(x.Identifier)).ToList();

        return new ReturnMessage<List<PurchaseResultModel>>
        {
            IsValidData = true,
            Value = resultModel
        };
    }

    public ReturnMessage<List<PurchaseBonusResultModel>> ListBonus(string programCode)
    {
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
        var userId = Guid.Parse(_httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
        var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.SystemUserId == userId);
        var itemsBonus = _logisticStuffRepository.Find(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.OwnerId == accountSettingsByProgram.AccountId);

        var resultModel = itemsBonus?.Select(item => new PurchaseBonusResultModel
        {
            Amount = item.AvailableQuantity ?? 0,
            ProductName = (item.Packing ?? "").Trim(),
            Id = (item.CodeNumber ?? "").Trim()
        }).ToList();

        return new ReturnMessage<List<PurchaseBonusResultModel>>
        {
            IsValidData = true,
            Value = resultModel
        };
    }

    public async Task<ReturnMessage<object>> Add(PurchaseCreateModel model, Guid userId)
    {
        if (model.Items == null || model.Items.Count == 0 || model.Items.Sum(x => x.Amount) != 4)
            return new ReturnMessage<object>
            {
                IsValidData = false,
                AdditionalMessage = "Invalid data!"
            };

        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == model.ProgramCode).Id;
        var userName = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
        var groupCode = Guid.NewGuid().ToString();
        var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.SystemUserId == userId);

        if (accountSettingsByProgram == null)
            return new ReturnMessage<object> { IsValidData = false, AdditionalMessage = "AccountSettingsByProgram not found!" };

        var lastPurchase = await _purchaseRepository
            .Queryable()
            .AsNoTracking()
            .Where(x => x.HealthProgramId == healthProgramId)
            .OrderByDescending(x => x.CreatedOn)
            .FirstOrDefaultAsync();

        var purchaseNumber = lastPurchase == null || lastPurchase.Identifier == null ? "1" : (int.Parse(lastPurchase.Identifier) + 1).ToString();
        var purchases = new List<Purchase>();
        var inventories = new List<LogisticsStuff>();
        var purchaseDate = DateTime.Now;
        var products = _logisticStuffRepository.Find(x => model.Items.Select(x => x.ProductId).Contains(x.Id));
        LogisticsStuff? bonusLogisticsStuff = null;
        if (products.Count != model.Items.Count)
            return new ReturnMessage<object> { IsValidData = false, AdditionalMessage = "Invalid products!" };

        var resultVoucher = _voucherService.Use(model.VoucherId, model.ProgramCode, groupCode);
        if (!resultVoucher.IsValidData)
            return new ReturnMessage<object> { IsValidData = false, AdditionalMessage = "Error to use voucher!" };

        if (model.Items.Count == 2)
        {
            var firstItem = products.First(x => x.Id == model.Items.First().ProductId);
            var secondItem = products.First(x => x.Id == model.Items.Last().ProductId);
            var leftToRight = _regardingEntityRepository
                .GetValue(x => x.RegardingObjectIdTarget == healthProgramId && x.RegardingEntityNameTarget == firstItem.CodeNumber!.ToUpper() && x.RegardingEntityNameSource == secondItem.CodeNumber!.ToUpper());
            var rightToLeft = _regardingEntityRepository
                .GetValue(x => x.RegardingObjectIdTarget == healthProgramId && x.RegardingEntityNameSource == firstItem.CodeNumber!.ToUpper() && x.RegardingEntityNameTarget == secondItem.CodeNumber!.ToUpper());

            if (leftToRight != null && leftToRight.Id != Guid.Empty)
                bonusLogisticsStuff = secondItem;
            else if (rightToLeft != null && rightToLeft.Id != Guid.Empty)
                bonusLogisticsStuff = firstItem;
        }

        foreach (var item in model.Items)
        {
            var logisticsStuff = products.First(x => x.Id == item.ProductId);
            if (logisticsStuff != null && logisticsStuff?.Id != null && logisticsStuff.Id != Guid.Empty)
            {
                if (bonusLogisticsStuff == null) bonusLogisticsStuff = logisticsStuff;

                var purchase = new Purchase
                {
                    Id = Guid.NewGuid(),
                    HealthProgramId = healthProgramId,
                    PurchaseDate = purchaseDate,
                    PointOfPurchase = accountSettingsByProgram.Name ?? "",
                    Name = accountSettingsByProgram.Name ?? "",
                    Observations = logisticsStuff.Name,
                    InternalControl = logisticsStuff.Id.ToString(),
                    ImportCode = groupCode,
                    AccountId = accountSettingsByProgram.AccountId,
                    IsDeleted = false,
                    CreatedOn = purchaseDate,
                    CreatedBy = userId,
                    CreatedByName = userName ?? "",
                    StatusCodeStringMapId = Guid.Parse("38396C30-EDD6-4C6B-A90C-6A33577F82A2"),
                    StateCode = true,
                    Identifier = purchaseNumber,
                    Lot = logisticsStuff.BarCode,
                    Amount = item.Amount,
                    EntityOriginalValues = model.IsGeneratePurchase ? "#SALES_ORDER_FATURADA" : "#SALES_ORDER_BONIFICADA",
                    FriendlyCode = "0",
                };

                purchases.Add(purchase);
                _purchaseRepository.Insert(purchase);
            }
        };

        var bonificationItem = purchases.First(x => x.InternalControl == bonusLogisticsStuff.Id.ToString());

        inventories = InstanceAmountBonus(inventories, bonusLogisticsStuff!, accountSettingsByProgram.AccountId ?? Guid.Empty);
        UpdateAmountBonus(inventories);

        var attachment = CreatePurchaseFile(purchases, "pedido_compra", bonificationItem);

        return new ReturnMessage<object>
        {
            IsValidData = true,
            Value = new
            {
                fileName = attachment.FileName,
                body = attachment.DocumentBody
            }
        };
    }

    public async Task<ReturnMessage<bool>> AddRepayment(RepaymentCreateModel model)
    {
        if (model.Items == null || model.Items.Count == 0)
        {
            return new ReturnMessage<bool>
            {
                IsValidData = false,
                AdditionalMessage = "Invalid data!"
            };
        }

        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == model.ProgramCode).Id;
        var userId = Guid.Parse(_httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
        var userName = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
        var groupCode = Guid.NewGuid().ToString();
        var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.SystemUserId == userId);
        var purchases = new List<Purchase>();
        var inventories = _logisticStuffRepository.Find(x =>
            x.HealthProgramId == healthProgramId &&
            x.OwnerId == accountSettingsByProgram.AccountId &&
            !x.IsDeleted);

        if (accountSettingsByProgram == null)
        {
            return new ReturnMessage<bool>
            {
                IsValidData = false,
                AdditionalMessage = "AccountSettingsByProgram not found!"
            };
        }

        try
        {
            foreach (var item in model.Items)
            {
                var logisticsStuff = _logisticStuffRepository.GetValue(x => x.Id == item.ProductId);
                var inventoryItem = _logisticStuffRepository.GetValue(x =>
                    x.HealthProgramId == logisticsStuff.HealthProgramId &&
                    x.Packing == logisticsStuff.CodeNumber &&
                    x.OwnerId == accountSettingsByProgram.AccountId &&
                    !x.IsDeleted);

                if (item.Amount < 1) throw new Exception("Invalid value!");
                if (inventoryItem == null || inventoryItem.AvailableQuantity < item.Amount) throw new Exception("Invalid value!");

                inventories = this.InstanceAmountBonus(inventories, logisticsStuff, accountSettingsByProgram.AccountId ?? Guid.Empty, false, item.Amount);

                var purchase = new Purchase
                {
                    Id = Guid.NewGuid(),
                    HealthProgramId = healthProgramId,
                    PurchaseDate = DateTime.Now,
                    PointOfPurchase = accountSettingsByProgram.Name ?? "",
                    Name = accountSettingsByProgram.Name ?? "",
                    Observations = logisticsStuff.Name,
                    InternalControl = logisticsStuff.Id.ToString(),
                    ImportCode = groupCode,
                    AccountId = accountSettingsByProgram.AccountId,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    CreatedBy = userId,
                    CreatedByName = userName ?? "",
                    StatusCodeStringMapId = Guid.Parse("38396C30-EDD6-4C6B-A90C-6A33577F82A2"),
                    StateCode = true,
                    Lot = logisticsStuff.BarCode,
                    Amount = item.Amount,
                    EntityOriginalValues = "#REPAYMENT",
                    FriendlyCode = "0"
                };

                _purchaseRepository.Insert(purchase);
                purchases.Add(purchase);
            };
        }
        catch
        {
            return new ReturnMessage<bool>
            {
                Value = false,
                AdditionalMessage = "Valores inválidos!",
                IsValidData = false
            };
        }


        this.UpdateAmountBonus(inventories);
        if (purchases.Count > 0) this.CreatePurchaseFile(purchases, "reembolso");

        return new ReturnMessage<bool>
        {
            IsValidData = true,
            Value = true
        };
    }

    public async Task<ReturnMessage<List<PurchaseListPartnerResultModel>>> ListByPartners(PurchaseListPartnerModel model)
    {
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == model.ProgramCode).Id;
        var purchaseQuery = _purchaseRepository.Queryable()
            .Include(x => x.Account)
                .ThenInclude(x => x.AccountSettingsByPrograms)
            .Where(x => x.HealthProgramId == healthProgramId);

        if (!string.IsNullOrEmpty(model.PartnerId))
            purchaseQuery = purchaseQuery.Where(x => x.Account.FriendlyCode == model.PartnerId);
        if (!string.IsNullOrEmpty(model.PartnerName))
            purchaseQuery = purchaseQuery.Where(purchase => purchase.Account.AccountSettingsByPrograms.FirstOrDefault().Name == model.PartnerName);
        if (!string.IsNullOrEmpty(model.PartnerCnpj))
            purchaseQuery = purchaseQuery.Where(purchase => purchase.Account.AccountSettingsByPrograms.FirstOrDefault().Cnpj == model.PartnerCnpj);
        if (!string.IsNullOrEmpty(model.Type))
            purchaseQuery = purchaseQuery.Where(purchase => purchase.EntityOriginalValues == model.Type);

        var purchases = await purchaseQuery.ToListAsync();
        var validPurchases = new List<Purchase>();
        purchases.ForEach(purchase =>
        {
            if (!validPurchases.Any(item => item.ImportCode == purchase.ImportCode))
                validPurchases.Add(purchase);
        });

        var resultModel = validPurchases.Select(purchase => new PurchaseListPartnerResultModel
        {
            Id = purchase.Id,
            SolicitationDate = purchase.PurchaseDate,
            PurchaseId = purchase.Identifier,
            CodeSap = purchase.Account?.AccountSettingsByPrograms.FirstOrDefault()?.InternalControl,
            PartnerName = purchase.Account?.AccountSettingsByPrograms.FirstOrDefault()?.Name,
            PartnerCnpj = purchase.Account?.AccountSettingsByPrograms.FirstOrDefault()?.Cnpj,
            PartnerEmail = purchase.Account?.AccountSettingsByPrograms.FirstOrDefault()?.EmailAddress,
            IsConfirmed = purchase.FriendlyCode == "1",
            Type = purchase.EntityOriginalValues
        }).ToList();

        return new ReturnMessage<List<PurchaseListPartnerResultModel>>
        {
            IsValidData = true,
            Value = resultModel
        };
    }

    public async Task<ReturnMessage<string>> DownloadFile(string programCode, Guid purchaseId)
    {
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
        var purchase = _purchaseRepository.GetValue(x => x.HealthProgramId == healthProgramId && x.Id == purchaseId && !x.IsDeleted);
        var purchases = _purchaseRepository.Find(x => x.HealthProgramId == healthProgramId && x.ImportCode == purchase.ImportCode && !x.IsDeleted);
        if (purchases == null)
            return new ReturnMessage<string> { IsValidData = false, AdditionalMessage = "Purchase not found!" };

        var attach = _attachmentRepository.GetValue(x => x.InternalControl == purchases.First().ImportCode);
        if (attach == null)
            return new ReturnMessage<string> { IsValidData = false, AdditionalMessage = "Attachment not found!" };

        return new ReturnMessage<string>
        {
            IsValidData = true,
            Value = attach.DocumentBody,
        };
    }

    public async Task<ReturnMessage<bool>> ToggleConfirm(string programCode, Guid purchaseId)
    {
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
        var purchase = _purchaseRepository.GetValue(x => x.HealthProgramId == healthProgramId && x.Id == purchaseId && !x.IsDeleted);
        if (purchase == null)
            return new ReturnMessage<bool> { Value = false, AdditionalMessage = "Purchase not found!" };

        if (purchase.FriendlyCode == "1") purchase.FriendlyCode = "0";
        else
        {
            purchase.FriendlyCode = "1";
            var voucher = _voucherRepository.GetValue(x => x.HealthProgramId == healthProgramId && x.FriendlyCode == purchase.ImportCode);

            if (voucher != null && voucher.CustomBoolean1 != true)
            {
                voucher.CustomBoolean1 = true;
                var diagnostic = _diagnosticRepository.GetValue(x => x.Id == voucher.DiagnosticId);
                var patient = _patientRepository.GetValue(x => x.Id == diagnostic.PatientId);
                var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.AccountId == purchase.AccountId);

                _emailService.MergeTemplateMail<Patient>(
                    Patient.EntityName,
                    Patient.EntityTypeCode,
                    "#PARCEIRO_VALIDOU_VOUCHER",
                    patient.Id,
                    patient.HealthProgramId!.Value,
                    true,
                    patient.EmailAddress1!);

                _emailService.MergeTemplateMail<Account>(
                    Account.EntityName,
                    Account.EntityTypeCode,
                    "#PARCEIRO_VOUCHER_VALIDADO",
                    accountSettingsByProgram.AccountId!.Value,
                    healthProgramId,
                    true,
                    accountSettingsByProgram.EmailAddress!,
                    bodyReplace: new Dictionary<string, string> { ["[#NOME#]"] = accountSettingsByProgram.Name });

                _voucherRepository.Update(voucher);
            }
        }

        _purchaseRepository.Update(purchase);

        return new ReturnMessage<bool>
        {
            IsValidData = true,
            Value = true
        };
    }

    public async Task<ReturnMessage<List<string>>> DownloadAll(string programCode, DateTime? date)
    {
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
        List<Purchase>? purchases = null;
        if (date != null)
        {
            var startDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 0, 0, 0);
            var endDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 23, 59, 59);
            purchases = _purchaseRepository.Find(x => x.HealthProgramId == healthProgramId && !x.IsDeleted && x.PurchaseDate >= startDate && x.PurchaseDate <= endDate);
        }
        else
            purchases = _purchaseRepository.Find(x => x.HealthProgramId == healthProgramId && !x.IsDeleted);

        if (purchases == null || purchases.Count == 0)
            return new ReturnMessage<List<string>> { IsValidData = false, AdditionalMessage = "Purchase not found!" };

        var fileText = this.CreatePurchaseFileMulti(purchases, healthProgramId);

        return new ReturnMessage<List<string>>
        {
            IsValidData = true,
            Value = new List<string>() { fileText }
        };
    }

    public string GetDataToExport()
    {
        var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == "073").Id;
        var purchases = _purchaseRepository
            .Queryable()
            .Include(x => x.Account)
                .ThenInclude(x => x.AccountSettingsByPrograms)
            .Where(x => x.HealthProgramId == healthProgramId && (x.EntityOriginalValues == "#SALES_ORDER_BONIFICADA" || x.EntityOriginalValues == "#SALES_ORDER_FATURADA"))
            .OrderByDescending(x => x.CreatedOn)
            .ToList();

        var vouchers = _voucherRepository.Find(x => x.HealthProgramId == healthProgramId);

        var fileData = $"Id;Nome;CNPJ;SAP;Produto;EAN;Quantidade;Data Criação;Tipo{Environment.NewLine}";

        purchases.ForEach(item =>
        {
            for (var i = 0; i < item.Amount; i++)
            {
                var type = item.EntityOriginalValues == "#SALES_ORDER_BONIFICADA" ? "Bonificado" : "Faturado";
                fileData += $"{item.ImportCode};{item.Name};{item.Account?.Cnpj};{item.Account?.AccountSettingsByPrograms?.FirstOrDefault(x => x.HealthProgramId == healthProgramId)?.InternalControl};{item.Observations};{item.Lot};1;{item.PurchaseDate?.ToString("dd/MM/yyyy")};{type}{Environment.NewLine}";
            }
        });

        return fileData;
    }

    private Attachment CreatePurchaseFile(List<Purchase> purchases, string type, Purchase? bonificationItem = null)
    {
        var firstLine = purchases.FirstOrDefault();
        if (firstLine == null) throw new Exception("Purchases not found!");

        var fileText = "";
        var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.AccountId == firstLine.AccountId);
        var purchaseDateString = firstLine.PurchaseDate?.ToString("yyyyMMdd");
        var cnpj = accountSettingsByProgram.Cnpj ?? "";
        var lineIndex = 1;
        var lineIndexVcb = 1;
        var isBonification = firstLine.EntityOriginalValues == "#SALES_ORDER_BONIFICADA";
        cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "").Substring(0, 13);

        if (isBonification)
        {
            var bonificationPurchases = bonificationItem != null ? new List<Purchase> { bonificationItem } : new List<Purchase> { purchases.First() };
            fileText += $"01;{firstLine.Identifier}_VCB;{purchaseDateString};;;;;;{cnpj};{cnpj};{purchases.Count};;VCB;;ORDERS;{purchaseDateString};;;BR{Environment.NewLine}";

            bonificationPurchases.ForEach(item =>
            {
                fileText += $"04;{firstLine.Identifier}_VCB;{cnpj};{cnpj};{lineIndexVcb};{item.Lot};;1;;;;;{Environment.NewLine}";
                lineIndexVcb++;
                lineIndex++;
            });
        }
        else
        {
            var bonificationPurchases = new List<Purchase> { purchases.First() };
            fileText += $"01;{firstLine.Identifier}_VCF;{purchaseDateString};;;;;;{cnpj};{cnpj};{purchases.Count};;VCF;;ORDERS;{purchaseDateString};;;BR{Environment.NewLine}";

            purchases.ForEach(item =>
            {
                var amount = item.Id == bonificationPurchases.First().Id ? item.Amount - 1 : item.Amount;
                fileText += $"04;{firstLine.Identifier}_VCF;{cnpj};{cnpj};{lineIndex};{item.Lot};;{amount};;;;;{Environment.NewLine}";
                lineIndex++;
            });

            fileText += $"01;{firstLine.Identifier}_VCB;{purchaseDateString};;;;;;{cnpj};{cnpj};{purchases.Count};;VCB;;ORDERS;{purchaseDateString};;;BR{Environment.NewLine}";
            bonificationPurchases.ForEach(item =>
            {
                fileText += $"04;{firstLine.Identifier}_VCB;{cnpj};{cnpj};{lineIndexVcb};{item.Lot};;1;;;;;{Environment.NewLine}";
                lineIndexVcb++;
                lineIndex++;
            });
        }

        fileText += $"09;2;{lineIndex - 1};{Environment.NewLine}";

        var fileName = $"jj_{firstLine.Identifier}_{type}.txt";

        var attachment = new Attachment
        {
            Id = Guid.NewGuid(),
            FileName = fileName,
            Name = fileName,
            MimeType = "txt",
            DocumentBody = fileText,
            CreatedOn = DateTime.Now,
            CreatedByName = firstLine.CreatedByName,
            CreatedBy = firstLine.CreatedBy,
            StateCode = true,
            IsDeleted = false,
            StatusCodeStringMapId = Guid.Parse("282FEF7A-E89E-4EC5-9910-17CE6D29C435"),
            InternalControl = firstLine.ImportCode
        };

        _attachmentRepository.Insert(attachment);

        return attachment;
    }

    private string CreatePurchaseFileMulti(List<Purchase> purchases, Guid healthProgramId)
    {
        var fileText = "";
        int lineIndex = 1;
        if (purchases == null || purchases.Count == 0) throw new Exception("Purchases not found!");
        var purchaseIdentifiers = purchases
            .Where(x => !string.IsNullOrEmpty(x.Identifier))
            .Select(x => x.Identifier ?? "")
            .Distinct()
            .Order()
            .ToList();

        purchaseIdentifiers.ForEach(identifier =>
        {
            var firstLine = purchases.First(x => x.Identifier == identifier);
            var mPurchases = purchases.Where(x => x.Identifier == identifier).ToList();
            var accountSettingsByProgram = _accountSettingsByProgramRepository.GetValue(x => x.AccountId == firstLine.AccountId);
            var purchaseDateString = firstLine.PurchaseDate?.ToString("yyyyMMdd");
            var cnpj = accountSettingsByProgram.Cnpj ?? "";
            var mLineIndex = 1;
            var mLineIndexBonux = 1;
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "").Substring(0, 13);

            var isBonus = false;
            var usedVoucher = _voucherRepository.GetValue(x => x.HealthProgramId == healthProgramId && x.FriendlyCode == firstLine.ImportCode);
            if (usedVoucher != null && usedVoucher.Id != Guid.Empty)
                isBonus = true;

            fileText += $"01;{firstLine.Identifier}_VCF;{purchaseDateString};;;;;;{cnpj};{cnpj};{mPurchases.Count};;VCF;;ORDERS;{purchaseDateString};;;BR{Environment.NewLine}";

            if (isBonus)
            {
                var bonificationPurchases = new List<Purchase> { mPurchases.First() };

                mPurchases.ForEach(item =>
                {
                    var amount = item.Id == bonificationPurchases.First().Id ? item.Amount - 1 : item.Amount;
                    fileText += $"04;{firstLine.Identifier}_VCF;{cnpj};{cnpj};{mLineIndex};{item.Lot};;{amount};;;;;{Environment.NewLine}";
                    lineIndex++;
                    mLineIndex++;
                });

                fileText += $"01;{firstLine.Identifier}_VCB;{purchaseDateString};;;;;;{cnpj};{cnpj};{mPurchases.Count};;VCB;;ORDERS;{purchaseDateString};;;BR{Environment.NewLine}";
                bonificationPurchases.ForEach(item =>
                {
                    fileText += $"04;{firstLine.Identifier}_VCB;{cnpj};{cnpj};{mLineIndexBonux};{item.Lot};;1;;;;;{Environment.NewLine}";
                    lineIndex++;
                    mLineIndexBonux++;
                });
            }
            else
            {
                mPurchases.ForEach(item =>
                {
                    fileText += $"04;{firstLine.Identifier}_VCF;{cnpj};{cnpj};{mLineIndex};{item.Lot};;{item.Amount};;;;;{Environment.NewLine}";
                    lineIndex++;
                });
            }
        });

        fileText += $"09;{purchaseIdentifiers.Count * 2};{lineIndex - 1};{Environment.NewLine}";

        return fileText;
    }

    private List<LogisticsStuff> InstanceAmountBonus(List<LogisticsStuff> inventories, LogisticsStuff parent, Guid accountId, bool isAdd = true, int amountSub = 0)
    {
        var inventoryItem = inventories.FirstOrDefault(x => x.Packing == parent.CodeNumber);
        if (inventoryItem == null)
        {
            inventoryItem = _logisticStuffRepository.GetValue(x =>
                x.HealthProgramId == parent.HealthProgramId &&
                x.Packing == parent.CodeNumber &&
                x.OwnerId == accountId &&
                !x.IsDeleted);
        }

        if (!isAdd && inventoryItem == null)
            throw new Exception("Invalid operation!");

        if (!isAdd && inventoryItem.AvailableQuantity <= 0)
            throw new Exception("Invalid amount!");

        if (inventoryItem == null)
        {
            inventoryItem = new LogisticsStuff
            {
                Id = Guid.NewGuid(),
                Name = parent.Name,
                CodeNumber = parent.CodeNumber,
                Description = parent.Description,
                BarCode = parent.BarCode,
                ListPrice = parent.ListPrice,
                HealthProgramId = parent.HealthProgramId,
                ProductFeatures = parent.ProductFeatures,
                StatusCodeStringMapId = parent.StatusCodeStringMapId,
                ImportCode = parent.ImportCode,
                InternalControl = parent.InternalControl,
                AvailableQuantity = 0,
                OwnerId = accountId,
                Packing = parent.CodeNumber
            };

            _logisticStuffRepository.Insert(inventoryItem);
        }

        if (isAdd) inventoryItem.AvailableQuantity++;
        else inventoryItem.AvailableQuantity -= amountSub;

        if (inventories.Any(x => x.Packing == parent.Packing))
            inventories.FirstOrDefault(x => x.Packing == parent.Packing)!.AvailableQuantity = inventoryItem.AvailableQuantity;
        else
            inventories.Add(inventoryItem);

        return inventories;
    }

    private void UpdateAmountBonus(List<LogisticsStuff> inventories)
    {
        foreach (var item in inventories)
        {
            _logisticStuffRepository.Update(item);
        }
    }
}