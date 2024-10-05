using Care.Api.Models;
using System.Linq.Expressions;

namespace Care.Api.Repository.Interfaces
{
    public interface ITemplateRepository : ICommonRepository<Template>
    {

        string GetBodyTemplateModel(Guid templateId, int templateFieldType);
        IEnumerable<Template> Find(Expression<Func<Template, bool>> predicate);
        Template GetTemplateByNameSMS(string templateName, Guid? healthprogramid);
    }
}
