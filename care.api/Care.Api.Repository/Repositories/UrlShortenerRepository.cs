using Care.Api.Context;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class UrlShortenerRepository : CommonRepository<UrlShortener>, IUrlShortenerRepository
    {
        public UrlShortenerRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
    }
}
