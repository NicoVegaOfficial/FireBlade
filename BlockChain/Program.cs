using System;

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            rsaEncryption r = new rsaEncryption();
            sign s = new sign();
            string txt = "hola";
            string x = s.signData(txt);
            string y = txt + "," + x;
            for (int i = 0; i <= 10; i++)
            {
                continueBlockchain(y);
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
