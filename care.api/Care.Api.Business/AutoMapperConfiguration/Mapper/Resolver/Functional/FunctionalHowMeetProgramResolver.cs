using AutoMapper;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Business.Enums.Functional;
using Care.Api.Business.Models.Viva;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalHowMeetProgramResolver : IValueResolver<Treatment, PostUpdatePacientRequestDto, int>
    {
        private readonly IStringMapRepository _stringMapRepository;

        public FunctionalHowMeetProgramResolver(IStringMapRepository stringMapRepository)
        {
            _stringMapRepository = stringMapRepository;
        }

        public int Resolve(Treatment source, PostUpdatePacientRequestDto destination, int destMember, ResolutionContext context)
        {
            if (source.Custom3StringMapId.HasValue)
            {
                var howMeetProgramStringMap = _stringMapRepository.GetValue(s => s.StringMapId == source.Custom3StringMapId);

                if (!string.IsNullOrEmpty(howMeetProgramStringMap.Flag))
                {
                    var eHowMeetProgram = Enums.EnumExtensions.GetEnumValueFromDescription<EHowMeetProgram>(howMeetProgramStringMap.Flag);
                    return (int)eHowMeetProgram;
                }
            }

            return (int)EHowMeetProgram.Outros;
        }
    }
}
