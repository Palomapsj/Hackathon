using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Care.Api.Repository.Repositories
{
    public class TemplateRepository : CommonRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public IEnumerable<Template> Find(Expression<Func<Template, bool>> predicate)
        {
            try
            {
                var templates = _careDbContext.Templates.Where(predicate).ToList();

                return templates;

            }
            catch (Exception ex) 
            {

                return null;
            }
        }

        public string GetBodyTemplateModel(Guid templateId, int templateFieldType)
        {
            string result = string.Empty;

            if(templateFieldType == 1)
            {
                var template = _careDbContext.Templates.Where(_ => _.Id == templateId).FirstOrDefault();

                if(template is not null) { result = template.Subject; }
            }
            else if (templateFieldType == 2)
            {
                var template = _careDbContext.Templates.Where(_ => _.Id == templateId).FirstOrDefault();

                if (template is not null) { result = template.Description; }
            }
            else
            {
                var template = _careDbContext.Templates.Where(_ => _.Id == templateId).FirstOrDefault();

                if (template is not null) { result = template.Message; }
            }

            return result;
        }


        public Template GetTemplateByNameSMS(string templateName, Guid? healthprogramid)
        {

            var smsType = new Guid("F21FF809-6924-4F51-8EF0-595347622ABD");
            try
            {
                var template = _careDbContext.Templates
                    .Where(_ => _.Name == templateName 
                           && _.HealthProgramId == healthprogramid
                           && _.TemplateTypeStringMapId == smsType)
                    .FirstOrDefault();

                return template;
            }
            catch (Exception ex)
            { }
            return null;

        }

    }
}
