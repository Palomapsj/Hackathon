using Care.Api.Context;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class StockHistoryRepository : CommonRepository<StockHistory>, IStockHistoryRepository
    {
        public StockHistoryRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }
    }
}
