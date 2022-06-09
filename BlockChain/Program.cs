using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
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
    public class block
    {
        public int index { get; set; }
        public string prevHash { get; set; }
        public long Timestamp { get; set; }
        public string data { get; set; }
    }
    public class genesisBlock : block
    {
        public string iniciar()
        {
            transactions nvCoin = new transactions();
            block genBlock = new block
            {
                index = 0,
                prevHash = "a6325ed86cc4af78beeb4b2ca801ea948a627e12d406445018f3c95a57370232f7607bf2946eafdba53443e5142aa40ea1ec1ccdcda5002441104dff685acb23", //nvCoin
                Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                data = nvCoin.coinbase()
            };
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string txt = JsonSerializer.Serialize(genBlock, options);
            return txt;
        }
    }

    public class newBlock : block
    {
        public void nextBlock()
        {

        }
    }
    public class calcHash
    {
        public string sha512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }
                return hashedInputStringBuilder.ToString().ToLower();
            }
        }
    }
    public class transactions
    {
        public string coinbase()
        {
            rsaEncryption rsa = new rsaEncryption();
            int serie = 1;
            string x = serie.ToString();
            string z = rsa.encrypt(x);
            return z;
        }
        public string add(string x)
        {
            return x;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            startBlockchain();
            static void startBlockchain()
            {
                genesisBlock gBlock = new genesisBlock();
                Console.WriteLine(gBlock.iniciar());
            }
            static void continueBlockchain()
            {
                newBlock nBlock = new newBlock();

            }
            static void leer()
            {
                genesisBlock gBlock = new genesisBlock();
                string z = gBlock.iniciar();
                genesisBlock? genesisBlock = JsonSerializer.Deserialize<genesisBlock>(z);
                Console.WriteLine($"{genesisBlock?.index}");
            }
        }
    }
}
