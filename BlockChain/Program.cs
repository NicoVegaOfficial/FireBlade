using System;

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

    }
}
