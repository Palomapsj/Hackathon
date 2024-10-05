namespace Care.Api.Models;
public partial class Unsubscribe : BaseEntity
{
    public string EmailUnsubscribed { get; set; }
    public virtual HealthProgram HealthProgram { get; set; }

    public Guid HealthProgramId { get; set; }
}
