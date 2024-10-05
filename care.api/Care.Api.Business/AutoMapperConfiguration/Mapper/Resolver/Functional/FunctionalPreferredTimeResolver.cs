using AutoMapper;
using Care.Api.Business.Enums.Functional;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Business.Models.Viva;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalPreferredTimeResolver : IValueResolver<Treatment, PostUpdatePacientRequestDto, int?>
    {
        private readonly IStringMapRepository _stringMapRepository;

        public FunctionalPreferredTimeResolver(IStringMapRepository stringMapRepository)
        {
            _stringMapRepository = stringMapRepository;
        }

        public int? Resolve(Treatment source, PostUpdatePacientRequestDto destination, int? destMember, ResolutionContext context)
        {
            if (source.PreferredTimeStringMapId.HasValue)
            {
                var preferedTimeStringMap = _stringMapRepository.GetValue(s => s.StringMapId == source.PreferredTimeStringMapId);

                if (!string.IsNullOrEmpty(preferedTimeStringMap.Flag))
                {
                    var ePreferredTime = Enums.EnumExtensions.GetEnumValueFromDescription<EPreferredTime>(preferedTimeStringMap.Flag);
                    return (int)ePreferredTime;
                }
            }

            return (int)EPreferredTime.Integral;
        }
    }
}
