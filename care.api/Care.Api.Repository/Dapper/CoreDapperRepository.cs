using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using Microsoft.IdentityModel.Protocols;
using Care.Api.Repository.Repositories;
using Care.Api.Context;
using static Dapper.SqlMapper;
using Care.Api.Models;

namespace Care.Api.Repository.Dapper
{

    public class CoreDapperRepository : IDisposable
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "DefaultConnection";

        public CoreDapperRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection ProfarmaSpecialtyConnection
        {
            get { return new SqlConnection(_config.GetConnectionString(Connectionstring)); }
        }

        public void Dispose()
        {

        }

        public TEntity? GetById<TEntity>(string entity, Guid Id) where TEntity : class
        {
            using (var cn = ProfarmaSpecialtyConnection)
            {
                var condition = new DynamicParameters();
                condition.Add("Id", Id);

                return cn.Query<TEntity>($"select * from [{entity}] where Id=@Id", condition).FirstOrDefault();
            }
        }

        public DateTime? GetById(string entity, string fieldName, Guid Id)
        {
            using (var cn = ProfarmaSpecialtyConnection)
            {
                var condition = new DynamicParameters();
                condition.Add("Id", Id);

                return cn.Query<DateTime>($"select [{fieldName}] from [{entity}] where Id=@Id", condition).FirstOrDefault();
            }
        }

        public List<string> GetEntityTemplate(Guid entityMetadataId, Guid? id)
        {
            using (var cn = ProfarmaSpecialtyConnection)
            {
                string entityMetadata = cn.Query<string>($"select EntityName from EntityMetadata where EntityMetadataId='{entityMetadataId}'").FirstOrDefault();
                if (id == null)
                {
                    return cn.Query<string>($"SELECT  convert(nvarchar(36),Id) FROM  {entityMetadata} WHERE isdeleted=0").ToList();
                }
                else
                {
                    return cn.Query<string>($"SELECT  convert(nvarchar(36),Id) FROM  [{entityMetadata}] WHERE id='{id}' and isdeleted=0").ToList();

                }
            }
        }

        public string GetAttributeEntityTemplate(string attribute, string entityMetadata, Guid id)
        {
            using (var cn = ProfarmaSpecialtyConnection)
            {
                return cn.Query<string>($"SELECT  isnull({attribute},'') FROM  [{entityMetadata}] WHERE id =  '{id}'").FirstOrDefault();
            }
        }

        public string GetAttributeEntityInnerTable(bool isLookUp, bool isPickList, string attribute, string entity, string innerTable, Guid id, int levelEntity, bool isName, string dateformat)
        {
            var resp = string.Empty;
            using (var cn = ProfarmaSpecialtyConnection)
            {
                if (!isLookUp && !isPickList)
                {
                    resp = cn.Query<string>($"SELECT isnull(OptionName,'') from StringMap where StringMapId in(Select {attribute}Id FROM  {entity} WHERE id =  '{id}' and isDeleted=0)").FirstOrDefault();
                }
                else if (isPickList)
                {
                    if (levelEntity == 1)
                    {
                        resp = cn.Query<string>($"SELECT isnull(OptionName,'') from StringMap where StringMapId in(Select {attribute}Id FROM  {entity} WHERE Id =  '{id}' and isDeleted=0)").FirstOrDefault();
                    }
                    else
                    {
                        string entityID = cn.Query<string>($"select  convert(nvarchar(36),{innerTable}Id) from {entity} where ID='{id}'").FirstOrDefault();
                        if (entityID != null)
                        {
                            resp = cn.Query<string>($"SELECT isnull(OptionName,'') from StringMap where StringMapId in(Select {attribute}Id FROM  {innerTable} WHERE Id =  '{entityID}' and isDeleted=0)").FirstOrDefault();
                        }
                    }
                }
                else
                {
                    if (levelEntity == 1)
                    {
                        if (dateformat == "d")
                        {
                            resp = cn.Query<string>($"select CONVERT(varchar(10),{attribute},103) from {innerTable} where id in(Select {innerTable}Id FROM  {entity} WHERE id =  '{id}' and isDeleted=0)").FirstOrDefault();
                        }
                        else if (dateformat == "h")
                        {
                            resp = cn.Query<string>($"select CONVERT(varchar(10),{attribute},108) from {innerTable} where id in(Select {innerTable}Id FROM  {entity} WHERE id =  '{id}' and isDeleted=0)").FirstOrDefault();
                        }
                        else
                        {
                            resp = cn.Query<string>($"SELECT isnull({attribute},'') from {innerTable} where id in(Select {innerTable}Id FROM  {entity} WHERE id =  '{id}' and isDeleted=0)").FirstOrDefault();
                        }
                    }
                    else if (levelEntity == 2)
                    {
                        var attributeName =
                            cn.Query<string>($"select AttributeName from AttributeMetadata A  join EntityMetadata e on e.EntityMetadataId=a.EntityMetadataId and EntityName='{entity}' where AttributeType='{innerTable}'").FirstOrDefault();

                        if (attributeName.Substring(attributeName.Length - 2).ToLower() != "id")
                            attributeName += "id";

                        string entityID = cn.Query<string>($"select convert(nvarchar(36),{attributeName}) from {entity} where ID='{id}'").FirstOrDefault();
                        if (!isName)
                        {
                            if (entityID != null)
                            {

                                if (dateformat == "d")
                                {
                                    resp = cn.Query<string>($"select CONVERT(varchar(10),{attribute},103)  FROM  {innerTable} WHERE id =  convert(nvarchar(36),'{entityID}') and isDeleted=0").FirstOrDefault();
                                }
                                else if (dateformat == "h")
                                {
                                    resp = cn.Query<string>($"select CONVERT(varchar(10),{attribute},108)  FROM  {innerTable} WHERE id =  convert(nvarchar(36),'{entityID}') and isDeleted=0").FirstOrDefault();
                                }
                                else
                                {
                                    resp = cn.Query<string>($"Select isnull({attribute},'') FROM  {innerTable} WHERE id =  convert(nvarchar(36),'{entityID}') and isDeleted=0").FirstOrDefault();
                                }
                            }
                        }
                        else
                        {
                            if (entityID != null)
                            {
                                string innerEntityId = cn.Query<string>($"Select convert(nvarchar(36),{attribute}Id) FROM  {innerTable} WHERE id =  convert(nvarchar(36),'{entityID}') and isDeleted=0").FirstOrDefault();
                                string innerEntityName = cn.Query<string>($"Select InnerTable FROM AttributeMetadata A join EntityMetadata e on e.EntityMetadataId = A.EntityMetadataId and EntityName='{innerTable}' where AttributeName = '{attribute}'").FirstOrDefault();

                                if (innerEntityId != null)
                                {
                                    resp = cn.Query<string>($"Select name FROM  {innerEntityName} WHERE id =  convert(nvarchar(36),'{innerEntityId}') and isDeleted=0").FirstOrDefault();
                                }
                            }
                        }
                    }
                    else
                    {
                        string entityID = cn.Query<string>($"select  convert(nvarchar(36),{innerTable}Id) from {entity} where ID='{id}'").FirstOrDefault();
                        resp = cn.Query<string>($"SELECT isnull({attribute},'') from {innerTable} where id in(Select {innerTable}Id FROM  {entity} WHERE id =  convert(nvarchar(36),'{entityID}') and isDeleted=0)").FirstOrDefault();
                    }
                }
                return resp ?? string.Empty;
            }
        }

