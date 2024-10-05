using Care.Api.Models;

namespace Care.Api.Business.Interfaces
{
    public interface IStringMapService
    {
        Task<StringMap?> GetStringMapByEntityAndAttributeAndFlag(string entityName, string attributeName, string flag);
        Task<StringMap> GetStringMapByEntityAndAttributeAndFlagAndProgram(string entityName, string attributeName, string flag, string programcode);
        Task<List<StringMap>> GetStringMapByEntityAndAttributeNameAndProgram(string entityName, string attributeName, string programcode);
        Task<StringMap?> GetStringMapByFlagAndAttributeAndEntityAndProgram(string flag, string entityName, string attributeName, Guid programcode);
        Task<List<StringMapBasic>> GetBasicStringMapByEntityAndAttributeNameAndProgram(string entityName, string attributeName, string programcode);
    }
}
