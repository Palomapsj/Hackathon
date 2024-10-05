using Care.Api.Models;

namespace Care.Api.Repository.Interfaces;

public interface ILogisticStuffRepository : ICommonRepository<LogisticsStuff>
{
    IQueryable<LogisticsStuff> Queryable();
}