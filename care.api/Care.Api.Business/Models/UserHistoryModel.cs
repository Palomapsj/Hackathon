using System.Reflection.Metadata.Ecma335;

namespace Care.Api.Business.Models
{
    public class UserHistoryModel
    {

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }


        public string GetAction(string action)
        {
            if (action.ToUpper() == "[LOGIN_SUCCESSFUL]")
                return "LOGIN REALIZADO";

            else if (action.ToUpper() == "[LOGIN_FAIL]")
                return "LOGIN FALHOU";

            return string.Empty;
        }
    }
}
