namespace Care.Api.Business.Models
{
    public class UserPasswordHistoryResult
    {
        public string? Message { get; private set; }
        public bool IsValid { get; private set ; }

        public UserPasswordHistoryResult(bool isValid, string message = "Você não pode inserir uma senha igual às últimas 10")
        {
            IsValid = isValid;
            Message = message;  
        }
    }
}