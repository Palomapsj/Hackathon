using AutoMapper;
using Care.Api.Business.Enums.Functional;
using Care.Api.Business.Models.Viva;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using ProFarma.Care.Domain.Entities;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalReasonRegistrationResolver : IValueResolver<Treatment, PostUpdatePacientRequestDto, List<int>>
    {
        private readonly IHealthProgramRepository _healthProgramRepository;

        public FunctionalReasonRegistrationResolver(IHealthProgramRepository healthProgramRepository)
        {
            _healthProgramRepository = healthProgramRepository;
        }

        public List<int> Resolve(Treatment source, PostUpdatePacientRequestDto destination, List<int> destMember, ResolutionContext context)
        {
            var motivos = new List<int>();
            
            var healthProgramDupixent = _healthProgramRepository.GetValue(h => h.Code == "980");

            if (source.HealthProgramId == healthProgramDupixent.Id)
            {
                if (source.DiseaseId.HasValue)
                    MotivoPorIndicacaoDupixentMapper(source.DiseaseId.Value, EIndication.Primeira, motivos);

                if (source.Disease2Id.HasValue)
                    MotivoPorIndicacaoDupixentMapper(source.Disease2Id.Value, EIndication.Segunda, motivos);

                if (source.Disease3Id.HasValue)
                    MotivoPorIndicacaoDupixentMapper(source.Disease3Id.Value, EIndication.Terceira, motivos);
            }
            else
            {
                if (source.DiseaseId.HasValue)
                {

                }
            }

            return motivos;
        }

        private void MotivoPorIndicacaoDupixentMapper(Guid diseaseId, EIndication eIndicacao, List<int> motivos)
        {
            var diseaseMotivosMap = new Dictionary<Guid?, (int primeiraIndicacao, int segundaIndicacao, int terceiraIndicacao)>
            {
                {
                    BaseEnumHelper.GetEnumGuid(EDisease.Polipos),
                    ((int)EReasonRegistration.PoliposNasaisPrimeiraIndicacao,
                    (int)EReasonRegistration.PoliposNasaisSegundaIndicacao,
                    (int)EReasonRegistration.PoliposNasaisTerceiraIndicacao)
                },
                {
                    BaseEnumHelper.GetEnumGuid(EDisease.Asma),
                    ((int)EReasonRegistration.AsmaPrimeiraIndicacao,
                    (int)EReasonRegistration.AsmaSegundaIndicacao,
                    (int)EReasonRegistration.AsmaTerceiraIndicacao)
                },
                {
                    BaseEnumHelper.GetEnumGuid(EDisease.DermatiteAtopica),
                    ((int)EReasonRegistration.DermatiteAtopicaPrimeiraIndicacao,
                    (int)EReasonRegistration.DermatiteAtopicaSegundaIndicacao,
                    (int)EReasonRegistration.DermatiteAtopicaTerceiraIndicacao)
                },
            };

            if (diseaseMotivosMap.TryGetValue(diseaseId, out var motivosIndicacao))
            {
                switch (eIndicacao)
                {
                    case EIndication.Primeira:
                        motivos.Add(motivosIndicacao.primeiraIndicacao);
                        break;
                    case EIndication.Segunda:
                        motivos.Add(motivosIndicacao.segundaIndicacao);
                        break;
                    case EIndication.Terceira:
                        motivos.Add(motivosIndicacao.terceiraIndicacao);
                        break;
                }
            }
        }
    }
}
