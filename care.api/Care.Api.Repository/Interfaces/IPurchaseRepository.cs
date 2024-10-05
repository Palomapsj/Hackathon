using Care.Api.Models;

namespace Care.Api.Repository.Interfaces;

public interface IPurchaseRepository : ICommonRepository<Purchase>
{
    IQueryable<Purchase> Queryable();
}