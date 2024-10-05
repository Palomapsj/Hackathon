using Care.Api.Models;
using ValidationResult = Care.Api.Repository.Validation.ValidationResult;

namespace Care.Api.Repository.Interfaces
{
    public interface IVoucherRepository : ICommonRepository<Voucher>
    {
        List<Voucher> GetVoucherByNumber(Guid healthprogramid, string number);
        Voucher GetVoucherByName(Guid healthprogramid, string name);
        IQueryable<Voucher> Queryable();
        ValidationResult Insert(List<Voucher> data);
        ValidationResult Update(List<Voucher> data);
    }
}
