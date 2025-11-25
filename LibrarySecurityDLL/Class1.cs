using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySecurityDLL
{
    public class LibrarySecurity
    {
        private static readonly byte[] key;

        static LibrarySecurity() //Need to set some default key in this case, normally needs more protection but within this scope it should be fine
        {
            string baseKey = "CSE445-Assignment5-Key";
            using (var value = SHA256.Create())
            {
                key = value.ComputeHash(Encoding.UTF8.GetBytes(baseKey));
            }

        }

        public static string EncryptString(string input)
        {
            //Setup necessary AES encryption content
            var aes = Aes.Create();
            aes.Key = key;

            var stringEncrypt = new MemoryStream();
            stringEncrypt.Write(aes.IV, 0, aes.IV.Length);

            var encrypting = aes.CreateEncryptor();
            var crypto = new CryptoStream(stringEncrypt, encrypting, CryptoStreamMode.Write);

            //Convert plain text to bytes then encrypt
            byte[] plain = Encoding.UTF8.GetBytes(input);
            crypto.Write(plain, 0, plain.Length);
            crypto.FlushFinalBlock();
            return Convert.ToBase64String(stringEncrypt.ToArray());
        }

        public static string DecryptString(string input)
        {
            try
            {
                //Convert string back to byte array for decryption
                byte[] value = Convert.FromBase64String(input);
                var aes = Aes.Create();
                aes.Key = key;

                byte[] iv = new byte[16];
                Array.Copy(value, 0, iv, 0, 16);

                aes.IV = iv;

                var decrypting = aes.CreateDecryptor();

                var memStreamDec = new MemoryStream(value, 16, value.Length - 16);
                var crypto = new CryptoStream(memStreamDec, decrypting, CryptoStreamMode.Read);
                var streamReader = new StreamReader(crypto);

                return streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public static string Hash(string value)
        {
            string salt = "CSE445Assignment6";
            using (var sha = new SHA512CryptoServiceProvider())
            {
                var hashedString = sha.ComputeHash(Encoding.Default.GetBytes(value + salt));
                return Convert.ToBase64String(hashedString);
            }
        }
    }
}
