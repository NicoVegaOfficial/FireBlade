using System;
namespace BlockChain
{
    public class options
    {
        public void show()
        {
            Console.WriteLine("choise a option");
            Console.WriteLine("======================");
            Console.WriteLine("1: Add a user");
            Console.WriteLine("2: Send Payment");
            Console.WriteLine("3: Add status");
            Console.WriteLine("4: Exit");
            int op = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                addUser();
            }
            if (op == 2)
            {
                sendPayment();
            }
            if (op == 3)
            {
                addStatus();
            }
            if (op == 4)
            {

                Environment.Exit(0);
            }
        }
        public void addStatus()
        {
            status s = new status();
            Console.WriteLine("Añade tu nuevo estado");
            string txt = Console.ReadLine();
            continueBlockchain(txt);
        }
        public void addUser()
        {
            accounts a = new accounts();
            Console.WriteLine("Ingresa el nombre de tu cuenta");
            string name = Console.ReadLine();
            string x = a.add(name);
            continueBlockchain(x);
        }
        public void sendPayment()
        {
            payments pay = new payments();
            string sender = Console.ReadLine();
            string rec = Console.ReadLine();
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            string x = pay.send(sender, rec, amount);
            continueBlockchain(x);
        }
        public string startBlockchain(string i)
        {
            genesisBlock gBlock = new genesisBlock();
            string s = gBlock.iniciar(i);
            return s;
        }
        public string continueBlockchain(string i)
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
