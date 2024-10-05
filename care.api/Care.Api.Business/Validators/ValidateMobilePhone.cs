using System.Text.RegularExpressions;

namespace Care.Api.Business.Validators
{
    public  class ValidateMobilePhone
    {
        public static string Mask(string number)
        {
            string cleanedPhoneNumber = CleanPhone(number);

            if (cleanedPhoneNumber.Length < 10 || cleanedPhoneNumber.Length > 11)            
                throw new ArgumentException("Número de telefone inválido.");            
                        
            string formattedPhoneNumber;
            if (cleanedPhoneNumber.Length == 10)            
                formattedPhoneNumber = Convert.ToUInt64(cleanedPhoneNumber).ToString("(00) 0000-0000");            
            else            
                formattedPhoneNumber = Convert.ToUInt64(cleanedPhoneNumber).ToString("(00) 00000-0000");            

            return formattedPhoneNumber;
        }

        private static string CleanPhone(string number) => Regex.Replace(number.Trim(), "[^0-9]", "");
    }
}
