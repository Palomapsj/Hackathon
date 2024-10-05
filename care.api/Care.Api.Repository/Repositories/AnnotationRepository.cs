using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class AnnotationRepository : CommonRepository<Annotation>, IAnnotationRepository
    {
        public AnnotationRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public Annotation GetAnnotationByRegardingId(Guid regardingEntityId)
        {
            var annotations = _careDbContext.Annotations
                                                .Include(_ => _.RegardingEntity)
                                                .Include(_ => _.Attachments.Where(a => a.IsDeleted == false))
                                                .Where(_ => _.RegardingEntity.Id == regardingEntityId
                                                         && _.IsDeleted == false)
                                                .ToList();

            return annotations.FirstOrDefault();
        }

        public Annotation GetAnnotationsAttachment(Guid diagnosticId, string flagStringMap, string? code = null)
        {
            try
            {
                var annotations = _careDbContext.Annotations
                                                    .Include(_ => _.RegardingEntity)
                                                    .Include(_ => _.AnnotationTypeStringMap)
                                                    .Include(_ => _.Attachments.Where(a => a.IsDeleted == false))
                                                    .Where(_ => _.RegardingEntity.RegardingObjectIdTarget == diagnosticId
                                                             && _.IsDeleted == false
                                                             && _.AnnotationTypeStringMap.Flag == flagStringMap
                                                             && _.RegardingEntity.InternalControl == code).ToList();

                return annotations.FirstOrDefault();
            }
            catch (Exception ex)
            { }

            return null;
        }
        public Annotation GetLatestAnnotationByRegardingObjectIdTarget(Guid regardingObjectIdTarget)
        {
            try
            {
                var annotation = _careDbContext.Annotations
                    .Include(_ => _.RegardingEntity)
                    .Include(_ => _.AnnotationTypeStringMap)
                    .Where(_ => _.RegardingEntity.RegardingObjectIdTarget == regardingObjectIdTarget)
                    .OrderByDescending(_ => _.CreatedOn)
                    .FirstOrDefault();

                return annotation;
            }
            catch (Exception ex)
            { }
            return null;
        }
        public List<Annotation> GetAnnotationsByStatusAndDiagnostic(Guid diagnosticId, List<Guid> status)
        {
            var annotations = _careDbContext.Annotations
                                                .Include(_ => _.RegardingEntity)
                                                .Where(_ => _.RegardingEntity.RegardingObjectIdTarget == diagnosticId && _.IsDeleted == false)
                                                .Include(_ => _.Attachments.Where(_ => _.IsDeleted == false))
                                                .ToList();

            var annotationsFilterd = annotations.Where(_ => status.Any(s => s == _.AnnotationTypeStringMapId)).ToList();

            return annotationsFilterd;
        }

        public List<Annotation> GetAnnotationsByRegardingObjectIdTarget(Guid regardingObjectIdTarget, string RegardingObjectIdNameTarget, string flagStringMap)
        {
            try
            {
                var annotations = _careDbContext.Annotations
                    .Include(_ => _.RegardingEntity)
                    .Include(_ => _.AnnotationTypeStringMap)
                                        .Include(_ => _.Attachments)
                    .Where(_ => _.RegardingEntity.RegardingObjectIdTarget == regardingObjectIdTarget && _.RegardingEntity.RegardingObjectIdNameTarget == RegardingObjectIdNameTarget && _.AnnotationTypeStringMap.Flag == flagStringMap)
                    .ToList();

                return annotations;
            }
            catch (Exception ex)
            { }
            return null;
        }

        public Annotation GetAttachmentByAnnotationId(Guid annotationId)
        {
            try
            {
                var annotation = _careDbContext.Annotations
                    .Where(_ => _.IsDeleted == false && _.Id == annotationId)
                    .Include(_ => _.Attachments.Where(a => a.IsDeleted == false))
                    .FirstOrDefault();

                return annotation;
            }
            catch (Exception ex)
            { }
            return null;
        }

        public Annotation GetAnnotationAttachmentSByLogisticsScheduleId(Guid id)
        {
            try
            {
                var annotation = _careDbContext.Annotations
                    .Where(_ => _.IsDeleted == false && _.ImportCode == id.ToString() && _.AnnotationTypeStringMapId == new Guid("065243AC-B219-414F-9421-8731EA8DDA74"))
                    .Include(_ => _.Attachments.Where(a => a.IsDeleted == false))
                    .OrderByDescending(o => o.CreatedOn)
                    .FirstOrDefault();

                return annotation;
            }
            catch (Exception ex)
            { }
            return null;
        }
    }
}
