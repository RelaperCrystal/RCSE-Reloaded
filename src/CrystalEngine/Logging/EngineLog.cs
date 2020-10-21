// CrystalEngine
// Copyright (C) RelaperCrystal 2020

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;

namespace CrystalEngine.Logging
{
	[SuppressMessage("ReSharper", "LocalizableElement")]
	public class EngineLog
	{
		readonly string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RelaperCrystal\\SimpleSeries\\CrystalEngine" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Millisecond.ToString() + ".log");
		public EngineLog()
		{
			if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RelaperCrystal\\SimpleSeries\\CrystalEngine")))
			{
				Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RelaperCrystal\\SimpleSeries\\CrystalEngine"));
				// ReSharper disable once StringLiteralTypo
				File.WriteAllText(file, "CrystalEngine, Copyright (C) RelaperCrystal 2020\r\n");
			}
		}

#pragma warning disable IDE0060 // 删除未使用的参数
		public void Info(string text, string sender)
		{
			File.WriteAllText(file, string.Format("[{0}] [{1}/INFO]\r\n" , sender, DateTime.Now.ToString(CultureInfo.CurrentCulture), text));
		}

		public void Warning(string text, string sender)
		{
			File.WriteAllText(file, $"[{sender}] [{DateTime.Now.ToString(CultureInfo.CurrentCulture)}/WARN] {text}\r\n");
		}

		public void Error(string text, string sender)
		{
			File.WriteAllText(file,
				$"[{sender}] [{DateTime.Now.ToString(CultureInfo.CurrentCulture)}/ERROR] {text}\r\n");
		}

		public void Fatal(string text, string sender)
		{
			File.WriteAllText(file,
				$"[{sender}] [{DateTime.Now.ToString(CultureInfo.CurrentCulture)}/FATAL] {text}\r\n");
		}

		public void Debug(string text, string sender)
		{
			File.WriteAllText(file,
				$"[{sender}] [{DateTime.Now.ToString(CultureInfo.CurrentCulture)}/DEBUG] {text}\r\n");
		}
#pragma warning restore IDE0060 // 删除未使用的参数
	}
}

