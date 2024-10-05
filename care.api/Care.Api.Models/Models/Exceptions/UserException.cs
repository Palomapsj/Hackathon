namespace Care.Api.Models.Exceptions
{
    /// <summary>
    /// Define as exceções que podem ser visualizadas pelo usuário.
    /// </summary>
    public class UserException : Exception
    {
        public UserException() { }

        public UserException(string? message) : base(message) { }
    }
}
