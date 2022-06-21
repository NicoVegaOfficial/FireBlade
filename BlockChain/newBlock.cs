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
            transactions tx = new transactions();
            int id = 0;
            string phash = i;
            long tm = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string[] dt = tx.add();

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
            return x;
        }
        private static string getHash(string i)
        {
            calcHash ch = new calcHash();
            string x = ch.sha512(i);
            return x;
        }
    }

}
