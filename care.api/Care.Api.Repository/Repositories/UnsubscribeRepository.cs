using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Care.Api.Repository.Repositories;

public class UnsubscribeRepository : CommonRepository<Unsubscribe>, IUnsubscribeRepository
{
    public UnsubscribeRepository(CareDbContext careDbContext) : base(careDbContext)
    {
    }

}
