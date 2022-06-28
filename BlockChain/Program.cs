using System;
using System.Text.Json;

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
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
            if (lastBlock.block == null)
            {
                lastBlock.block = startBlockchain();
                Console.WriteLine(lastBlock.block);
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
