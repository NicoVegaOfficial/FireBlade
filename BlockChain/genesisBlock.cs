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
                prevHash = null,
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
            status st = new status();
            c = st.add("@nico", i);
            return c;
        }
    }
}
