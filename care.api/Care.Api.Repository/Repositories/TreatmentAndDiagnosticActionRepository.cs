using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Care.Api.Repository.Repositories
{
    public class TreatmentAndDiagnosticActionRepository : CommonRepository<TreatmentAndDiagnosticAction>, ITreatmentAndDiagnosticActionRepository
    {
        public TreatmentAndDiagnosticActionRepository(CareDbContext careDbContext) : base(careDbContext)
        {        
        }

        public IEnumerable<TreatmentAndDiagnosticAction> GetSimilarAction(Guid id, int actionStatus, string sourceEntityTypeCode, string sourceEntityName, Guid? diagnosticId = null, Guid? treatmentId = null, Guid? sourceEntityId = null)
        {
            return _careDbContext.TreatmentAndDiagnosticActions.Include(i => i.ActionConfiguration).Where(
                    x =>
                        x.ActionConfigurationId == id
                        && x.ActionStatus == actionStatus
                        && x.SourceEntityTypeCode == sourceEntityTypeCode
                        && x.SourceEntityName == sourceEntityName
                        && x.DiagnosticId == @diagnosticId
                        && x.TreatmentId == @treatmentId
                        && x.SourceEntityObjectId == @sourceEntityId).ToList();
        }

        public List<TreatmentAndDiagnosticActionAudit> GetTreatmentAudit(Guid id)
        {
            var treatmentAndDiagnosticActionAuditsList = _careDbContext.TreatmentAndDiagnosticActionAudits.Where(_ => _.RegardingObjectId == id).ToList();

            return treatmentAndDiagnosticActionAuditsList;
        }
    }

}
