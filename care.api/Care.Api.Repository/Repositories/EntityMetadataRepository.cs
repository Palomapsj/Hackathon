using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Dapper;
using Care.Api.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class EntityMetadataRepository : CommonRepository<DoctorByProgram>, IEntityMetadataRepository
    {

        private readonly IConfiguration _config;
        public EntityMetadataRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public EntityMetadata? GetEntityMetadata(string entityName)
        {
            var entityMetadata = _careDbContext.EntityMetadata.Where(_ => _.EntityName == entityName).FirstOrDefault();

            if (entityMetadata is null) {
                return null;
            }

            return entityMetadata;
        }


    }
}
