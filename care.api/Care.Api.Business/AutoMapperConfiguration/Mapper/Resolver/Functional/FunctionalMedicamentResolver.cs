using AutoMapper;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Care.Api.Business.Models.Viva;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalMedicamentResolver : IValueResolver<Treatment, PostUpdatePacientRequestDto, MedicamentFunctionalRequest>
    {
        private readonly ITreatmentCustomDataRepository _treatmentCustomDataRepository;
        private readonly IDoctorRepository _doctorRepository;

        public FunctionalMedicamentResolver(ITreatmentCustomDataRepository treatmentCustomDataRepository, IDoctorRepository doctorRepository)
        {
            _treatmentCustomDataRepository = treatmentCustomDataRepository;
            _doctorRepository = doctorRepository;
        }

        public MedicamentFunctionalRequest Resolve(Treatment source, PostUpdatePacientRequestDto destination, MedicamentFunctionalRequest destMember, ResolutionContext context)
        {
            var treatmentCustomData = _treatmentCustomDataRepository.GetValue(t => t.Id == source.TreatmentCustomDataId);
            var doctor = _doctorRepository.GetValue(d => d.Id == source.DoctorId);
            var medico = new DoctorFunctionalRequest(doctor?.LicenseNumber, doctor?.LicenseState, doctor?.FullName);

            return new MedicamentFunctionalRequest(treatmentCustomData?.SupportFieldInt3, treatmentCustomData?.SupportFieldInt, source.Dosage, medico, treatmentCustomData?.SupportFieldInt2 ?? 0);
        }
    }
}
