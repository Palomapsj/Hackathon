using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Business.Services
{
    public class StringMapService : IStringMapService
    {

        private readonly IStringMapRepository _stringMapRepository;

        public StringMapService(
            IStringMapRepository stringMapRepository
            )
        {
            _stringMapRepository = stringMapRepository;
        }

        public Task<StringMap?> GetStringMapByEntityAndAttributeAndFlag(string entityName, string attributeName, string flag)
        {
            var stringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity(flag, entityName, attributeName);

            return System.Threading.Tasks.Task.FromResult(stringMap);
        }

        public Task<StringMap> GetStringMapByEntityAndAttributeAndFlagAndProgram(string entityName, string attributeName, string flag, string programcode)
        {
            var stringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity(flag, Exam.EntityName, "ExamStatusStringMap");

            return System.Threading.Tasks.Task.FromResult(stringMap);
        }

        public Task<List<StringMap>> GetStringMapByEntityAndAttributeNameAndProgram(string entityName, string attributeName, string programcode)
        {
            var stringMap = _stringMapRepository.GetStringMapByEntityAndAttributeNameAndProgram(entityName, attributeName, programcode);

            return System.Threading.Tasks.Task.FromResult(stringMap);
        }

        public Task<StringMap?> GetStringMapByFlagAndAttributeAndEntityAndProgram(string flag, string entityName, string attributeName, Guid programcode)
        {
            var stringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntityAndProgram(flag, entityName, attributeName, programcode);

            return System.Threading.Tasks.Task.FromResult(stringMap);
        }

        public async Task<List<StringMapBasic>> GetBasicStringMapByEntityAndAttributeNameAndProgram(string entityName, string attributeName, string programcode)
        {
            List<StringMapBasic> result = new List<StringMapBasic>();

            var stringMapList = _stringMapRepository.GetStringMapByEntityAndAttributeNameAndProgram(entityName, attributeName, programcode);

            foreach (var stringMap in stringMapList)
            {
                var stringMapItem = new StringMapBasic()
                {
                    StringMapId = stringMap.StringMapId,
                    EntityMetadataId = stringMap.EntityMetadataId,
                    EntityMetadataIdName = stringMap.EntityMetadataIdName,
                    AttributeMetadataId = stringMap.AttributeMetadataId,
                    AttributeMetadataIdName = stringMap.AttributeMetadataIdName,
                    OptionValue = stringMap.OptionValue,
                    OptionName = stringMap.OptionName,
                    DisplayOrder = stringMap.DisplayOrder.Value,
                    IsDisabled = stringMap.IsDisabled,
                    OptionNameLangEn = stringMap.OptionNameLangEn,
                    ProgramId = stringMap.ProgramId,
                    IsSystemOption = stringMap.IsSystemOption,
                    Flag = stringMap.Flag,
                };

                result.Add(stringMapItem);
            }

            return result;
        }
    }
}
