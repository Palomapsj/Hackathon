using AutoMapper;
using Care.Api.Models;
using Care.Api.Business.Enums.Functional;
using ProFarma.Care.Domain.Entities;
using Care.Api.Repository.Interfaces;
using Care.Api.Business.Models.Viva;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalAddressResolver : IValueResolver<Treatment, PostUpdatePacientRequestDto, AddressFunctionalRequest>
    {
        private readonly ITreatmentAddressRepository _treatmentAddressRepository;

        public FunctionalAddressResolver(ITreatmentAddressRepository treatmentAddressRepository)
        {
            _treatmentAddressRepository = treatmentAddressRepository;
        }

        public AddressFunctionalRequest Resolve(Treatment source, PostUpdatePacientRequestDto destination, AddressFunctionalRequest destMember, ResolutionContext context)
        {
            var address = _treatmentAddressRepository.GetByTreatmentId(source.Id).Result;
            int tipoEndereco = 0;

            if (address != null)
            {

                if (address.AddressTypeStringMapId.HasValue)
                {
                    EAddressType eAddressType = BaseEnumHelper.GetEnumByGuid<EAddressType>(address.AddressTypeStringMapId.Value);
                    tipoEndereco = (int)eAddressType;
                }

                return new AddressFunctionalRequest(
                    address.AddressName,
                    address.AddressNumber,
                    address.AddressDistrict,
                    address.AddressCity,
                    address.AddressPostalCode,
                    address.AddressState,
                    address.AddressComplement,
                    address.AddressReference,
                    tipoEndereco,
                    address.ReceiveMail == true ? 1 : 0);
            }

            return null;
        }
    }
}
