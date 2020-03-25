using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalEngine.Simple
{
    public static class Panko
    {
        public static void SaveAsPanko(string fileName, string text)
        {
            FileStream fs = File.OpenWrite(fileName);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(2);
            bw.Write(false);
            bw.Write(1);
            bw.Write(Encoding.UTF8.GetBytes(text));
            bw.Close();
        }

        public static string ReadPanko(string fileName, out int version, out bool isCompressed, out int tool)
        {
            try
            {
                FileStream fs = File.OpenRead(fileName);
                BinaryReader br = new BinaryReader(fs);
                version = br.ReadInt32();
                isCompressed = br.ReadBoolean();
                tool = br.ReadInt32();
                string result = br.ReadString();
                return result;
            }
            catch(Exception ex)
            {
                version = 2;
                isCompressed = false;
                tool = 1;
                return "Panko Decoder Error: " + ex.ToString();
            }
        }

        public static string ReadPanko(string fileName) => ReadPanko(fileName);
    }
}
