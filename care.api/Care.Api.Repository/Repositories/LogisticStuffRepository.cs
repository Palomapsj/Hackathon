using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories;

public class LogisticStuffRepository : CommonRepository<LogisticsStuff>, ILogisticStuffRepository
{
    public LogisticStuffRepository(CareDbContext careDbContext) : base(careDbContext)
    {

    }

    public IQueryable<LogisticsStuff>? Queryable()
    {
        try
        {
            return _careDbContext.Set<LogisticsStuff>().AsQueryable();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Trace: {ex.StackTrace}");
            return null;
        }
    }
}