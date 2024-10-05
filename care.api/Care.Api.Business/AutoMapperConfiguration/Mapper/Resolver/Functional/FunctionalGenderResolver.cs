using AutoMapper;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Business.Enums.Functional;
using Care.Api.Business.Models.Viva;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalGenderResolver : IValueResolver<Treatment, PostUpdatePacientRequestDto, int?>
    {
        private readonly IStringMapRepository _stringMapRepository;

        public FunctionalGenderResolver(IStringMapRepository stringMapRepository)
        {
            _stringMapRepository = stringMapRepository;
        }

        public int? Resolve(Treatment source, PostUpdatePacientRequestDto destination, int? destMember, ResolutionContext context)
        {
            if (source.GenderStringMapId.HasValue)
            {

                var genderStringMap = _stringMapRepository.GetValue(s => s.StringMapId == source.GenderStringMapId);

                if (!string.IsNullOrEmpty(genderStringMap.Flag))
                {
                    var eGender = Enums.EnumExtensions.GetEnumValueFromDescription<EGender>(genderStringMap.Flag);
                    return (int)eGender;
                }
            }

            return (int)EGender.NaoInformado;
        }
    }
}
