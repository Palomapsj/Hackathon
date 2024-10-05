using Care.Api.Models;

namespace Care.Api.Repository.Interfaces;

    public interface IRepresentativeRepository : ICommonRepository<Representative>
    {
        Representative GetProfessionalByLicense(Guid id, Guid? userId);
    }

