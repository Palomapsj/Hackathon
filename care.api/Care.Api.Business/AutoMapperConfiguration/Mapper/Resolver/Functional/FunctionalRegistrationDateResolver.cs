using AutoMapper;
using Care.Api.Business.Models.Viva;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalRegistrationDateResolver : IValueResolver<Treatment, PostUpdatePacientRequestDto, DateTime?>
    {
        private readonly ITreatmentCustomDataRepository _treatmentCustomDataRepository;

        public FunctionalRegistrationDateResolver(ITreatmentCustomDataRepository treatmentCustomDataRepository)
        {
            _treatmentCustomDataRepository = treatmentCustomDataRepository;
        }

        public DateTime? Resolve(Treatment source, PostUpdatePacientRequestDto destination, DateTime? destMember, ResolutionContext context)
        {
            if (source.TreatmentCustomDataId.HasValue)
            {
                var treatmentCustomData = _treatmentCustomDataRepository.GetValue(t => t.Id == source.TreatmentCustomDataId);

                return treatmentCustomData.CustomDateTime1;
            }

            return null;
        }
    }
}
