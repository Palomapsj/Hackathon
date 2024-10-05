using System.Security.Cryptography;
using Care.Api.Business.ServicesReturnMessage;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
using System.Web;
using Care.Api.Business.Models;
using Care.Api.Models;
using wsCorreios;
using System.Globalization;
using System.Text;
using Care.Api.Business.Validators;

namespace Care.Api.Business.Helper
{
    public static class Helper
    {
        public static string IfNotEmptyReturnValue(this string? value)
        {
            if (value is not null)
                return value;

            return string.Empty;
        }

        public static string ExtractInitialsFromName(string name)
        {
            string[] excecoes = new string[] { "e", "de", "da", "das", "do", "dos" };
            var palavras = new Queue<string>();
            foreach (var palavra in name.Split(' '))
            {
                if (!string.IsNullOrEmpty(palavra))
                {
                    var emMinusculo = palavra.ToLower();
                    var letras = emMinusculo.ToCharArray();
                    if (!excecoes.Contains(emMinusculo)) letras[0] = char.ToUpper(letras[0]);
                    palavras.Enqueue(new string(letras));
                }
            }

            Regex initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]??");
            var result = initials.Replace(string.Join(" ", palavras), "$1").Where(w => w.ToString() == w.ToString().ToUpper() && !string.IsNullOrEmpty(w.ToString().Trim()));

            return string.Join("", result);
        }

        public static string GetRandomKey(int len)
        {
            byte[] data = new byte[1];
            int maxSize = len;
            string ltrs = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chars = ltrs.ToCharArray();
            var result = string.Empty;

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(data);
                data = new byte[maxSize];
                rng.GetNonZeroBytes(data);
            }

            var resultBytes = data.Select(w => chars[w % (chars.Length)]).ToList();

            foreach (var item in resultBytes)
            {
                result += item.ToString();
            }

            return result;
        }

        private static Stream ExecuteRequest(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            var resp = req.GetResponse();

            return resp.GetResponseStream();
        }

     

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadius = 6371; // Raio da Terra em quilômetros

            double dlat = ToRadians(lat2 - lat1);
            double dlon = ToRadians(lon2 - lon1);

            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadius * c;
        }

        public static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static string FormatFullAddress(TreatmentAddress address)
        {
            string formattedZipCode = GetAddressFormattedField(address.AddressPostalCode, ", ");
            string formattedStreet = GetAddressFormattedField(address.AddressName);
            string formattedNumber = GetAddressFormattedField(address.AddressNumber, ", ");
            string formattedComplement = GetAddressFormattedField(address.AddressComplement, ", ");
            string formattedDistrict = GetAddressFormattedField(address.AddressDistrict, " - ");
            string formattedCity = GetAddressFormattedField(address.AddressCity, ", ");
            string formattedState = GetAddressFormattedField(address.AddressState, " - ");

            string fullAddress = $"{formattedStreet}{formattedNumber}{formattedComplement}{formattedDistrict}{formattedCity}{formattedState}{formattedZipCode}";

            return fullAddress.Trim();
        }

        public static string FormatFullAddress(enderecoERP address)
        {
            string formattedZipCode = GetAddressFormattedField(address.cep, ", ");
            string formattedStreet = GetAddressFormattedField(address.end);
            string formattedComplement = GetAddressFormattedField(address.complemento2, ", ");
            string formattedDistrict = GetAddressFormattedField(address.bairro, " - ");
            string formattedCity = GetAddressFormattedField(address.cidade, ", ");
            string formattedState = GetAddressFormattedField(address.uf, " - ");

            string fullAddress = $"{formattedStreet}{formattedComplement}{formattedDistrict}{formattedCity}{formattedState}{formattedZipCode}";

            return fullAddress.Trim();
        }

        private static string GetAddressFormattedField(string fieldValue, string separator = "")
        {
            return string.IsNullOrEmpty(fieldValue) ? string.Empty : $"{separator}{fieldValue}";
        }

        public static string GetFileExtensionFromMimeType(string mimeType)
        {
            if (string.IsNullOrEmpty(mimeType))
                return string.Empty;

            switch (mimeType)
            {
                case "image/jpeg":
                    return ".jpg";
                case "image/png":
                    return ".png";
                case "image/gif":
                    return ".gif";
                case "image/bmp":
                    return ".bmp";
                default:
                    return string.Empty;
            }
        }

        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();

        }

        public static string MaskEmail(string email)
        {
            int indexAtSign = email.IndexOf('@');
            if (indexAtSign <= 0)
                return email;

            string partBeforeAtSign = email.Substring(0, indexAtSign);
            string partAfterAtSign = email.Substring(indexAtSign);
            string maskedPart = MaskPart(partBeforeAtSign, 4, 'x');

            return $"{maskedPart}{partAfterAtSign}";
        }

        private static string MaskPart(string maskPart, int maxCharacters, char mask)
        {
            if (maskPart.Length > maxCharacters)
                return maskPart.Substring(0, maxCharacters).PadRight(maskPart.Length, mask);

            return maskPart.PadRight(maxCharacters, mask);
        }

        public static string alfanumericoAleatorio(int tamanho)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        public static void ValidatePatientCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || !ValidateCPF.IsValid(cpf))
                throw new ArgumentException("CPF inválido");
        }

        public static string RemoveCaracterEspecial(string text)
        {
            return Regex.Replace(text.Trim(), "[^0-9a-zA-Z]+", "");
        }

        public static bool ValidateUserEmail(string email)
        {
            bool result = true;

            if (!ValidateEmail.IsValidEmail(email))
                result = false;

            if (!string.IsNullOrEmpty(email) && !ValidateEmail.IsValid(email))
                result = false;

            return result;
        }

        public static string RemoveAccentuation(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}