namespace Care.Api.Business.ServicesReturnMessage
{
    public class ReturnMessage<T>
    {
        public ReturnMessage()
        {
            
        }

        public ReturnMessage(bool success, T value, string additionalMessage = "")
        {
            IsValidData = success;
            Value = value;
            AdditionalMessage = additionalMessage;
        }

        public T? Value { get; set; }
        public bool IsValidData { get; set; }
        public string? AdditionalMessage { get; set; }
        public bool IsUserException { get; set; } = false;
    }
}
