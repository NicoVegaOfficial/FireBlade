using System;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
using System.Text;


namespace BlockChain
{
    public class rsaEncryption
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters privateKey;
        private RSAParameters publicKey;
        public rsaEncryption()
        {
            privateKey = csp.ExportParameters(true);
            publicKey = csp.ExportParameters(false);
        }
        public string getPublicKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, publicKey);
            return sw.ToString();
        }

        public string getPrivateKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, privateKey);
            return sw.ToString();
        }
        public string encrypt(string txt)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publicKey);
            var data = Encoding.Unicode.GetBytes(txt);
            var cypher = csp.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }
        public string Decrypt(string crypto)
        {
            var dataBytes = Convert.FromBase64String(crypto);
            csp.ImportParameters(privateKey);
            var txt = csp.Decrypt(dataBytes, false);
            return Encoding.Unicode.GetString(txt);
        }
    }

}
