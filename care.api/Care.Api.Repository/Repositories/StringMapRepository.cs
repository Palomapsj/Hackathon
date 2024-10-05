using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Dapper;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Care.Api.Repository.Repositories
{
    public class StringMapRepository : CommonRepository<StringMap>, IStringMapRepository
    {
        private readonly IConfiguration _config;
        public StringMapRepository(CareDbContext careDbContext, IConfiguration config) : base(careDbContext)
        {
            _config = config;
        }

        public Guid? GetStatusCode(string entityName, string flag)
        {
            var stringMap = _careDbContext.StringMaps.Where(_ => _.Flag == flag
                                                            && _.AttributeMetadataIdName == "STATUSCODESTRINGMAP"
                                                            && _.EntityMetadataIdName == entityName).FirstOrDefault();

            if (stringMap == null) { return null; }

            return stringMap.StringMapId;
        }

        public StringMap? GetStringMapByFlagAndAttributeAndEntity(string flag, string entityName, string attributeName)
        {
            var stringMap = _careDbContext.StringMaps.Where(_ => _.Flag == flag
                                                                && _.EntityMetadataIdName == entityName
                                                                && _.AttributeMetadataIdName == attributeName).FirstOrDefault();

            if (stringMap == null) { return null; }

            return stringMap;
        }

        public List<StringMap>? GetStringMapByEntityAndAttributeNameAndProgram(string entityName, string attributeName, string programcode)
        {
            var healthProgramId = _careDbContext.HealthPrograms.FirstOrDefault(_ => _.Code == programcode).Id;

            if (healthProgramId != Guid.Empty)
            {
                return _careDbContext.StringMaps.Where(_ => _.EntityMetadataIdName == entityName
                                                         && _.AttributeMetadataIdName == attributeName
                                                         && _.ProgramId.Value == healthProgramId
                                                         && (_.IsDisabled.HasValue && _.IsDisabled.Value == false)).ToList();
            }

            return null;
        }

        public List<StringMap> GetStringMapByEntityAndAttributeNameAndProgram(string entityName, string attributeName, Guid healthProgramId)
        {
            return _careDbContext.StringMaps.Where(_ => _.EntityMetadataIdName == entityName
                                                        && _.AttributeMetadataIdName == attributeName
                                                        && _.ProgramId.Value == healthProgramId
                                                        && (_.IsDisabled.HasValue && _.IsDisabled.Value == false)).ToList();

        }

        public StringMap? GetStringMapByAttributeOptionValue(string entityName, string attributeName, int optionValue)
        {
            var stringMap = _careDbContext.StringMaps.Where(_ => _.EntityMetadataIdName == entityName
                                                              && _.AttributeMetadataIdName == attributeName
                                                              && _.OptionValue == optionValue).FirstOrDefault();

            if (stringMap == null) { return null; }

            return stringMap;
        }

        public StringMap? GetStringMapByAttributeOptionValueAndProgram(string entityName, string attributeName, int optionValue, Guid healthProgramId)
        {
            var stringMap = _careDbContext.StringMaps.Where(_ => _.EntityMetadataIdName == entityName
                                                              && _.AttributeMetadataIdName == attributeName
                                                              && _.OptionValue == optionValue
                                                              && _.ProgramId == healthProgramId).FirstOrDefault();

            if (stringMap == null) { return null; }

            return stringMap;
        }

        public StringMap? GetStringMapByFlagAndAttributeAndEntityAndProgram(string flag, string entityName, string attributeName, Guid healthProgramId)
        {
            var stringMap = _careDbContext.StringMaps.Where(_ => _.Flag == flag
                                                              && _.EntityMetadataIdName == entityName
                                                              && _.AttributeMetadataIdName == attributeName
                                                              && _.ProgramId == healthProgramId).FirstOrDefault();

            if (stringMap == null) { return null; }

            return stringMap;
        }

        public Guid? GetStringMapId(string entityName, string optionName)
        {
            var stringMap = _careDbContext.StringMaps.Where(_ => _.OptionName == optionName
                                                            && _.EntityMetadataIdName == entityName).FirstOrDefault();

            if (stringMap == null) { return null; }

            return stringMap.StringMapId;
        }

        public async Task<List<StringMap>> GetStringMapsWithoutHidePickListOptions(string entityName, string attributeName, Guid programId)
        {
            var coreDapper = new CoreDapperRepository(_config);

            var hidePickListOptions = coreDapper.GetHidePickListOptions(entityName, attributeName, programId);

            var results = new List<StringMap>();

            if (hidePickListOptions is not null)
            {
                results = await _careDbContext.StringMaps.Where(x => x.EntityMetadataIdName == entityName
                                                           && x.AttributeMetadataIdName == attributeName
                                                           && (x.ProgramId == programId || x.ProgramId == Guid.Parse("6FF88F55-C993-412A-A8E8-2CBBE9B9CFB5"))
                                                           && (!hidePickListOptions.Contains(x.StringMapId))
                                                           ).ToListAsync();
            }
            else
            {
                results = await _careDbContext.StringMaps.Where(x => x.EntityMetadataIdName == entityName
                                                            && x.AttributeMetadataIdName == attributeName
                                                            && (x.ProgramId == programId || x.ProgramId == Guid.Parse("6FF88F55-C993-412A-A8E8-2CBBE9B9CFB5"))
                                                            ).ToListAsync();

            }

            return results;
        }
    }
}
