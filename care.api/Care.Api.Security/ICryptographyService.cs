using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Security
{
    public interface ICryptographyService
    {
        public string Encrypt(string text);
        public string Decrypt(string text);
    }
}
