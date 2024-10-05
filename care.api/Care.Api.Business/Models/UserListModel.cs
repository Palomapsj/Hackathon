namespace Care.Api.Business.Models
{
    public class UserListModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? UserBirthdate { get; set; }
        public string? UserMobilephone { get; set; }
        public string? UserCPF { get; set; }
        public string? UserPassword { get; set; }

        public string? ProgramCode { get; set; }
    }
}