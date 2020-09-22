using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalEngine.Logging
{
	public class EngineLog
	{
		readonly string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RelaperCrystal\\SimpleSeries\\CrystalEngine" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Millisecond.ToString() + ".log");
		public EngineLog()
		{
			if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RelaperCrystal\\SimpleSeries\\CrystalEngine")))
			{
				Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RelaperCrystal\\SimpleSeries\\CrystalEngine"));
				File.WriteAllText(file, "CrystalEngine, Copyright (C) RelaperCrystal 2020\r\n");
			}
		}

#pragma warning disable IDE0060 // 删除未使用的参数
		public void Info(string text, object sender)

		{
			File.WriteAllText(file, string.Format("[{0}] [{1}/INFO]\r\n" ,nameof(sender), DateTime.Now.ToString(), text));
		}

		public void Warning(string text, object sender)
		{
			File.WriteAllText(file, string.Format("[{0}] [{1}/WARN] {2}\r\n", nameof(sender), DateTime.Now.ToString(), text));
		}

		public void Error(string text, object sender)
		{
			File.WriteAllText(file, string.Format("[{0}] [{1}/ERROR] {2}\r\n", nameof(sender), DateTime.Now.ToString(), text));
		}

		public void Fatal(string text, object sender)
		{
			File.WriteAllText(file, string.Format("[{0}] [{1}/FATAL] {2}\r\n", nameof(sender), DateTime.Now.ToString(), text));
		}

		public void Debug(string text, object sender)
		{
			File.WriteAllText(file, string.Format("[{0}] [{1}/DEBUG] {2}\r\n", nameof(sender), DateTime.Now.ToString(), text));
		}
#pragma warning restore IDE0060 // 删除未使用的参数
	}
}

