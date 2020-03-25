using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetFile
{
    public static class MeetFileHelper
    {
        public static void WriteStringFile(string text, FileStream stream)
        {
            if(string.IsNullOrEmpty(text))
            {
                throw new ArgumentException();
            }

            if(stream == null || !stream.CanWrite)
            {
                throw new ArgumentException();
            }

            BinaryWriter bw = new BinaryWriter(stream);
            bw.Write(true);
            bw.Write(false);
            bw.Write(text.Length);
            bw.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(text)));
            bw.Write(10);
            bw.Write("UTF-8");
            bw.Close();
            bw.Dispose();
            stream.Dispose();
        }

        public static void WriteStringFile(string text, string path)
        {
            WriteStringFile(text, File.OpenWrite(path));
        }

        public static string ReadStringFile(FileStream stream)
        {
            if (stream == null || !stream.CanRead)
            {
                throw new ArgumentException();
            }

            BinaryReader br = new BinaryReader(stream);
            bool verifyBool1 = br.ReadBoolean();
            bool verifyBool2 = br.ReadBoolean();

            if(!verifyBool1 || verifyBool2)
            {
                throw new InvaildMeetFileException("MeetFile 文件无效，因为其头 2 位的 Boolean 识别头无效。");
            }

            int length = br.ReadInt32();
            string result = br.ReadString();

            int verifyInt = br.ReadInt32();

            if(verifyInt != 10)
            {
                throw new InvaildMeetFileException("MeetFile 文件无效，因为其位于文本后方的整数型识别头无效。");
            }

            string real = Convert.FromBase64String(result).ToString();

            if(br.ReadString() != "UTF-8")
            {
                real = real + Environment.NewLine + "!!!!--------------------------!!!!\r\n编码不是 UTF-8!\r\n这意味着有别的" +
                    "软件创建了这个文件。";
            }

            br.Close();
            br.Dispose();
            return real;
        }

    }

    [Serializable]
    public class InvaildMeetFileException : Exception
    {
        public InvaildMeetFileException(string message) : base(message)
        {
        }

        public InvaildMeetFileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvaildMeetFileException() : base("MeetFile 无效。")
        {

        }

        protected InvaildMeetFileException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }
}
