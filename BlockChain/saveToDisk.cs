using System;
using System.IO;
using System.Text;

namespace BlockChain
{
    public class saveToDisk
    {

        public void save(string name, string input)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filepath = desktop + @"\folder\" + name + ".json";
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            using (FileStream fs = File.Create(filepath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(input);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
