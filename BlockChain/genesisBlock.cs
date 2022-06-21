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
            string phash = "a6325ed86cc4af78beeb4b2ca801ea948a627e12d406445018f3c95a57370232f7607bf2946eafdba53443e5142aa40ea1ec1ccdcda5002441104dff685acb23"; //nvCoin
            long tm = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string[] dt = st.add();

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
    }
}
