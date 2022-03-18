using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography;
namespace BlockChain
{
    public class block
    {
        public int index { get; set; }
        public string prevHash { get; set; }
        public long Timestamp { get; set; }
        public string data { get; set; }
    }
    public class genesisBlock
    {
        public void iniciar()
        {
            var genBlock = new block
            {
                index = 0,
                prevHash = "891e2f58bc689b757413684ad49e53b4cd967d245c2594586548bffe20f48324a6d95634a45afde174a2e297bd20807a5d2e96d7724760ea2fb96220ac3b270f",
                Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                data = "Datos"
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string txt = JsonSerializer.Serialize(genBlock, options);
            Console.WriteLine(txt);
        }
    }
    public class newBlock
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
                return hashedInputStringBuilder.ToString();
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            genesisBlock nBlock = new genesisBlock();
            calcHash nhash = new calcHash();
            nBlock.iniciar();
        }
    }
}
