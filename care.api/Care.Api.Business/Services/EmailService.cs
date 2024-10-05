using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using Care.Api.Repository.Interfaces;
using Care.Api.Models;
using Care.Api.Repository.Dapper;
using static Care.Api.Business.Enums.EnumsHelper;
using ValidationResult = Care.Api.Repository.Validation.ValidationResult;

namespace Care.Api.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IConfiguration _config;
        private readonly IEntityMetadataRepository _entityMetadataRepository;
        private readonly IStringMapRepository _stringMapRepository;
        private readonly IHealthProgramTemplateSettingRepository _healthProgramTemplateSettingRepository;
        private readonly IRegardingEntityRepository _regardingEntityRepository;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly ITemplateService _templateService;
        private readonly IHealthProgramRepository _healthProgramRepository;
        private readonly IStringMapService _stringMapService;
        public EmailService(
            IEmailRepository emailRepository,
            IConfiguration config,
            IEntityMetadataRepository entityMetadataRepository,
            IStringMapRepository stringMapRepository,
            IHealthProgramTemplateSettingRepository healthProgramTemplateSettingRepository,
            IRegardingEntityRepository regardingEntityRepository,
            IAttachmentRepository attachmentRepository,
            ITemplateService templateService,
            IHealthProgramRepository healthProgramRepository,
            IStringMapService stringMapService
            )
        {
            _emailRepository = emailRepository;
            _config = config;
            _entityMetadataRepository = entityMetadataRepository;
            _stringMapRepository = stringMapRepository;
            _healthProgramTemplateSettingRepository = healthProgramTemplateSettingRepository;
            _regardingEntityRepository = regardingEntityRepository;
            _attachmentRepository = attachmentRepository;
            _templateService = templateService;
            _healthProgramRepository = healthProgramRepository;
            _stringMapService = stringMapService;
        }

        public Email MergeTemplateMail<TEntity>(string entityName, int entityTypeCode, string templateName, Guid regardingEntityId, Guid healthProgramId, bool saveEmail = false, string to = null, bool immediateSend = true, bool sendtodefaultentity = true, Dictionary<string, string>? bodyReplace = null, DateTime? scheduledSend = null) where TEntity : class
        {
            CoreDapperRepository coreDapper = new CoreDapperRepository(_config);
            EntityMetadata getEntityMetadata = _entityMetadataRepository.GetEntityMetadata(entityName);
            StringMap strMapTemplateTypeStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity("TypeEmail", "HealthProgramTemplateSetting", "TemplateTypeStringMap");

            string statusFlag = "#WTSNT"; //Wait to be sent
            if (!immediateSend) statusFlag = "#DRFT"; //Draft

            StringMap strMapStatusCodeStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity(statusFlag, "Email", "StatusCodeStringMap");
            HealthProgramTemplateSetting template = _healthProgramTemplateSettingRepository.GetValue(w => w.EntityMetadataId == getEntityMetadata.EntityMetadataId
                                                                        && w.Name == templateName
                                                                        && w.TemplateTypeStringMapId == strMapTemplateTypeStringMap.StringMapId
                                                                        && w.HealthProgramId == healthProgramId
                                                                        && w.IsDeleted == false);

            if (template != null)
            {
                var dataEntity = coreDapper.GetById<TEntity>(entityName, regardingEntityId);

                DateTime scheduleDate = DateTime.Now;

                if (scheduledSend.HasValue)
                {
                    scheduleDate = scheduledSend.Value;
                }
                else
                {
                    if (template.AttributeName != null && template.ScheduleDays.HasValue)
                    {
                        var fieldDate = dataEntity.GetType().GetProperty(template.AttributeName).GetValue(dataEntity, null);

                        if (fieldDate != null)
                        {
                            scheduleDate =
                                (fieldDate is DateTime ? (DateTime)fieldDate : new DateTime()).AddDays(
                                    template.ScheduleDays.Value);
                        }
                    }
                    else
                    {
                        if (template.ScheduleDays.HasValue)
                            scheduleDate = scheduleDate.AddDays(template.ScheduleDays.Value);
                    }
                }

                if (template != null)
                {
                    var lstRegardingEntity = _regardingEntityRepository.GetRegardingEntity(template.Id, HealthProgramTemplateSetting.EntityName, HealthProgramTemplateSetting.EntityTypeCode);
                    var attachments = new List<Attachment>();

                    lstRegardingEntity.ForEach(w =>
                    {
                        if (w != null)
                        {
                            var info = _attachmentRepository.GetValue(f => f.RegardingEntityId == w.Id);
                            if (info is not null)
                            {
                                attachments.Add(info);
                            }
                        }
                    });

                    TemplateRenderField templateRenderField = null;

                    if (regardingEntityId != Guid.Empty)
                        templateRenderField = _templateService.GetItemsRenderTemplateListByEntity(template.TemplateId.Value, regardingEntityId).FirstOrDefault();
                    else
                        templateRenderField = this.GetTemplateRenderFieldByEntity(template.TemplateId.Value);


                    if (templateRenderField == null)
                    {
                        templateRenderField = this.GetTemplateRenderFieldByEntity(template.TemplateId.Value);
                    }

                    string bodyMessage = templateRenderField.Message;

                    if (bodyReplace is not null)
                    {
                        foreach (var br in bodyReplace)
                        {
                            bodyMessage = bodyMessage.Replace(br.Key, br.Value);
                        }
                    }

                    if (templateRenderField != null)
                    {
                        Email email = new Email();
                        email.Id = Guid.NewGuid();
                        //email.Body = templateRenderField.Message;
                        email.Body = bodyMessage;
                        email.Subject = StripHtml(templateRenderField.Subject);

                        //email.Subject = HtmlToPlainText(templateRenderField.Subject);
                        email.Ccc = template.Ccc;

                        if (!string.IsNullOrEmpty(@to))
                        {
                            if (!string.IsNullOrEmpty(template.To))
                                email.To = template.To + ";" + to;
                            else
                                email.To = to;
                        }
                        else
                            email.To = template.To;

                        email.EmailBoxSettingId = template.EmailBoxSettingId;
                        //email.EmailBoxSettingName = template.EmailBoxSetting.Name; PROPRIEDADE NÃO MAPEADA

                        email.HealthProgramId = template.HealthProgramId;
                        email.MimeType = "text/html";
                        email.Name = templateName + " - " + HtmlToPlainText(templateRenderField.Subject);


                        if (scheduleDate != DateTime.MinValue)
                            email.ScheduleDate = scheduleDate;

                        email.RegardingEntity = this.GenerateEmailRegardingEntity(dataEntity, email.Id, regardingEntityId, entityName, entityTypeCode);

                        // if (@saveEmail)
                        //   {
                        try
                        {
                            var validResult = _emailRepository.Insert(email);

                            if (validResult.IsValid)
                            {
                                var dbEmail = _emailRepository.GetValue(_ => _.Id == email.Id);

                                if (attachments.Any())
                                {
                                    attachments.ForEach(w =>
                                    {
                                        var attachment = new Attachment();
                                        attachment.Id = Guid.NewGuid();
                                        attachment.FileName = w.FileName;
                                        attachment.DocumentBody = w.DocumentBody;
                                        attachment.FileSize = w.FileSize;
                                        attachment.MimeType = w.MimeType;
                                        //attachment.HealthProgramId = w.HealthProgramId; PROPRIEDADE NÃO MAPEADA
                                        attachment.Name = w.FileName;

                                        var regardingEntityAttachment = new RegardingEntity()
                                        {
                                            Name = "Annotation" + " - ",
                                            Id = Guid.NewGuid(),
                                            RegardingObjectIdTarget = dbEmail.Id,
                                            RegardingEntityTypeCodeTarget = Email.EntityTypeCode,
                                            RegardingEntityNameTarget = Email.EntityName,
                                            RegardingObjectIdNameTarget = Email.EntityName,

                                            RegardingObjectIdSource = attachment.Id,
                                            RegardingEntityTypeCodeSource = Attachment.EntityTypeCode,
                                            RegardingEntityNameSource = Attachment.EntityName,
                                            RegardingObjectIdNameSource = Attachment.EntityName
                                        };

                                        attachment.RegardingEntity = regardingEntityAttachment;
                                        _attachmentRepository.Insert(attachment);

                                    });
                                }

                                dbEmail.StatusCodeStringMapId = strMapStatusCodeStringMap.StringMapId;

                                _emailRepository.Update(dbEmail);
                                return dbEmail;
                            }
                            return null;
                        }
                        catch (Exception e)
                        {
                            return null;
                        }
                        // }
                        return email;

                    }
                }

            }

            return null;
        }

        public Email MergeTemplateMailSaveEmail<TEntity>(string entityName, int entityTypeCode, string templateName, Guid regardingEntityId, Guid healthProgramId, bool saveEmail = false, string to = null, bool immediateSend = true, bool sendtodefaultentity = true, Dictionary<string, string>? bodyReplace = null) where TEntity : class
        {
            CoreDapperRepository coreDapper = new CoreDapperRepository(_config);
            EntityMetadata getEntityMetadata = _entityMetadataRepository.GetEntityMetadata(entityName);
            StringMap strMapTemplateTypeStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity("TypeEmail", "HealthProgramTemplateSetting", "TemplateTypeStringMap");

            string statusFlag = "#WTSNT"; //Wait to be sent
            if (!immediateSend) statusFlag = "#DRFT"; //Draft

            StringMap strMapStatusCodeStringMap = _stringMapRepository.GetStringMapByFlagAndAttributeAndEntity(statusFlag, "Email", "StatusCodeStringMap");
            HealthProgramTemplateSetting template = _healthProgramTemplateSettingRepository.GetValue(w => w.EntityMetadataId == getEntityMetadata.EntityMetadataId
                                                                        && w.Name == templateName
                                                                        && w.TemplateTypeStringMapId == strMapTemplateTypeStringMap.StringMapId
                                                                        && w.HealthProgramId == healthProgramId
                                                                        && w.IsDeleted == false);

            if (template != null)
            {
                var dataEntity = coreDapper.GetById<TEntity>(entityName, regardingEntityId);

                DateTime scheduleDate = DateTime.Now;

                if (template.AttributeName != null && template.ScheduleDays.HasValue)
                {
                    var fieldDate = dataEntity.GetType().GetProperty(template.AttributeName).GetValue(dataEntity, null);

                    if (fieldDate != null)
                    {
                        scheduleDate =
                            (fieldDate is DateTime ? (DateTime)fieldDate : new DateTime()).AddDays(
                                template.ScheduleDays.Value);
                    }
                }
                else
                {
                    if (template.ScheduleDays.HasValue)
                        scheduleDate = scheduleDate.AddDays(template.ScheduleDays.Value);
                }

                if (template != null)
                {
                    var lstRegardingEntity = _regardingEntityRepository.GetRegardingEntity(template.Id, HealthProgramTemplateSetting.EntityName, HealthProgramTemplateSetting.EntityTypeCode);
                    var attachments = new List<Attachment>();

                    lstRegardingEntity.ForEach(w =>
                    {
                        if (w != null)
                        {
                            var info = _attachmentRepository.GetValue(f => f.RegardingEntityId == w.Id);
                            if (info is not null)
                            {
                                attachments.Add(info);
                            }
                        }
                    });

                    TemplateRenderField templateRenderField = null;

                    if (regardingEntityId != Guid.Empty)
                        templateRenderField = _templateService.GetItemsRenderTemplateListByEntity(template.TemplateId.Value, regardingEntityId).FirstOrDefault();
                    else
                        templateRenderField = this.GetTemplateRenderFieldByEntity(template.TemplateId.Value);


                    if (templateRenderField == null)
                    {
                        templateRenderField = this.GetTemplateRenderFieldByEntity(template.TemplateId.Value);
                    }

                    string bodyMessage = templateRenderField.Message;

                    if (bodyReplace is not null)
                    {
                        foreach (var br in bodyReplace)
                        {
                            bodyMessage = bodyMessage.Replace(br.Key, br.Value);
                        }
                    }

                    if (templateRenderField != null)
                    {
                        Email email = new Email();
                        email.Id = Guid.NewGuid();
                        //email.Body = templateRenderField.Message;
                        email.Body = bodyMessage;
                        email.Subject = StripHtml(templateRenderField.Subject);

                        //email.Subject = HtmlToPlainText(templateRenderField.Subject);
                        email.Ccc = template.Ccc;

                        if (!string.IsNullOrEmpty(@to))
                        {
                            if (!string.IsNullOrEmpty(template.To))
                                email.To = template.To + ";" + to;
                            else
                                email.To = to;
                        }
                        else
                            email.To = template.To;

                        email.EmailBoxSettingId = template.EmailBoxSettingId;
                        //email.EmailBoxSettingName = template.EmailBoxSetting.Name; PROPRIEDADE NÃO MAPEADA

                        email.HealthProgramId = template.HealthProgramId;
                        email.MimeType = "text/html";
                        email.Name = templateName + " - " + HtmlToPlainText(templateRenderField.Subject);


                        if (scheduleDate != DateTime.MinValue)
                            email.ScheduleDate = scheduleDate;

                        email.RegardingEntity = this.GenerateEmailRegardingEntity(dataEntity, email.Id, regardingEntityId, entityName, entityTypeCode);

                        if (@saveEmail)
                        {
                            try
                            {
                                var validResult = _emailRepository.Insert(email);

                                if (validResult.IsValid)
                                {
                                    var dbEmail = _emailRepository.GetValue(_ => _.Id == email.Id);

                                    if (attachments.Any())
                                    {
                                        attachments.ForEach(w =>
                                        {
                                            var attachment = new Attachment();
                                            attachment.Id = Guid.NewGuid();
                                            attachment.FileName = w.FileName;
                                            attachment.DocumentBody = w.DocumentBody;
                                            attachment.FileSize = w.FileSize;
                                            attachment.MimeType = w.MimeType;
                                            //attachment.HealthProgramId = w.HealthProgramId; PROPRIEDADE NÃO MAPEADA
                                            attachment.Name = w.FileName;

                                            var regardingEntityAttachment = new RegardingEntity()
                                            {
                                                Name = "Annotation" + " - ",
                                                Id = Guid.NewGuid(),
                                                RegardingObjectIdTarget = dbEmail.Id,
                                                RegardingEntityTypeCodeTarget = Email.EntityTypeCode,
                                                RegardingEntityNameTarget = Email.EntityName,
                                                RegardingObjectIdNameTarget = Email.EntityName,

                                                RegardingObjectIdSource = attachment.Id,
                                                RegardingEntityTypeCodeSource = Attachment.EntityTypeCode,
                                                RegardingEntityNameSource = Attachment.EntityName,
                                                RegardingObjectIdNameSource = Attachment.EntityName
                                            };

                                            attachment.RegardingEntity = regardingEntityAttachment;
                                            _attachmentRepository.Insert(attachment);

                                        });
                                    }

                                    dbEmail.StatusCodeStringMapId = strMapStatusCodeStringMap.StringMapId;

                                    _emailRepository.Update(dbEmail);
                                    return dbEmail;
                                }
                                return null;
                            }
                            catch (Exception e)
                            {
                                return null;
                            }
                        }

                        else 
                        { 
                            email.StatusCodeStringMapId = strMapStatusCodeStringMap.StringMapId;
                        }

                        return email;

                    }
                }

            }

            return null;
        }


        public TemplateRenderField GetTemplateRenderFieldByEntity(Guid templateId)
        {
            TemplateRenderField template = new TemplateRenderField(templateId, templateId);

            //1: Subject, 2: Description, 3: Message"
            for (var index = 1; index <= 3; index++)
            {
                string fieldValue = _templateService.GetBodyTemplateModel(templateId, index);

                template.SetItem((TemplateFieldType)index, fieldValue);
            }

            return template;
        }

        private static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);
            text = text.Replace(">", "");

            return text;
        }

        private RegardingEntity GenerateEmailRegardingEntity<TEntity>(TEntity entity, Guid emailId, Guid regardingEntityId, string entityName, int entityTypeCode, bool defaultentity = true) where TEntity : class
        {
            const string treatmentIdAttribute = "TreatmentId";
            const string diagnosticIdAttribute = "DiagnosticId";

            if (entity != null && entity.GetType().GetProperty(treatmentIdAttribute) != null && entity.GetType().GetProperty(treatmentIdAttribute).GetValue(entity, null) != null && defaultentity)
            {
                var treatmentId = entity.GetType().GetProperty(treatmentIdAttribute).GetValue(entity, null);

                return new RegardingEntity()
                {
                    Name = Treatment.EntityName,
                    Id = Guid.NewGuid(),
                    RegardingObjectIdTarget = (Guid)treatmentId,
                    RegardingEntityTypeCodeTarget = Treatment.EntityTypeCode,
                    RegardingEntityNameTarget = Treatment.EntityName,
                    RegardingObjectIdNameTarget = Treatment.EntityName,

                    RegardingObjectIdSource = emailId,
                    RegardingEntityTypeCodeSource = Email.EntityTypeCode,
                    RegardingEntityNameSource = Email.EntityName,
                    RegardingObjectIdNameSource = Email.EntityName
                };
            }
            else if (entity != null && entity.GetType().GetProperty(diagnosticIdAttribute) != null && entity.GetType().GetProperty(diagnosticIdAttribute).GetValue(entity, null) != null && defaultentity)
            {
                var diagnosticId = entity.GetType().GetProperty(diagnosticIdAttribute).GetValue(entity, null);

                return new RegardingEntity()
                {
                    Name = Diagnostic.EntityName,
                    Id = Guid.NewGuid(),
                    RegardingObjectIdTarget = (Guid)diagnosticId,
                    RegardingEntityTypeCodeTarget = Diagnostic.EntityTypeCode,
                    RegardingEntityNameTarget = Diagnostic.EntityName,
                    RegardingObjectIdNameTarget = Diagnostic.EntityName,

                    RegardingObjectIdSource = emailId,
                    RegardingEntityTypeCodeSource = Email.EntityTypeCode,
                    RegardingEntityNameSource = Email.EntityName,
                    RegardingObjectIdNameSource = Email.EntityName
                };
            }
            else
            {
                return new RegardingEntity()
                {
                    Name = entityName,
                    Id = Guid.NewGuid(),
                    RegardingObjectIdTarget = regardingEntityId,
                    RegardingEntityTypeCodeTarget = entityTypeCode,
                    RegardingEntityNameTarget = entityName,
                    RegardingObjectIdNameTarget = entityName,

                    RegardingObjectIdSource = emailId,
                    RegardingEntityTypeCodeSource = Email.EntityTypeCode,
                    RegardingEntityNameSource = Email.EntityName,
                    RegardingObjectIdNameSource = Email.EntityName
                };
            }
        }

        public Email GetEmailForTokenValidation(EmailTokenValidationModel emailTokenValidationModel)
        {
            var untilDate = DateTime.Now.AddMinutes(-5);
            var healthProgramId = _healthProgramRepository.GetValue(hp => hp.Code == emailTokenValidationModel.ProgramCode).Id;
            var result = new Email();
            var emailStatusStringMapIdSent = _stringMapService.GetStringMapByEntityAndAttributeAndFlag("Email", "StatusCodeStringMap", "#SND").Result.StringMapId;
            var emailStatusStringMapIdValidated = _stringMapService.GetStringMapByEntityAndAttributeAndFlag("Email", "StatusCodeStringMap", "#TOKEN_VALIDATED").Result.StringMapId;

            var emailList = _emailRepository.GetValues(e => e.To == emailTokenValidationModel.Email
                                                    && (e.StatusCodeStringMapId == emailStatusStringMapIdSent || e.StatusCodeStringMapId == emailStatusStringMapIdValidated)
                                                    && e.HealthProgramId == healthProgramId
                                                    && e.IsDeleted == false
                                                    && e.StateCode == true);


            if (emailTokenValidationModel.Name == "#ForgotPasswordToken")
            {
                var emailPasswordChange = emailList.Where(email => email.Name.Contains(emailTokenValidationModel.Name)
                                                 && email.StatusCodeStringMapId == emailStatusStringMapIdSent).ToList()
                                                 .OrderByDescending(sendedOn => sendedOn.SendedOn)
                                                 .FirstOrDefault();
                var emailPasswordChangeValidated = emailList.Where(email => email.Name.Contains(emailTokenValidationModel.Name)
                                                                && email.StatusCodeStringMapId == emailStatusStringMapIdValidated).ToList()
                                                                .OrderByDescending(sendedOn => sendedOn.SendedOn)
                                                                .FirstOrDefault();
                if (emailPasswordChange != null)
                {
                    result = emailPasswordChange;
                }
                else if (emailPasswordChangeValidated != null)
                {
                    result = emailPasswordChangeValidated;
                }
            }

            else if (emailTokenValidationModel.Name == "#REGISTERACCOUNTTOKEN")
            {
                var emailPasswordChange = emailList.Where(email => email.Name.Contains(emailTokenValidationModel.Name)
                                                 && email.StatusCodeStringMapId == emailStatusStringMapIdSent).ToList()
                                                 .OrderByDescending(sendedOn => sendedOn.SendedOn)
                                                 .FirstOrDefault();
                var emailPasswordChangeValidated = emailList.Where(email => email.Name.Contains(emailTokenValidationModel.Name)
                                                                && email.StatusCodeStringMapId == emailStatusStringMapIdValidated).ToList()
                                                                .OrderByDescending(sendedOn => sendedOn.SendedOn)
                                                                .FirstOrDefault();
                if (emailPasswordChange != null)
                    return emailPasswordChange;
                if (emailPasswordChangeValidated != null)
                {
                    result = emailPasswordChangeValidated;
                }
            }
            return result;
        }

        public ValidationResult Save(Email email)
        {
            return _emailRepository.Insert(email);
        }

        public Email GetById(Guid id)
        {
            return _emailRepository.GetValue(_ => _.Id == id);
        }

        static string StripHtml(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}
