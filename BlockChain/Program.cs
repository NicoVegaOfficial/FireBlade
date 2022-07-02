using System;

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string s = Console.ReadLine();
                continueBlockchain(s);
            }
        }
        private static string startBlockchain(string i)
        {
            genesisBlock gBlock = new genesisBlock();
            string s = gBlock.iniciar(i);
            return s;
        }
        private static void continueBlockchain(string i)
        {
            newBlock nbl = new newBlock();
            if (lastBlock.block == null)
            {
                lastBlock.block = startBlockchain(i);
                Console.WriteLine(lastBlock.block);
            }
            else
            {
                string nn = nbl.nextBlock(i);
                Console.WriteLine(nn);
            }
        }

    }
}
