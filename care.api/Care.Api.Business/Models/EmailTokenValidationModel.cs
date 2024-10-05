namespace Care.Api.Business.Models
{
    public class EmailTokenValidationModel
    {
        public string? Name { get; set; }
        public string? Token { get; set; }
        public string? Email { get; set; }
        public string? ProgramCode { get; set; }
        public string? Password { get; set; }
    }
}
