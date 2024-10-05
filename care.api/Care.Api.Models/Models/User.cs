using Care.Api.Models;
using Care.Api.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Care.Api.Models.Models;

namespace Care.Api.Models;

public partial class User : BaseEntity
{
    [NotMapped]
    public static int EntityTypeCode => 1302;

    [NotMapped]
    public static string EntityName => "User";

    [NotMapped]
    public static Guid EntityId => Guid.Parse("d564b272-040e-4402-8773-91f17ac6e4e6");

    public string? Name { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public string? Mobilephone { get; set; }

    public int? Language { get; set; }

    public DateTime? LastAccess { get; set; }

    public int? AccessTry { get; set; }

    public DateTime? DateAccessTry { get; set; }

    public int? Status { get; set; }

    public bool? IsAdmin { get; set; }

    public Guid? DeletedBy { get; set; }

    public string? DeletedByName { get; set; }

    public string? ReasonStateCode { get; set; }

    public string? ReasonDeleted { get; set; }

    public string? FriendlyCode { get; set; }

    public string? ImportCode { get; set; }

    public string? InternalControl { get; set; }

    public Guid? ProfileId { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<AccountSettingsByProgram> AccountSettingsByPrograms { get; } = new List<AccountSettingsByProgram>();

    public virtual ICollection<Chat> Chats { get; } = new List<Chat>();

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();

    public virtual ICollection<Diagnostic> Diagnostics { get; } = new List<Diagnostic>();

    public virtual ICollection<DoctorByProgram> DoctorByProgramConsultants { get; } = new List<DoctorByProgram>();

    public virtual ICollection<DoctorByProgram> DoctorByProgramSystemUsers { get; } = new List<DoctorByProgram>();

    public virtual ICollection<HealthProfessionalByProgram> HealthProfessionalByPrograms { get; } = new List<HealthProfessionalByProgram>();

    public virtual ICollection<HealthProfessional> HealthProfessionals { get; } = new List<HealthProfessional>();

    public virtual ICollection<LogisticsSchedule> LogisticsSchedules { get; } = new List<LogisticsSchedule>();

    public virtual ICollection<MedicamentAccess> MedicamentAccesses { get; } = new List<MedicamentAccess>();

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();

    public virtual Profile? Profile { get; set; }

    public virtual ICollection<Representative> Representatives { get; } = new List<Representative>();

    public virtual StringMap? StatusCodeStringMap { get; set; }

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();

    public virtual ICollection<UserSystemLog> UserSystemLogs { get; } = new List<UserSystemLog>();

    public virtual ICollection<AccessProfile> AccessProfiles { get; } = new List<AccessProfile>();

    public virtual ICollection<UserPasswordHistory>? UserPasswordHistorys { get; set; }

    public virtual ICollection<UrlShortener>? UrlShorteners { get; set; }

    public virtual ICollection<ClickTracking>? ClickTrackings { get; set; }

    public virtual ICollection<TemplateConfiguration>? TemplateConfigurations { get; set; }

}
