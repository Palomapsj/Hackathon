using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using ValidationResult = Care.Api.Repository.Validation.ValidationResult;

namespace Care.Api.Repository.Repositories;

public class VoucherRepository : CommonRepository<Voucher>, IVoucherRepository
{
    public VoucherRepository(CareDbContext careDbContext) : base(careDbContext)
    {

    }

    public List<Voucher> GetVoucherByNumber(Guid healthprogramId, string number)
    {
        var voucherList = _careDbContext
            .Vouchers
            .Where(_ => _.HealthProgramId == healthprogramId && _.Number == number).ToList();

        return voucherList;
    }

    public IQueryable<Voucher>? Queryable()
    {
        try
        {
            return _careDbContext.Set<Voucher>().AsQueryable();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
            return null;
        }
    }

    public Voucher GetVoucherByName(Guid healthprogramId, string name)
    {
        var voucherList = _careDbContext.Vouchers.Where(_ => _.HealthProgramId == healthprogramId
                                                          && _.Name == name)
                                                           .Include(_ => _.Doctor)
                                                           .FirstOrDefault();

        return voucherList;
    }

    public ValidationResult Insert(List<Voucher> data)
    {
        var validationResult = new ValidationResult();

        try
        {
            var auditRepository = new AuditRepository(_careDbContext._configuration);
            data.ForEach(dataItem => auditRepository.SaveAudit(dataItem, Microsoft.EntityFrameworkCore.EntityState.Added));

            _careDbContext.Set<Voucher>().AddRange(data);
            _careDbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            validationResult.Add(ex.Message);
        }

        return validationResult;
    }

    public ValidationResult Update(List<Voucher> data)
    {
        var validationResult = new ValidationResult();
        try
        {
            var id = _careDbContext.ContextId;
            var auditRepository = new AuditRepository(_careDbContext._configuration);
            data.ForEach(dataItem => auditRepository.SaveAudit(dataItem, EntityState.Modified));
            data.ForEach(dataItem => _careDbContext.Entry(dataItem).State = EntityState.Modified);
            _careDbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            validationResult.Add(ex.Message);
        }

        return validationResult;
    }
}

