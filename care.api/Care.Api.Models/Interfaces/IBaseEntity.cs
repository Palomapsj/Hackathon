using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime? CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        DateTime? DeletedOn { get; set; }

        Guid? CreatedBy { get; set; }
        string? CreatedByName { get; set; }

        Guid? ModifiedBy { get; set; }
        string? ModifiedByName { get; set; }

        Guid? OwnerId { get; set; }
        string? OwnerIdName { get; set; }


        bool? StateCode { get; set; }
        bool IsDeleted { get; set; }
    }
}
