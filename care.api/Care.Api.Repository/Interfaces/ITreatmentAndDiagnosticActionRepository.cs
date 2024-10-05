using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface ITreatmentAndDiagnosticActionRepository : ICommonRepository<TreatmentAndDiagnosticAction>
    {
        IEnumerable<TreatmentAndDiagnosticAction> GetSimilarAction(Guid id, int actionStatus, string sourceEntityTypeCode, string sourceEntityName, Guid? @diagnosticId = null, Guid? @treatmentId = null, Guid? @sourceEntityId = null);
    }
}
