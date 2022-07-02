using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace BlockChain
{
    public class genesisBlock : block
    {
        public string iniciar(string i)
        {
            block genBlock = new block
            {
                index = 0,
                prevHash = "a4abd4448c49562d828115d13a1fccea927f52b4d5459297f8b43e42da89238bc13626e43dcb38ddb082488927ec904fb42057443983e88585179d50551afe62",
                Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                data = datax(i),
                nonce = 0
            };
            JsonSerializerOptions op = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            string x = JsonSerializer.Serialize(genBlock, op);
            lastBlock.index = 0;
            lastBlock.block = x;
            return x;
        }
        private string[] datax(string i)
        {
            string[] c;
            transactions tx = new transactions();
            status st = new status();
            c = st.add("@nico", i);
            return c;
        }
    }
}
