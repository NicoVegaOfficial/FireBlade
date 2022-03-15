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
        public string data { get; set; }
    }
    public class genesisBlock
    {
        public void iniciar()
        {
            var genBlock = new block
            {
                index = 0,
                prevHash = "5a51818c86168c73ad4333f8dc38a739bbe7f31b68506d5756f5bec7b4a96d4b",
                data = "Datos"
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string txt = JsonSerializer.Serialize(genBlock, options);
            Console.WriteLine(txt);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            genesisBlock nBlock = new genesisBlock();
            nBlock.iniciar();
        }

    }
}
