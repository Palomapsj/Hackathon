using Care.Api.Models;

namespace Care.Api.Repository.Interfaces
{
    public interface IAnnotationRepository : ICommonRepository<Annotation>
    {
        List<Annotation> GetAnnotationsByStatusAndDiagnostic(Guid diagnosticId, List<Guid> status);

        Annotation GetAnnotationsAttachment(Guid diagnosticId, string flagStringMap, string? code = null);

        Annotation GetAnnotationByRegardingId(Guid regardingEntityId);

        List<Annotation> GetAnnotationsByRegardingObjectIdTarget(Guid regardingObjectIdTarget, string RegardingObjectIdNameTarget, string flagStringMap);

        Annotation GetAttachmentByAnnotationId(Guid annotationId);
        Annotation GetLatestAnnotationByRegardingObjectIdTarget(Guid regardingObjectIdTarget);

        Annotation GetAnnotationAttachmentSByLogisticsScheduleId(Guid id);        
    }
}
