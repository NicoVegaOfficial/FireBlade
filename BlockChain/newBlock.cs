using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace BlockChain
{
    public class newBlock : block
    {
        public string nextBlock(string i)
        {
            block genBlock = new block
            {
                index = idBlock(),
                prevHash = prevHashBlock(lastBlock.block),
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
            calcHash c = new calcHash();
            lastBlock.hash = c.sha512(x);
            lastBlock.block = x;
            return x;
        }
        private int idBlock()
        {
            int x = lastBlock.index + 1;
            lastBlock.index = x;
            return x;

        }

        private string[] datax(string i)
        {
            string[] c;
            status st = new status();
            c = st.add("@System", i);
            return c;
        }
        private static string prevHashBlock(string i)
        {
            calcHash ch = new calcHash();
            string x = ch.sha512(i);
            return x;
        }

    }

}