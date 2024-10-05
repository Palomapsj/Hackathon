using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Care.Api.Business.Validators
{
    public class ValidateEmail
    {
        private const string EmailPatternValidation = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public static bool IsValid(string email)
        {
            return Regex.IsMatch(email, EmailPatternValidation);
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return HasValidMXRecords(mailAddress.Host);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (System.Net.Sockets.SocketException)
            {
                return false; 
            }
        }

        static bool HasValidMXRecords(string domain)
        {
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(domain);

                foreach (var record in hostEntry?.AddressList)
                {
                    if (record.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                
            }

            return false;
        }

    }
}
