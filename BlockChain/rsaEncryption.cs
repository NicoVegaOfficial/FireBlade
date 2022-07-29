using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain
{
    public class rsaEncryption
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters key;
        public rsaEncryption()
        {
            key = csp.ExportParameters(true);
        }
        public string getPublicKey()
        {
            byte[] q = csp.ExportRSAPublicKey();
            string z = string.Join("", q);
            return z;
        }

        public string getPrivateKey()
        {
            byte[] q = csp.ExportRSAPrivateKey();
            string z = string.Join("", q);
            return z;
        }
        public string encrypt(string txt)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(key);
            var data = Encoding.Unicode.GetBytes(txt);
            var cypher = csp.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }
        public string decrypt(string crypto)
        {
            var dataBytes = Convert.FromBase64String(crypto);
            csp.ImportParameters(key);
            var txt = csp.Decrypt(dataBytes, false);
            return Encoding.Unicode.GetString(txt);
        }
        public string signData(string i)
        {
            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            byte[] originalData = ByteConverter.GetBytes(i);
            byte[] signedData;
            signedData = HashAndSignBytes(originalData, key);
            if (VerifySignedHash(originalData, signedData, key))
            {
                string x = string.Join("", signedData);
                return x;
            }
            else
            {
                return null;
            }
        }
        private static byte[] HashAndSignBytes(byte[] DataToSign, RSAParameters Key)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(Key);
                return rsa.SignData(DataToSign, SHA512.Create());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public bool VerifySignedHash(byte[] DataToVerify, byte[] SignedData, RSAParameters Key)
        {
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(Key);
                return RSAalg.VerifyData(DataToVerify, SHA512.Create(), SignedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}
