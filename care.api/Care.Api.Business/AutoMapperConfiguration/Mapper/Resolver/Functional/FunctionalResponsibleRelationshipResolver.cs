using AutoMapper;
using Care.Api.Models;
using Care.Api.Business.Enums.Functional;
using Care.Api.Repository.Interfaces;
using Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Interfaces;
using Care.Api.Business.Models.Viva;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalResponsibleRelationshipResolver : IFunctionalResponsibleRelationshipResolver, IValueResolver<Treatment, PostUpdatePacientRequestDto, int>
    {
        private readonly IStringMapRepository _stringMapRepository;

        public FunctionalResponsibleRelationshipResolver(IStringMapRepository stringMapRepository)
        {
            _stringMapRepository = stringMapRepository;
        }

        public int Resolve(Treatment source, PostUpdatePacientRequestDto destination, int destMember, ResolutionContext context)
        {
            return Resolve(source);
        }

        public int Resolve(Treatment source)
        {
            if (source.KinshipStringMapId.HasValue)
            {
                var kinshipStringMap = _stringMapRepository.GetValue(s => s.StringMapId == source.KinshipStringMapId);

                if (!string.IsNullOrEmpty(kinshipStringMap.Flag))
                {
                    var eResponsibleRelationship = Enums.EnumExtensions.GetEnumValueFromDescription<EResponsibleRelationship>(kinshipStringMap.Flag);
                    return (int)eResponsibleRelationship;
                }
            }

            return (int)EResponsibleRelationship.NaoInformado;
        }
    }
}
