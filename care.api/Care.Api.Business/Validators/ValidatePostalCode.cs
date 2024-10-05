using System.Text.RegularExpressions;

namespace Care.Api.Business.Validators
{
    public class ValidatePostalCode
    {
        public static string Mask(string postalCode)
        {
            postalCode = ClearPostalCode(postalCode);
            return Convert.ToUInt64(postalCode).ToString(@"00000-000");
        }

        private static string ClearPostalCode(string postalCode) => Regex.Replace(postalCode.Trim(), "[^0-9]+", "");
    }
}
