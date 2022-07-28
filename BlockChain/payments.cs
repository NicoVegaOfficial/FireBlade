namespace BlockChain
{
    public class payments
    {
        public string send(string sender, string recipient, decimal amount)
        {            
            string x = sender + "-" + recipient + "-" + amount.ToString();
            return x;
        }
    }
}
