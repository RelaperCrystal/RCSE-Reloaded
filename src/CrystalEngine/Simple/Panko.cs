using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalEngine.Simple
{
	[Obsolete("Panko 不再被支持。", true)]
	public static class Panko
	{
		[Obsolete("Panko 不再被支持。", true)]
		public static void SaveAsPanko(string fileName, string text)
		{
			//FileStream fs = File.OpenWrite(fileName);
			//BinaryWriter bw = new BinaryWriter(fs);
			//bw.Write(2);
			//bw.Write(false);
			//bw.Write(1);
			//bw.Write(Encoding.UTF8.GetBytes(text));
			//bw.Close();
		}

		[Obsolete("Panko 不再被支持。", true)]
		public static string ReadPanko(string fileName, out int version, out bool isCompressed, out int tool)
		{
			throw new NotImplementedException();
		}

		[Obsolete("Panko 不再被支持。", true)]
		public static string ReadPanko(string fileName) => ReadPanko(fileName);
	}
}
