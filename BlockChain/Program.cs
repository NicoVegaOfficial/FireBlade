using System;
using System.Text.Json;

namespace BlockChain
{
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
