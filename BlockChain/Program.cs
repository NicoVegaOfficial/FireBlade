using System;
namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {/*
            sign s = new sign();
            rsaEncryption r = new rsaEncryption();
            string a = "Hola mundo";
            string b = s.signData(a);
            string c = s.getKey();
            byte[] aa = new byte[a.Length];
            byte[] bb = new byte[b.Length];
            bool d = s.VerifySignedHash(aa, bb, sign.key);
            Console.WriteLine(d);*/
            //Console.WriteLine(sign.key.Q);
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
            accounts a = new accounts();
            Console.WriteLine("Ingresa el nombre de tu cuenta");
            string name = Console.ReadLine();
            string x = a.add(name);
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
