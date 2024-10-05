using Care.Api.Business.Models;
using Care.Api.Models;
using ValidationResult = Care.Api.Repository.Validation.ValidationResult;

namespace Care.Api.Business.Interfaces
{
    public interface IEmailService
    {
        Email MergeTemplateMail<TEntity>(string entityName, int entityTypeCode, string templateName, Guid regardingEntityId, Guid healthProgramId, bool @saveEmail = false,
                                                string @to = null, bool immediateSend = true, bool sendtodefaultentity = true, Dictionary<string, string>? bodyReplace = null, DateTime? scheduledSend = null) where TEntity : class;
        Email MergeTemplateMailSaveEmail<TEntity>(string entityName, int entityTypeCode, string templateName, Guid regardingEntityId, Guid healthProgramId, bool saveEmail = false, string to = null, bool immediateSend = true, bool sendtodefaultentity = true, Dictionary<string, string>? bodyReplace = null) where TEntity : class;
        
        Email GetEmailForTokenValidation(EmailTokenValidationModel emailTokenValidationModel);

        ValidationResult Save(Email email);

        Email GetById(Guid id);
    }
}
