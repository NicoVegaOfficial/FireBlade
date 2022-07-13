using System;

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            options();
        }

        private static void options()
        {
            Console.WriteLine("choise a option");
            Console.WriteLine("1: Add a User");
            int op = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                addUser();
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
