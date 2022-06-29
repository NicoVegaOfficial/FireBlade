using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace BlockChain
{
    public class genesisBlock : block
    {
        public string iniciar()
        {
            transactions tx = new transactions();
            status st = new status();
            int id = 0;
            string phash = "c971e770079bf27bd12ca854eb8076f96df76d3f8e2c2568f9fd3d78b0cd0842cfc3edd2eea0ac8914134cbd4335af450836d39be51ff7d224bc573d137a3ca0"; //NearCoin
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
            lastBlock.index = id;
            lastBlock.block = x;
            return x;
        }
        private string[] datax()
        {
            string[] c;
            transactions tx = new transactions();
            status st = new status();
            c = st.add("nico", "hola mundo");
            return c;
        }
    }
}
