namespace Care.Api.Business.ServicesReturnMessage
{
    public class ValidationMessage
    {
        public string PropertyName { get; private set; }
        public string ErrorMessage { get; private set; }

        public ValidationMessage(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }    
}
