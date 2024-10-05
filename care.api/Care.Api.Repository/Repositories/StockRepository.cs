using Care.Api.Context;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class StockRepository : CommonRepository<Stock>, IStockRepository
    {
        public StockRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }
    }
}
