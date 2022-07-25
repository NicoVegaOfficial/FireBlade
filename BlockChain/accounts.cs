using System;

namespace BlockChain
{
    public class accounts
    {
        public string add(string name)
        {
            sign s = new sign();
            rsaEncryption r = new rsaEncryption();
            string pubKey = r.getPublicKey();
            string x = name + "," + pubKey + "," + getTime();
            return x;
        }
        public string verify()
        {
            return null;
        }
        private string getTime()
        {
            long x = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            return x.ToString();
        }
    }
}