using Care.Api.Business.Models.Viva;
using Care.Api.Models;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Interfaces
{
    public interface IFunctionalTelephoneResolver
    {
        List<TelephonesFunctionalRequest> Resolve(Treatment source);
        void DefinirTelefoneFuncional(List<TelephonesFunctionalRequest> telefones, string telefone, int tipoTelefone);
    }
}
