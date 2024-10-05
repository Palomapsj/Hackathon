using Care.Api.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Care.Api.Models
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public virtual string? CreatedByName { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public Guid? OwnerId { get; set; }
        public string? OwnerIdName { get; set; }
        public bool IsDeleted { get; set; }
        public bool? StateCode { get; set; }
        public Guid? StatusCodeStringMapId { get; set; }
        public string? EntityOriginalValues { get; set; }

        [NotMapped]
        public Guid? CurrentUserId { get; set; }
    }
}
