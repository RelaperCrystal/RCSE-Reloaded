using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalEngine.Simple.DateTime
{
	[Obsolete("请使用扩展方法 DateTime.OutputChineseFormat()")]
	public class ChinaFormatDateTime
	{
		/// <summary>
		/// 内置的 DateTime。
		/// </summary>
		public System.DateTime DateTime { get; private set; }

		[Obsolete("请使用扩展方法 DateTime.OutputChineseFormat()")]
		public ChinaFormatDateTime(System.DateTime date)
		{
			DateTime = date;
		}

		[Obsolete("请使用扩展方法 DateTime.OutputChineseFormat()")]
		public string GetChinaFormatDate(bool isShortDate)
		{
			if(isShortDate)
			{
				string result = DateTime.Year + "/" + DateTime.Month + "/" + DateTime.Day;
				return result;
			}
			else
			{
				string result = DateTime.Year + "年" + DateTime.Month + "月" + DateTime.Day + "日";
				return result;
			}
		}

		[Obsolete("请使用扩展方法 DateTime.OutputChineseFormat()")]
		public string GetChinaFormatDateTime(bool isShort)
		{
			if (isShort)
			{
				string result = DateTime.Year + "/" + DateTime.Month + "/" + DateTime.Day + " " + DateTime.Hour + ":"
					+ DateTime.Minute + ":" + DateTime.Second;
				return result;
			}
			else
			{
				string result = DateTime.Year + "年" + DateTime.Month + "月" + DateTime.Day + "日" + DateTime.Hour + "时"
					+ DateTime.Minute + "分" + DateTime.Second + "秒";
				return result;
			}
		}

		[Obsolete("请使用扩展方法 DateTime.OutputChineseFormat()")]
		public string GetChinaFormatDateTimeNoSecond(bool isShort)
		{
			if (isShort)
			{
				string result = DateTime.Year + "/" + DateTime.Month + "/" + DateTime.Day + " " + DateTime.Hour + ":"
					+ DateTime.Minute;
				return result;
			}
			else
			{
				string result = DateTime.Year + "年" + DateTime.Month + "月" + DateTime.Day + "日" + DateTime.Hour + "时"
					+ DateTime.Minute + "分";
				return result;
			}
		}
	}
   }