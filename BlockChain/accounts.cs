namespace BlockChain
{
    public class accounts
    {
        public string add(string txt)
        {
            sign s = new sign();
            rsaEncryption r = new rsaEncryption();
            string pubKey = r.getPublicKey();
            return txt + "," + pubKey;
        }
        public string verify()
        {
            return null;
        }
    }
}