using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace BlockChain
{
    public class newBlock : block
    {
        public string nextBlock()
        {
            int id = idBlock();
            string phash = prevHashBlock(lastBlock.block);
            long tm = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string[] dt = datax();

            block genBlock = new block
            {
                index = id,
                prevHash = phash,
                Timestamp = tm,
                data = dt
            };
            JsonSerializerOptions op = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            string x = JsonSerializer.Serialize(genBlock, op);
            lastBlock.block = x;
            return x;
        }
        private int idBlock()
        {
            int x = lastBlock.index + 1;
            lastBlock.index = x;
            return x;
    
        }
        private string[] datax()
        {
            string[] c;
            transactions tx = new transactions();
            status st = new status();
            c = st.add("Segundo Bloque");
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