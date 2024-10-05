using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Security
{
    public class CryptographyService : ICryptographyService
    {
        #region Global Variables

        private readonly TripleDESCryptoServiceProvider tripledescryptoserviceprovider =
            new TripleDESCryptoServiceProvider();

        private readonly MD5CryptoServiceProvider md5cryptoserviceprovider = new MD5CryptoServiceProvider();
        private readonly string profarmaCareKey = "Fi@p|c@r&";

        #endregion

        #region Cryptography Methods

        /// <summary>
        /// Encrypt string.
        /// </summary>
        /// <param name="text">Encrypt string</param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            try
            {
                if (text.Trim() == "") return "";
                tripledescryptoserviceprovider.Key =
                    md5cryptoserviceprovider.ComputeHash(Encoding.ASCII.GetBytes(profarmaCareKey));
                tripledescryptoserviceprovider.Mode = CipherMode.ECB;
                var desdencrypt = tripledescryptoserviceprovider.CreateEncryptor();
                var buff = Encoding.ASCII.GetBytes(text);
                return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Decrypt cryptographed string.
        /// </summary>
        /// <param name="text">Cryptographed string to decrypt</param>
        /// <returns></returns>
        public string Decrypt(string text)
        {
            try
            {
                if (text.Trim() == "") return "";
                tripledescryptoserviceprovider.Key =
                    md5cryptoserviceprovider.ComputeHash(Encoding.ASCII.GetBytes(profarmaCareKey));
                tripledescryptoserviceprovider.Mode = CipherMode.ECB;
                var desdencrypt = tripledescryptoserviceprovider.CreateDecryptor();
                try
                {
                    var buff = Convert.FromBase64String(text);
                    return Encoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                }
                catch
                {
                    return text;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion    
    }
}
