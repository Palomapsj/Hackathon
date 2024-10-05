using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories;

public class PurchaseRepository : CommonRepository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(CareDbContext careDbContext) : base(careDbContext)
    {

    }

    public IQueryable<Purchase>? Queryable()
    {
        try
        {
            return _careDbContext.Set<Purchase>().AsQueryable();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
            return null;
        }
    }
}