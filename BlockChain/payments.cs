namespace BlockChain
{
    public class payments
    {
        public string send(string sender, string recipient, decimal amount)
        {
            rsaEncryption r = new rsaEncryption();
            string x = sender + "-" + recipient + "-" + amount.ToString();
            string sing = r.signData(x);
            string output = x + "-" + sing;
            return output;
        }
    }
}
