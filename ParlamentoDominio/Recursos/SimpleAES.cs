using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ParlamentoDominio.Recursos
{
    public class SimpleAES
    {
        private static readonly byte[] Key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
        private static readonly byte[] Vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };
        private static readonly ICryptoTransform Encryptor;
        private static readonly ICryptoTransform Decryptor;
        private static readonly UTF8Encoding Encoder;

        static SimpleAES()
        {
            RijndaelManaged rm = new RijndaelManaged();
            Encryptor = rm.CreateEncryptor(Key, Vector);
            Decryptor = rm.CreateDecryptor(Key, Vector);
            Encoder = new UTF8Encoding();
        }

        public static string Encrypt(string unencrypted)
        {
            return HttpServerUtility.UrlTokenEncode(Encrypt(Encoder.GetBytes(unencrypted)));
        }

        public static string Decrypt(string encrypted)
        {
            return Encoder.GetString(Decrypt(HttpServerUtility.UrlTokenDecode(encrypted)));
        }

        public static byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, Encryptor);
        }

        public static byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, Decryptor);
        }

        protected static byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}