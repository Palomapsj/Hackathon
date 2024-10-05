namespace Care.Api.Business.Models
{
    public class UserCreateModel
    {
        public Guid Id { get; set; }
        public string? EmailAddress { get; set; }
        public string? Telephone { get; set; }
        public string? Mobilephone { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Profile { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Cpf { get; set; }
        public required string ProgramCode { get; set; }

        public int? Status { get; set; }
    }
}