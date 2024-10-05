using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class EmailRepository : CommonRepository<Email>, IEmailRepository
    {
        public EmailRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public override Email Update(Email data)
        {
            try
            {
                var id = _careDbContext.ContextId;
                if (data is BaseEntity && data is not null)
                {
                    (data as BaseEntity).ModifiedOn = DateTime.Now;

                    var entityId = (data as BaseEntity).Id;
                    var entityInDatabase = GetById(entityId);

                    SetOriginalValues(ref data, entityInDatabase);

                    //SetUser(ref data, EntityState.Modified);
                }

                AuditRepository auditRepository = new AuditRepository(_careDbContext._configuration);
                auditRepository.SaveAudit(data, EntityState.Modified);

                _careDbContext.ChangeTracker.Clear();
                _careDbContext.Entry(data).State = EntityState.Modified;
                _careDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }

            return data;
        }
    }
}
