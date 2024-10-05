using Care.Api.Models;
using Care.Api.Models.Models;
using ValidationResult = Care.Api.Repository.Validation.ValidationResult;

namespace Care.Api.Repository.Interfaces
{
    public interface ICaregiverTreatmentRepository : ICommonRepository<CaregiverTreatment>
    {
        ValidationResult Add(Guid caregiverId, Guid treatmentId);
    }
}
