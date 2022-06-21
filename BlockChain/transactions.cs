namespace BlockChain
{
    public class transactions
    {
        public string[] add()
        {
            rsaEncryption rsa = new rsaEncryption();
            int saldo = 100;
            string x = saldo.ToString();
            string[] z = { rsa.encrypt(x) };
            return z;
        }
    }
}
