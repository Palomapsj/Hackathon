using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class SmsRepository : CommonRepository<Sms>, ISmsRepository
    {
        public SmsRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }
    }
}
