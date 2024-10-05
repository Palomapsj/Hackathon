using AutoMapper;
using Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Interfaces;
using Care.Api.Models;
using Care.Api.Business.Enums.Functional;
using Care.Api.Business.Models.Viva;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional
{
    public class FunctionalTelephoneResolver : IFunctionalTelephoneResolver, IValueResolver<Treatment, PostUpdatePacientRequestDto, List<TelephonesFunctionalRequest>>
    {
        public void DefinirTelefoneFuncional(List<TelephonesFunctionalRequest> telefones, string telefone, int tipoTelefone)
        {
            telefones.Add(new TelephonesFunctionalRequest(ExtractDDDPhone(telefone), ExtractNumberPhone(telefone), tipoTelefone));
        }

        private string ExtractDDDPhone(string phone)
        {
            string number = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string ddd = number.Substring(0, 2);

            return ddd;
        }

        private string ExtractNumberPhone(string phone)
        {
            string numberReplace = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string number = numberReplace.Substring(2);

            return number;
        }

        public List<TelephonesFunctionalRequest> Resolve(Treatment source)
        {
            var telefones = new List<TelephonesFunctionalRequest>();

            if (!string.IsNullOrWhiteSpace(source.Telephone1))
            {
                DefinirTelefoneFuncional(telefones, source.Telephone1, (int)EPhoneType.Residencial);
            }
            if (!string.IsNullOrWhiteSpace(source.Telephone2))
            {
                DefinirTelefoneFuncional(telefones, source.Telephone2, (int)EPhoneType.Residencial);
            }
            if (!string.IsNullOrWhiteSpace(source.Telephone3))
            {
                DefinirTelefoneFuncional(telefones, source.Telephone3, (int)EPhoneType.Residencial);
            }

            if (!string.IsNullOrWhiteSpace(source.Mobilephone1))
            {
                DefinirTelefoneFuncional(telefones, source.Mobilephone1, (int)EPhoneType.Celular);
            }
            if (!string.IsNullOrWhiteSpace(source.Mobilephone2))
            {
                DefinirTelefoneFuncional(telefones, source.Mobilephone2, (int)EPhoneType.Celular);
            }
            if (!string.IsNullOrWhiteSpace(source.Mobilephone3))
            {
                DefinirTelefoneFuncional(telefones, source.Mobilephone3, (int)EPhoneType.Celular);
            }

            return telefones;
        }

        public List<TelephonesFunctionalRequest> Resolve(Treatment source, PostUpdatePacientRequestDto destination, List<TelephonesFunctionalRequest> destMember, ResolutionContext context)
        {
            return Resolve(source);
        }
    }
}
