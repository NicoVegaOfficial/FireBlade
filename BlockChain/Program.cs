using System;

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                options();
            }
        }

        private static void options()
        {
            Console.WriteLine("choise a option");
            Console.WriteLine("======================");
            Console.WriteLine("1: Add a User");
            Console.WriteLine("2: Exit");
            int op = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                addUser();
            }
            if (op == 2)
            {

                Environment.Exit(0);
            }
        }
        private static void addUser()
        {
            rsaEncryption r = new rsaEncryption();
            accounts a = new accounts();
            Console.WriteLine("Ingresa el nombre de tu cuenta");
            string name = Console.ReadLine();
            string pubKey = r.getPublicKey();
            string x = a.add(name, pubKey);
            continueBlockchain(x);
        }
        private static string startBlockchain(string i)
        {
            genesisBlock gBlock = new genesisBlock();
            string s = gBlock.iniciar(i);
            return s;
        }
        private static string continueBlockchain(string i)
        {
            saveToDisk sd = new saveToDisk();
            newBlock nbl = new newBlock();
            if (lastBlock.block == null)
            {
                string nn = startBlockchain(i);
                string file = "block" + lastBlock.index.ToString();
                sd.save(file, nn);
                return lastBlock.block;

            }
            else
            {
                string nn = nbl.nextBlock(i);
                string file = "block" + lastBlock.index.ToString();
                sd.save(file, nn);
                return nn;
            }
        }
    }
}
