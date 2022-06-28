namespace BlockChain
{
    public class transactions
    {
        public string[] add()
        {
            rsaEncryption rsa = new rsaEncryption();
            float saldo = 100.00000000f;
            string x = saldo.ToString();
            string[] z = { rsa.encrypt(x) };
            return z;
        }
    }
}
