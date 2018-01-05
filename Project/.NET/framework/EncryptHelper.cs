using System.Text;
using System.Security.Cryptography;

namespace T.Common.Utils
{
    public class EncryptHelper
    {
        static string key = "nobody";

        public static string ToMD5(string source)
        {
            return ToMD5(source, null, true);
        }

        public static string ToMD5(string source, string salt, bool addKey)
        {
            byte[] byteArray = null;
            var md5 = MD5.Create();
            if (string.IsNullOrEmpty(salt))
            {
                if (addKey)
                {
                    byteArray = md5.ComputeHash(Encoding.UTF8.GetBytes($"{source}{key}"));
                }
                else
                {
                    byteArray = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
                }
            }
            else
            {
                if (addKey)
                {
                    byteArray = md5.ComputeHash(Encoding.UTF8.GetBytes($"{source}{key}&salt={salt}"));
                }
                else
                {
                    byteArray = md5.ComputeHash(Encoding.UTF8.GetBytes($"{source}&salt={salt}"));
                }
            }
            var strBuilder = new StringBuilder();
            foreach (byte b in byteArray)
            {
                strBuilder.Append(b.ToString("x2"));
            }
            return strBuilder.ToString().ToUpper();
        }
        
        public static string Hash(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteArray = Encoding.ASCII.GetBytes(str);
            byteArray = md5.ComputeHash(byteArray);
            string hashedValue = "";
            foreach (byte b in byteArray)
            {
                hashedValue += b.ToString("x2");
            }
            return hashedValue;
        }
    }
}