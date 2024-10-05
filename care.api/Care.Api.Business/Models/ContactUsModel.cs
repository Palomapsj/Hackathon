namespace Care.Api.Business.Models;

public class ContactUsModel
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Message { get; set; }
    public required string ProgramCode { get; set; }
}