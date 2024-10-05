using Care.Api.Models;
using Care.Api.Models.Models;

namespace Care.Api.Repository.Interfaces;

public interface IPatientRepository : ICommonRepository<Patient>
{
    Task<List<MultidisciplinaryService>> GetMultidisciplinaryServicesByFullName(Guid Id);

    Patient GetPatientByCpf(string Cpf);

    IQueryable<Patient?> Queryable();
}
