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
    public class lastBlock
    {
        public static string data;
    }
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
        public int nonce { get; set; }
    }
    public class genesisBlock : block
    {
        public string iniciar()
        {
            transactions tx = new transactions();
            int id = 0;
            string phash = "a6325ed86cc4af78beeb4b2ca801ea948a627e12d406445018f3c95a57370232f7607bf2946eafdba53443e5142aa40ea1ec1ccdcda5002441104dff685acb23"; //nvCoin
            long tm = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string dt = tx.add();

            block genBlock = new block
            {
                index = id,
                prevHash = phash,
                Timestamp = tm,
                data = dt
            };
            JsonSerializerOptions op = new JsonSerializerOptions { WriteIndented = true };
            string x = JsonSerializer.Serialize(genBlock, op);
            return x;
        }
    }

    public class newBlock : block
    {
        public string nextBlock(string i)
        {
            transactions tx = new transactions();
            int id = 0;
            string phash = i;
            long tm = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string dt = tx.add();

            block genBlock = new block
            {
                index = id,
                prevHash = phash,
                Timestamp = tm,
                data = dt
            };
            JsonSerializerOptions op = new JsonSerializerOptions { WriteIndented = true };
            string x = JsonSerializer.Serialize(genBlock, op);
            return x;
        }
        private static string getHash(string i)
        {
            calcHash ch = new calcHash();
            string x = ch.sha512(i);
            return x;
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
        public string add()
        {
            rsaEncryption rsa = new rsaEncryption();
            int saldo = 100;
            string x = saldo.ToString();
            string z = rsa.encrypt(x);
            return z;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(startBlockchain());


        }
        static void continueBlockchain()
        {
            calcHash hsh = new calcHash();
            newBlock nbl = new newBlock();
            string x = startBlockchain();
            Console.WriteLine(x);
            Console.WriteLine("==================");
            string n = hsh.sha512(x);
            string nn = nbl.nextBlock(n);
            Console.WriteLine(nn);
        }
        static void leer()
        {
            genesisBlock gBlock = new genesisBlock();
            string z = gBlock.iniciar();
            genesisBlock genesisBlock = JsonSerializer.Deserialize<genesisBlock>(z);
            Console.WriteLine(genesisBlock.index);
        }
        public static string startBlockchain()
        {
            genesisBlock gBlock = new genesisBlock();
            string s = gBlock.iniciar();
            return s;
        }
        static string cHash(string i)
        {
            calcHash sha = new calcHash();
            string x = sha.sha512(i);
            return x;
        }
    }
}
