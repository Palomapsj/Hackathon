using System.Text.RegularExpressions;

namespace Care.Api.Business.Validators
{
    public class ValidateCPF
    {
        public static bool IsValid(string cpf)
        {
            cpf = ClearCPF(cpf);

            if (!IsLengthValid(cpf) || IsAllDigitsEqual(cpf))
                return false;

            int[] multiplicators1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicators2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string calculatedDigit = CalculateDigit(cpf, multiplicators1);
            calculatedDigit = CalculateDigit(cpf + calculatedDigit, multiplicators2);

            return cpf.EndsWith(calculatedDigit);
        }

        public static string Mask(string cpf)
        {
            cpf = ClearCPF(cpf);
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        private static string ClearCPF(string cpf) => Regex.Replace(cpf.Trim(), "[^0-9]+", "");

        private static bool IsLengthValid(string cpf) => cpf.Length == 11;

        private static bool IsAllDigitsEqual(string cpf) => new string(cpf[0], cpf.Length) == cpf;

        private static string CalculateDigit(string cpf, int[] multipliers)
        {
            int sum = 0;

            for (int i = 0; i < multipliers.Length; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * multipliers[i];
            }

            int remainder = sum % 11;
            return (remainder < 2) ? "0" : (11 - remainder).ToString();
        }
    }
}
