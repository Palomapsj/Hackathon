using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Repository.Repositories
{
    public class AttachmentRepository : CommonRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

    }
}
