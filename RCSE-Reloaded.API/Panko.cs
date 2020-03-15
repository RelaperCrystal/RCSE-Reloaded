using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded.API
{
    public static class Panko
    {
        public static void SaveAsPanko(string fileName, string text)
        {
            FileStream fs = File.OpenWrite(fileName);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Seek(0, SeekOrigin.Begin);
            bw.Write(1);
            bw.Seek(1, SeekOrigin.Current);
            bw.Write(false);
            bw.Seek(1, SeekOrigin.Current);
            bw.Write(0);
            bw.Seek(1, SeekOrigin.Current);
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
                fs.Position++;
                isCompressed = br.ReadBoolean();
                fs.Position++;
                tool = br.ReadInt32();
                fs.Position++;
                string result = br.ReadString();
                return result;
            }
            catch(Exception ex)
            {
                version = 1;
                isCompressed = false;
                tool = 0;
                return "Panko解码器错误: " + ex.ToString();
            }
        }

        public static string ReadPanko(string fileName) => ReadPanko(fileName);
    }
}
