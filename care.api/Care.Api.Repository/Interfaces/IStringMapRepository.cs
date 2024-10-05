using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IStringMapRepository : ICommonRepository<StringMap>
    {
        StringMap? GetStringMapByFlagAndAttributeAndEntity(string flag, string entityName, string attributeName);

        Guid? GetStatusCode(string entityName, string Flag);

        List<StringMap> GetStringMapByEntityAndAttributeNameAndProgram(string entityName, string attributeName, string programcode);

        List<StringMap> GetStringMapByEntityAndAttributeNameAndProgram(string entityName, string attributeName, Guid healthProgramId);

        StringMap? GetStringMapByAttributeOptionValueAndProgram(string entityName, string attributeName, int optionValue, Guid healthProgramId);

        StringMap? GetStringMapByAttributeOptionValue(string entityName, string attributeName, int optionValue);

        StringMap? GetStringMapByFlagAndAttributeAndEntityAndProgram(string flag, string entityName, string attributeName, Guid healthProgramId);

        Guid? GetStringMapId(string entityName, string optionName);

        Task<List<StringMap>> GetStringMapsWithoutHidePickListOptions(string entityName, string attributeName, Guid programId);
    }
}
