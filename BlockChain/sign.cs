using System;
using System.Security.Cryptography;
using System.Text;
namespace BlockChain
{
    public class sign
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        public static RSAParameters key;
        public sign()
        {
            key = rsa.ExportParameters(true);
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
        public string getKey()
        {
            string x = string.Join("", key.Q);
            return x;
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
