using AutoMapper;
using Care.Api.Models;
using Care.Api.Business.Enums.Functional;
using Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Interfaces;
using Care.Api.Business.Models.Viva;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalResponsibleResolver : IValueResolver<Treatment, PostUpdatePacientRequestDto, ResponsibleFunctionalRequest>
    {
        private readonly IFunctionalResponsibleRelationshipResolver _relacaoResponsavelResolver;
        private readonly IFunctionalTelephoneResolver _telefoneFuncionalResolver;

        public FunctionalResponsibleResolver(IFunctionalResponsibleRelationshipResolver relacaoResponsavelResolver, IFunctionalTelephoneResolver telefoneFuncionalResolver)
        {
            _relacaoResponsavelResolver = relacaoResponsavelResolver;
            _telefoneFuncionalResolver = telefoneFuncionalResolver;
        }

        public ResponsibleFunctionalRequest Resolve(Treatment source, PostUpdatePacientRequestDto destination, ResponsibleFunctionalRequest destMember, ResolutionContext context)
        {
            return new ResponsibleFunctionalRequest(
                            source.FullNameCaregiver,
                            _relacaoResponsavelResolver.Resolve(source),
                            source.BirthdateCaregiver,
                            TelefoneFuncionalResponsavelMapper(source),
                            source.CpfCaregiver,
                            1
                        );
        }

        private List<TelephonesFunctionalRequest> TelefoneFuncionalResponsavelMapper(Treatment treatment)
        {
            var telefones = new List<TelephonesFunctionalRequest>();

            if (!string.IsNullOrWhiteSpace(treatment.Telephone1Caregiver))
            {
                _telefoneFuncionalResolver.DefinirTelefoneFuncional(telefones, treatment.Telephone1Caregiver, (int)EPhoneType.Residencial);
            }
            if (!string.IsNullOrWhiteSpace(treatment.Mobilephone1Caregiver))
            {
                _telefoneFuncionalResolver.DefinirTelefoneFuncional(telefones, treatment.Mobilephone1Caregiver, (int)EPhoneType.Celular);
            }

            return telefones;
        }        
    }
}
