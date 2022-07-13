using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace BlockChain
{
    public class accounts
    {
        sign s = new sign();
        public string add(string name, string pubKey)
        {
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