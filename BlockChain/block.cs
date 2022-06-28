namespace BlockChain
{
    public class block
    {
        public int index { get; set; }
        public string prevHash { get; set; }
        public long Timestamp { get; set; }
        public string[] data { get; set; }
        public int nonce { get; set; }
    }
}
