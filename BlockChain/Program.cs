using System;
using System.Text.Json;

namespace BlockChain
{
    public class Program
    {
        static string x = null;
        static void Main(string[] args)
        {
            for (int x = 0; x < 10; x++)
            {
                continueBlockchain();
            }
        }
        public static string startBlockchain()
        {
            genesisBlock gBlock = new genesisBlock();
            string s = gBlock.iniciar();
            return s;
        }
        static void continueBlockchain()
        {
            newBlock nbl = new newBlock();
            if (x == null)
            {
                x = startBlockchain();
                Console.WriteLine(x);
            }
            else
            {
                string nn = nbl.nextBlock();
                Console.WriteLine(nn);
            }
        }
        static void leer()
        {
            genesisBlock gBlock = new genesisBlock();
            string z = gBlock.iniciar();
            genesisBlock genesisBlock = JsonSerializer.Deserialize<genesisBlock>(z);
            Console.WriteLine(genesisBlock.index);
        }
        static string cHash(string i)
        {
            calcHash sha = new calcHash();
            string x = sha.sha512(i);
            return x;
        }
    }
}
