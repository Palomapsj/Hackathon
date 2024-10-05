using Care.Api.Models;

namespace Care.Api.Business.Models
{
    public class UserAuthModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? HealthProgramCode { get; set; }
        public List<string>? HealthPrograms { get; set; }
        public string? Login { get; set; }
    }

    public class UserAuthByProgramModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
