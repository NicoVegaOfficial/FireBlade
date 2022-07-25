using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BlockChain
{
    public class saveToDisk
    {
        public void save(string name, string input)
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\FireBlade";
            string file = appdata + @"\" + name + ".json";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) == true)
            {
                appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"/FireBlade";
                file = appdata + @"/" + name + ".json";
            }
            if (!Directory.Exists(appdata))
            {
                Directory.CreateDirectory(appdata);
            }
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            using (FileStream fs = File.Create(file))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(input);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