        public int InsertAudit(AuditEntity audit)
        {
            using (var cn = ProfarmaSpecialtyConnection)
            {
                if (audit.TableNameAudit == "Email" || audit.TableNameAudit == "Template" || audit.TableNameAudit.ToUpper() == "SMS")
                {
                    audit.XMLNewValues = null;
                    audit.XMLOldValues = null;
                }

                var condition = new DynamicParameters();
                condition.Add("ID", audit.Id);
                condition.Add("Fields", audit.Fields);
                condition.Add("Message", audit.Message);
                condition.Add("RegardingObjectId", audit.RegardingObjectId);
                condition.Add("CreatedOn", audit.CreatedOn);
                condition.Add("UserId", audit.UserId);

                condition.Add("XMLNewValues", audit.XMLNewValues);
                condition.Add("XMLOldValues", audit.XMLOldValues);

                return cn.Execute($"INSERT INTO [{audit.TableNameAudit}Audit]([ID],[Fields],[Message],[RegardingObjectId],[CreatedOn],[UserId],[XMLNewValues],[XMLOldValues]) VALUES(@ID, @Fields,@Message,@RegardingObjectId,@CreatedOn,@UserId,@XMLNewValues,@XMLOldValues)", condition);
            }
        }

        public string GetVoucher(Guid id)
        {
            var resp = string.Empty;

            using (var cn = ProfarmaSpecialtyConnection)
            {
               resp = cn.Query<string>($"SELECT Name FROM VOUCHER WHERE id =  '{id}'").FirstOrDefault();
                return resp;
            }
        }

        public string GetDosage(Guid id)
        {
            var resp = string.Empty;

            using (var cn = ProfarmaSpecialtyConnection)
            {
                resp = cn.Query<string>($"SELECT Name FROM StrengthMedicament WHERE id =  '{id}'").FirstOrDefault();
                return resp;
            }
        }

        public IEnumerable<TEntity> Get<TEntity>(string sql) where TEntity : class
        {
            using (var cn = ProfarmaSpecialtyConnection)
            {
                return cn.Query<TEntity>(sql);
            }
        }



        public List<Guid> GetHidePickListOptions(string entityName, string attributeName, Guid programId)
        {
            using (var cn = ProfarmaSpecialtyConnection)
            {
                var param = new DynamicParameters();

                param.Add("@EntityName",entityName);
                param.Add("@AttributeName",attributeName);
                param.Add("@ProgramId",programId);

                var rulesAttribute = cn.Query<string>($"SELECT HidePickListOptions FROM RulesAttributeMetadata WHERE EntityMetadataIdName= @EntityName AND AttributeMetadataIdName = @AttributeName AND ProgramId = @ProgramId",param).FirstOrDefault();

                List<Guid> hidePickListOptions = new List<Guid>();

                if (rulesAttribute != null)
                {
                    hidePickListOptions = rulesAttribute.Split("|").Select(x => Guid.TryParse(x, out var guid) ? guid : throw new FormatException("Guid invalido")).ToList();
                }
                
                return hidePickListOptions;
            }
        }

        public bool UpdateFunctional(Guid id, int? instructorRequest, int? unitDose, int? medicamentCod)
        {
            using (var cn = ProfarmaSpecialtyConnection)
            {
                var param = new DynamicParameters();

                param.Add("@id", id);
                param.Add("@instructorRequest", instructorRequest);
                param.Add("@unitDose", unitDose);
                param.Add("@medicamentCod", medicamentCod);
                param.Add("@modifiedOn", DateTime.Now);

                var result = cn.Execute($"UPDATE TreatmentCustomData SET SupportFieldInt = @instructorRequest, SupportFieldInt2 = @unitDose, SupportFieldInt3 = @medicamentCod, ModifiedOn = @modifiedOn WHERE Id = @id", param);
                               
                return result > 0;
            }
        }
    }
}
