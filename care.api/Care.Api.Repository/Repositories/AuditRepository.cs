using Care.Api.Models;
using Care.Api.Repository.Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Care.Api.Repository.Repositories
{
    public class AuditRepository
    {

        private readonly IConfiguration _config;
        private readonly CoreDapperRepository coreDapper;

        public AuditRepository(IConfiguration config)
        {
            coreDapper = new CoreDapperRepository(config);
        }

        public AuditEntity SaveAudit<TEntity>(TEntity entity, EntityState entityState, bool @getOnlyobject = false) where TEntity : class
        {
            var result = new AuditEntity();

            var excludeFields = new string[]
            {
                "EntityTypeCode",
                "EntityName",
                "EntityAbreviationCode",
                "IsValid",
                "Id",
                "CurrentAuditId",
                "CurrentUserId",
                "EntityOriginalValues",
                "ValidationResult",
                "IsOperationAkka"
            };

            if (entity.GetType().GetInterface("INotAudit") == null)
            {
                SetBasicAuditData(ref result, entity, entityState);
                //var coreDapper = new Core.Dapper.CoreDapperRepository();

                if (entityState == EntityState.Added)
                {
                    result.XMLNewValues = Helpers.Helpers.AuditJsonSerializer(entity);
                    result.XMLOldValues = string.Empty;

                    entity.GetType().GetProperties().ToList().ForEach(w =>
                    {
                        if (!excludeFields.Contains(w.Name))
                        {
                            var value = w.GetValue(entity, null);

                            if (value != null)
                            {
                                if (w.PropertyType.IsConstructedGenericType && w.PropertyType.IsValueType == false)
                                {
                                    if ((value as IEnumerable<object>).Any())
                                    {
                                        result.Fields += w.Name + ";";
                                    }
                                }
                                else
                                {
                                    result.Fields += w.Name + ";";
                                }
                            }
                        }
                    });
                }

                if (entityState == EntityState.Modified || entityState == EntityState.Deleted)
                {
                    result.XMLNewValues = Helpers.Helpers.AuditJsonSerializer(entity);

                    var propertyInfo = entity.GetType().GetProperty("EntityOriginalValues");

                    if (propertyInfo != null)
                    {
                        var json = propertyInfo.GetValue(entity);

                        if (json != null)
                        {
                            propertyInfo.SetValue(entity, null);
                            result.XMLOldValues = json.ToString();
                        }
                    }

                    result.Fields = CompareFields<TEntity>(entity, result.XMLOldValues);

                    /*  TO DO TRETMENT AINDA Ñ É UTILIZADO
                    if (result.TableNameAudit == "Treatment")
                    {
                        var fieldsTreatment = new string[] { "TreatmentSituationId", "PhaseId", "TreatmentStatusId", "TreatmentStatusDetailId" };
                        var execDapperTreatmentHistory = false;

                        foreach (var field in fieldsTreatment)
                        {
                            if (result.Fields.Contains(field))
                            {
                                execDapperTreatmentHistory = true;
                                break;
                            }
                        }

                        if (execDapperTreatmentHistory)
                            coreDapper.CreateTreatmentHistory(entity);

                    }
                    */

                }

                if (!@getOnlyobject)
                    coreDapper.InsertAudit(result);

                return result;
            }

            return null;
        }


        private void SetBasicAuditData<TEntity>(ref AuditEntity audit, TEntity dados, EntityState entityState) where TEntity : class
        {
            object regardingObjectId = null;
            object isDeleted = null;
            object createdOn = null;
            object auditId = null;
            object userId = null;
            audit.Id = Guid.NewGuid();
            audit.Message = Enum.GetName(typeof(EntityState), entityState);

            if (dados.GetType().Name == "ResourceWorkSetting")
            {
                audit.TableNameAudit = "ResourceWorkSettings";
            }
            else if (dados.GetType().Name == "ResourceWorkSetting")
            {
                audit.TableNameAudit = "ResourceWorkSettings";
            }
            else
            {
                audit.TableNameAudit = dados.GetType().Name;
            }

            if (audit.TableNameAudit.IndexOf('_') >= 0)
            {
                audit.TableNameAudit = dados.GetType().BaseType.Name;//dados.Entity.GetType().Name.Substring(0, dados.Entity.GetType().Name.IndexOf('_'));
            }


            isDeleted = dados.GetType().GetProperties().Where(p => p.Name == "isDeleted").Select(p => p.GetValue(dados, null)).FirstOrDefault();
            regardingObjectId = dados.GetType().GetProperties().Where(p => p.Name == "Id").Select(p => p.GetValue(dados, null)).FirstOrDefault();
            createdOn = dados.GetType().GetProperties().Where(p => p.Name == "ModifiedOn").Select(p => p.GetValue(dados, null)).FirstOrDefault();
            userId = dados.GetType().GetProperties().Where(p => p.Name == "CurrentUserId").Select(p => p.GetValue(dados, null)).FirstOrDefault();
            if (userId == null)
            {
                userId =
                    dados.GetType()
                        .GetProperties()
                        .Where(p => p.Name == "ModifiedBy")
                        .Select(p => p.GetValue(dados, null))
                        .FirstOrDefault();
            }


            if (isDeleted != null)
            {
                if (bool.Parse(isDeleted.ToString()))
                {
                    audit.Message = Enum.GetName(typeof(EntityState), EntityState.Deleted);
                    createdOn = dados.GetType().GetProperties().Where(p => p.Name == "DeletedOn").Select(p => p.GetValue(dados, null)).FirstOrDefault();
                }
            }

            if (regardingObjectId != null)
            {
                audit.RegardingObjectId = Guid.Parse(regardingObjectId.ToString());
            }

            if (createdOn != null)
            {
                audit.CreatedOn = (createdOn as DateTime?).Value;
            }
            else
            {
                audit.CreatedOn = DateTime.Now;
            }

            auditId = dados.GetType().GetProperties().Where(p => p.Name == "CurrentAuditId").Select(p => p.GetValue(dados, null)).FirstOrDefault();

            if (auditId != null)
            {
                audit.Id = Guid.Parse(auditId.ToString());
            }

            if (userId != null)
            {
                audit.UserId = (userId as Guid?).Value;
            }
        }

        private string CompareFields<TEntity>(TEntity entity, string entityOldValues) where TEntity : class
        {
            try
            {
                var fields = new List<string>();
                var fieldsForRemove = new List<string>();
                var excludeFields = new string[]
                {
                "EntityTypeCode",
                "EntityName",
                "EntityAbreviationCode",
                "IsValid",
                "Id",
                "CurrentAuditId",
                "CurrentUserId",
                "EntityOriginalValues",
                "ValidationResult",
                "IsOperationAkka"

                };

                if (entity != null && !string.IsNullOrEmpty(entityOldValues))
                {
                    //var objNewValues = JsonConvert.DeserializeObject<TEntity>(entityNewValues);
                    var objOldValues = JsonConvert.DeserializeObject<TEntity>(entityOldValues);

                    foreach (var field in entity.GetType().GetProperties().Where(w => excludeFields.Contains(w.Name) == false))
                    {
                        var objOriginalValueAux = objOldValues.GetType().GetProperties().Where(p => p.Name == field.Name).ToList();
                        var objOriginalValue = objOriginalValueAux.Select(p => p.GetValue(objOldValues, null)).FirstOrDefault();

                        var objCurrentValuesAux = entity.GetType().GetProperties().Where(p => p.Name == field.Name).ToList();
                        var objCurrentValues = objCurrentValuesAux.Select(p => p.GetValue(entity, null)).FirstOrDefault();

                        if (field.Name == "ModifiedByName" || field.Name == "ModifiedBy")
                            fields.Add(field.Name);

                        if ((objOriginalValue == null && objCurrentValues != null) ||
                            (objOriginalValue != null && objCurrentValues == null))
                        {

                            if (objOriginalValue is StringMap && objCurrentValues == null)
                            {
                                var strMapId1 = objOldValues.GetType().GetProperty(field.Name + "Id").GetValue(objOldValues, null);
                                var strMapId2 = entity.GetType().GetProperty(field.Name + "Id").GetValue(objOldValues, null);

                                if (strMapId1 != null && strMapId2 != null)
                                {
                                    if (strMapId1.GetHashCode() == strMapId2.GetHashCode())
                                    {
                                        fieldsForRemove.Add(field.Name);
                                    }
                                }
                            }

                            if (objOriginalValue != null)
                            {
                                if ((objOriginalValue.GetType().BaseType.Name.Contains("BaseEntity") ||
                                     objOriginalValue.GetType().BaseType.Name.Contains("BaseContact")) &&
                                    objCurrentValues == null)
                                {
                                    var lkpMapId1 =
                                        objOldValues.GetType().GetProperty(field.Name + "Id").GetValue(objOldValues, null);
                                    var lkpMapId2 = entity.GetType()
                                        .GetProperty(field.Name + "Id")
                                        .GetValue(objOldValues, null);

                                    if (lkpMapId1 != null && lkpMapId2 != null)
                                    {
                                        if (lkpMapId1.GetHashCode() == lkpMapId2.GetHashCode())
                                        {
                                            fieldsForRemove.Add(field.Name);
                                        }
                                    }
                                }

                                if (!fieldsForRemove.Contains(field.Name))
                                    fields.Add(field.Name);
                            }
                            else
                            {
                                fields.Add(field.Name);
                            }
                        }

                        if (objOriginalValue != null && objCurrentValues != null)
                        {
                            if (objOriginalValue.GetHashCode() != objCurrentValues.GetHashCode())
                            {
                                fields.Add(field.Name);
                            }

                            if (field.PropertyType.IsConstructedGenericType && field.PropertyType.IsValueType == false)
                            {
                                if (!(objOriginalValue as IEnumerable<object>).Any() &&
                                    !(objCurrentValues as IEnumerable<object>).Any())
                                {
                                    fields.Remove(field.Name);
                                }
                            }
                        }

                    }
                }

                return string.Concat(fields.Select(w => w + ";"));
            }
            catch (Exception ex)
            {
                var a = "";
                return "";
            }
        }


    }

    public class AuditEntity
    {
        public Guid Id { get; set; }
        public string Fields { get; set; }
        public string Message { get; set; }
        public Guid RegardingObjectId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UserId { get; set; }
        public string XMLNewValues { get; set; }
        public string XMLOldValues { get; set; }
        public string TableNameAudit { get; set; }
    }
}

