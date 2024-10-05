using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Care.Api.Business.Enums.EnumsHelper;

namespace Care.Api.Business.Models
{
    public class TemplateRenderField
    {
        #region Properties
        public Guid Id
        {
            get; private set;
        }
        public Guid EntityId
        {
            get; private set;
        }
        public string Subject
        {
            get; private set;
        }
        public string Description
        {
            get; private set;
        }
        public string Message
        {
            get; private set;
        }
        #endregion

        public TemplateRenderField(Guid id, Guid EntityId)
        {
            this.Id = id;
            this.EntityId = EntityId;

        }

        public void SetItem(TemplateFieldType templateFieldType, string value)
        {
            if (TemplateFieldType.Subject == templateFieldType)
            {
                this.Subject = value;
            }
            else if (TemplateFieldType.Description == templateFieldType)
            {
                this.Description = value;

            }
            else
            {
                this.Message = value;
            }
        }

    }
}
