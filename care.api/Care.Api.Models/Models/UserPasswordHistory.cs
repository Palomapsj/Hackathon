namespace Care.Api.Models.Models
{
    public partial class UserPasswordHistory : BaseEntity
    {        
        public Guid? HealthProgramId { get; set; }
        public Guid UserId { get; set; }
        public string PreviousPassword { get; set; }
        public string CurrentPassword { get; set; }

        public virtual HealthProgram? HealthProgram { get; set; }
        public virtual User User { get; set; }
    }
}
