using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class ChatRepository : CommonRepository<Chat>, IChatRepository
    {
        public ChatRepository(CareDbContext careDbContext) : base(careDbContext)
        {
                
        }
    }
}
